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
	for (int i=0;i<=listaC.num;i++)
	{
		sprintf(jugadoresconectados, "%s/%s", jugadoresconectados, listaC.conectados[i].nombre);
	}
}

int nuevousuario (char nombre[20], char contra[20])
{
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
	exit(0);
}

int login_usuario(char usuario[20], char contra[20])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	int encontrado = 0;
	char query[200];
	sprintf(query,"SELECT Jugador.usuario, Jugador.contrase鎙 FROM Jugador WHERE Jugador.usuario='%s' AND Jugador.contrase鎙='%s'", usuario, contra);
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
		printf("Contrase嚙帶: %s\n", row[1]);
		row = mysql_fetch_row(resultado);
		return 1;
	}
	exit(0);
}

int Consulta1()
{
	//Recibir el jugador con el mayor numero de partidas jugadas (*y que su nombre empiece por la letra A)
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta[200];
	strcpy (consulta,"SELECT usuario FROM Jugador WHERE puntuaciones IN ( SELECT MAX(puntuaciones) FROM Jugador )"); //*usuario LIKE 'A%' AND
	printf("%s\n", consulta);
	err=mysql_query (conn, consulta);
	
	if (err!=0)
	{
		printf("Error al consultar datos de la base %u %s\n",
			 mysql_errno(conn), mysql_error(conn));
		exit (1);
		return -1;
	}
				
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
				
	if (row == NULL)
	{
		printf("No se han obtenido datos en la consulta\n");
		return -2;
	}
	
	else
	{
		while (row !=NULL)
		{
			// la columna 0 contiene el nombre del jugador y la 2 la puntuacion
			printf ("%s\n", row[0]);
			printf ("%d\n", row[2]);
			int puntos = row[2] - '0';
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
			return puntos;
		}
	}
	
	mysql_close (conn);
	exit(0);
}


int Consulta2()
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int cont = 1;
	
	char query[200];
	strcpy(query, "SELECT ID_partida FROM Partidas WHERE cantidad_jugadores = 3");
	printf("%s\n", query);
	err=mysql_query (conn, query);
	
	
	if (err!=0)
	{
		printf ("Error al consultar datos de la base\n");
		return -1;
	} 
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	
	if (row == NULL) 
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2;
	}
	
	else
	{
		
		while (row !=NULL) { 
			
			printf ("Id_partida: %s\n", row[0]);
			row = mysql_fetch_row (resultado);
			cont++;
		}
		return cont;
	}
	
	mysql_close (conn); 
	exit(0);
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
		
		switch(codigo)
		{
		case 0:
			
			terminar = 1;
			
			break;
			
		case 1:
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contra, p);
			
			printf ("Nombre: %s \n, Contrase嚙帶: %s\n", nombre,contra);
			int result = nuevousuario(nombre, contra);
			
			if(result == -1)
			{
				sprintf (respuesta, "1-Error al consultar datos de la base\n");
			}
			
			else if (result == 1)
			{
				sprintf(respuesta, "1-Registrado correctamente!");
			}
			
			printf("---------------------------------------------\n");
			
			break;
			
		case 2:
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contra, p);
			
			printf ("Nombre: %s \n, Contrase嚙帶: %s\n", nombre,contra);
			
			int res = login_usuario(nombre, contra);
			
			if(res == 1)
			{
				sprintf(respuesta, "1-Logueado correctamente\n");
				pthread_mutex_unlock( &mutex );
				PonConectados( nombre, sock_conn);
				pthread_mutex_unlock( &mutex);
			}
			
			else
			{
				sprintf(respuesta, "1-Usuario o contrase嚙帶 incorrectos\n");
			}
			
			printf("---------------------------------------------\n");
			
			break;
		
		case 3:
		{	
			int a = Consulta1();
			if(a == -1)
			{
				sprintf(respuesta,"Error al consultar la base de datos\n");
			}
			else if(a == -2)
			{
				sprintf(respuesta,"No se han obtenido datos en la consulta\n");
			}
			else
			{
				sprintf(respuesta,"Puntuacion mas alta: %d\n", a);
			}
			
			printf("---------------------------------------------\n");
			
			break;
		}
		case 4:
		{
			int cont = Consulta2();
			
			if(cont == -1)
			{
				sprintf(respuesta,"Error al consultar la base de datos\n");
			}
			else if(cont == -2)
			{
				sprintf(respuesta,"No se han obtenido datos en la consulta\n");
			}
			else
			{
				sprintf(respuesta,"Numero de partidas con tres jugadores: %d\n", cont);
			}
			
			printf("---------------------------------------------\n");
			
			break;
		}
		
		default:
			
			break;
		}
		
		if (codigo != 0)
		{
			printf("%s\n", respuesta);
			
			write(sock_conn, respuesta, strlen(respuesta));
			
			printf("resultado: %s\n", jugadoresconectados);
			
			if ((codigo ==1 )||(codigo ==2 )||(codigo ==3 )||(codigo ==4 )||(codigo ==5 ))
			{
				int err;
				
				MYSQL_RES *resultado;
				MYSQL_ROW row;
				
				conn = mysql_init(NULL);
				if(conn==NULL)
				{
					printf("Error al crear la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				
				conn = mysql_real_connect (conn, "localhost", "root", "mysql", "PARCHIS", 0, NULL, 0);
				
				if (conn==NULL)
				{
					printf ("Error al inicializar la conexion: %u %s\n", 
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				ListaConectados listaC;
				DameConectados(jugadoresconectados);
				printf("Resultado conectados: %s\n",jugadoresconectados);
				
				char notificacion [200];
				sprintf (notificacion, "6-%s", jugadoresconectados);
				
				int j;
				for (j=0; j<=listaC.num; j++)
				{
					printf("Notificacion:%s\n",notificacion);
					//write (sockets[j],notificacion, strlen(notificacion));
				}
				printf("Resultado server: %s\n",notificacion);
			}
		}
	}	
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
	serv_adr.sin_port = htons(9011); //escucharemos por el puerto 9080
	
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
