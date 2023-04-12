#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

int contador;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];
MYSQL *conn;

//estructura de conectados
typedef struct{
	char nombre[20];
	int socket;
} Conectado;

//estructura de la lista de conectados
typedef struct{
	Conectado conectados[100]; //vector de 100 conectados
	int num;
} ListaConectados;

ListaConectados listaC;

int PonConectados (char nombre[20], int socket){
	//A?ade nuevo conectados. retorna 0 si ok y -1 si la lista ya estaba llena y no lo ha podido a?adir
	if(listaC.num ==100)
		return -1;
	else{
		strcpy(listaC.conectados[listaC.num].nombre, nombre);
		listaC.conectados[listaC.num].socket = socket;
		listaC.num++;
		return 0;
	}
}

void DameConectados (char jugadoresconectados[100])
{
	memset(jugadoresconectados, 0, 100);
	int i = 0;
	while(i < listaC.num && listaC.num !=0)
	{
		sprintf(jugadoresconectados, "%s/%s", jugadoresconectados, listaC.conectados[i].nombre);
	}
	if (listaC.num == 0)
		sprintf(jugadoresconectados,"%s/%s",jugadoresconectados, listaC.conectados[0].nombre);
}

int nuevousuario (char nombre[20], char contra[20], char Jugadores[100])
{
	
	listaC.num++;
	DameConectados(Jugadores);
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char query[200];
	sprintf (query, "INSERT INTO Jugador VALUES ('%s','%s',0,0,0)", nombre, contra);
	printf("%s\n",query);
	err=mysql_query (conn, query);
	
	if (err!=0) {
		return -1;
	}else{
		return 1;
	}
}

int login_usuario(char usuario[20], char contra[20], char Jugadores[100])
{
	strcpy(listaC.conectados[listaC.num].nombre,Jugadores);
	listaC.num++;
	DameConectados(Jugadores);
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	int encontrado = 0;
	char query[200];
	sprintf(query,"SELECT Jugador.usuario, Jugador.contrase\ufff1a FROM Jugador WHERE Jugador.usuario='%s' AND Jugador.contrase\ufff1a='%s'", usuario, contra);
	printf("%s\n",query);
	err = mysql_query(conn, query);
	
	if(err != 0)
	{
		return -1;
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		return -1;
	else
	{
		printf("Usuario: %s\n", row[0]);
		strcpy(usuario, row[0]);
		printf("Contrase\ufff1a: %s\n", row[1]);
		row = mysql_fetch_row(resultado);
		return 1;
	}
}

void *AtenderCliente (void *socket)
{
	//Declaraci?n del socket
	int sock_conn;
	int *s;
	s = (int*) socket;
	sock_conn = *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	char jugadoresconectados[100];
	
	
	int terminar =0;
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		char nombre[20];
		char contra[20];
		char contestacion[20];
		char Jugadores[100];
		
		
		switch(codigo)
		{
		case 0:
			p = strtok( NULL, "/");
			
			strcpy (nombre, p);
			// Ya tenemos el nombre
			terminar = 1;
			break;
			
		case 1:
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contra, p);
			
			printf ("Nombre: %s \n, Contrase\ufff1a: %s\n", nombre,contra);
			int result = nuevousuario(nombre,contra,jugadoresconectados);
			
			if(result == -1)
			{
				printf ("1-Error al consultar datos de la base\n");
				strcpy(respuesta,"1-Error al consultar datos de la base\n");
				strcat(respuesta, "/");
				strcat(respuesta, jugadoresconectados);
				printf("%s \n",respuesta);
				
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			else if (result == 1)
			{
				PonConectados(nombre,socket);
				printf("1-Registrado correctamente!\n");
				strcpy(respuesta,"1-Registrado correctamente!");
				strcat(respuesta, "/");
				strcat(respuesta, jugadoresconectados);
				printf("%s \n",respuesta);
				
				write(sock_conn, respuesta, strlen(respuesta));
			}
			break;
			
		case 2:
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contra, p);
			
			int res = login_usuario(nombre, contra,jugadoresconectados);
			
			if(res == 1)
			{
				printf("1-Logueado correctamente\n");
				pthread_mutex_unlock( &mutex );
				PonConectados( nombre, sock_conn);
				pthread_mutex_unlock( &mutex);
				strcpy(respuesta,"1-Logueado correctamente\n");
				strcat(respuesta, "/");
				strcat(respuesta, jugadoresconectados);
				printf("%s \n",respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			else
			{
				printf("1-Usuario o contrase\ufff1a incorrectos\n");
				strcpy(respuesta,"1-Usuario o contrase\ufff1a incorrectos\n");
				strcat(respuesta, "/");
				strcat(respuesta, jugadoresconectados);
				printf("%s \n",respuesta);
				
				write(sock_conn, respuesta, strlen(respuesta));
			}
			break;
			
		case 3:
			
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contra, p);
			
			
			break;
			
		case 4:
			
			break;
			
		case 5:
			DameConectados(jugadoresconectados);
			char respuesta[100];
			strcat(respuesta, "/");
			strcpy(respuesta,jugadoresconectados);
			write(sock_conn, respuesta, strlen(respuesta));
			
			break;
			
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
	
}

int DameSocket (ListaConectados *lista, char nombre[20]){
	//devuelve el socket o -1 si no esta en la lista
	int i=0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado){
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado = 1;
		if(!encontrado)
			i++;
	}
	if(encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
}
int main (int argc, char *argv[])
{	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	//Abrir el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) <0) //creacion del socket de escucha
		printf("Error creant socket");
	
	memset(&serv_adr, 0, sizeof(serv_adr)); //inicializar a cero serv_addr
	serv_adr.sin_family = AF_INET;
	
	//asocia el socket a cualquiera de las IP de la maquina. htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl (INADDR_ANY);
	serv_adr.sin_port = htons(9010); //escucharemos por el puerto 9080
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf("error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	//Conexion MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit;
	}
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "PARCHIS", 0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit;
	}
	
	pthread_t thread;
	i=0;
	for (;;)//bucle infinito
	{
		printf("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL); //acepta conexion a trav???s del socket de escucha
		printf("He recibido conexion\n");
		
		sockets[i] = sock_conn;
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i++;
		
		
	}
}

