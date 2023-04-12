

namespace Proyecto_Parhis
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dameconectados = new System.Windows.Forms.Button();
            this.TablaConectados = new System.Windows.Forms.DataGridView();
            this.Consulta2 = new System.Windows.Forms.Button();
            this.Consulta1 = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.Button();
            this.darse_alta = new System.Windows.Forms.Button();
            this.log_contraseña = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.log_nombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.alta_contraseña = new System.Windows.Forms.TextBox();
            this.alta_nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaConectados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Proyecto_Parhis.Properties.Resources.parchis__1_;
            this.pictureBox1.Location = new System.Drawing.Point(444, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(517, 517);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.dameconectados);
            this.groupBox1.Controls.Add(this.TablaConectados);
            this.groupBox1.Controls.Add(this.Consulta2);
            this.groupBox1.Controls.Add(this.Consulta1);
            this.groupBox1.Controls.Add(this.log);
            this.groupBox1.Controls.Add(this.darse_alta);
            this.groupBox1.Controls.Add(this.log_contraseña);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.log_nombre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.alta_contraseña);
            this.groupBox1.Controls.Add(this.alta_nombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Cambria Math", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 629);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menú:";
            // 
            // dameconectados
            // 
            this.dameconectados.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dameconectados.Location = new System.Drawing.Point(266, 447);
            this.dameconectados.Name = "dameconectados";
            this.dameconectados.Size = new System.Drawing.Size(126, 23);
            this.dameconectados.TabIndex = 21;
            this.dameconectados.Text = "Dame conectados";
            this.dameconectados.UseVisualStyleBackColor = true;
            this.dameconectados.Click += new System.EventHandler(this.dameconectados_Click);
            // 
            // TablaConectados
            // 
            this.TablaConectados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.TablaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaConectados.Location = new System.Drawing.Point(266, 476);
            this.TablaConectados.Name = "TablaConectados";
            this.TablaConectados.RowTemplate.Height = 25;
            this.TablaConectados.Size = new System.Drawing.Size(109, 144);
            this.TablaConectados.TabIndex = 20;
            this.TablaConectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaConectados_CellContentClick);
            // 
            // Consulta2
            // 
            this.Consulta2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Consulta2.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Consulta2.Location = new System.Drawing.Point(12, 546);
            this.Consulta2.Name = "Consulta2";
            this.Consulta2.Size = new System.Drawing.Size(188, 48);
            this.Consulta2.TabIndex = 19;
            this.Consulta2.Text = "CONSULTA 2";
            this.Consulta2.UseVisualStyleBackColor = false;
            this.Consulta2.Click += new System.EventHandler(this.Consulta2_Click);
            // 
            // Consulta1
            // 
            this.Consulta1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Consulta1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Consulta1.Location = new System.Drawing.Point(12, 469);
            this.Consulta1.Name = "Consulta1";
            this.Consulta1.Size = new System.Drawing.Size(188, 48);
            this.Consulta1.TabIndex = 18;
            this.Consulta1.Text = "CONSULTA 1";
            this.Consulta1.UseVisualStyleBackColor = false;
            this.Consulta1.Click += new System.EventHandler(this.Consulta1_Click);
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log.Location = new System.Drawing.Point(228, 343);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(83, 29);
            this.log.TabIndex = 16;
            this.log.Text = "Log in";
            this.log.UseVisualStyleBackColor = true;
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // darse_alta
            // 
            this.darse_alta.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.darse_alta.Location = new System.Drawing.Point(228, 169);
            this.darse_alta.Name = "darse_alta";
            this.darse_alta.Size = new System.Drawing.Size(83, 30);
            this.darse_alta.TabIndex = 15;
            this.darse_alta.Text = "Enviar";
            this.darse_alta.UseVisualStyleBackColor = true;
            this.darse_alta.Click += new System.EventHandler(this.darse_alta_Click);
            // 
            // log_contraseña
            // 
            this.log_contraseña.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log_contraseña.Location = new System.Drawing.Point(100, 363);
            this.log_contraseña.Name = "log_contraseña";
            this.log_contraseña.Size = new System.Drawing.Size(100, 32);
            this.log_contraseña.TabIndex = 14;
            this.log_contraseña.TextChanged += new System.EventHandler(this.log_contraseña_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria Math", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(7, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 67);
            this.label8.TabIndex = 13;
            this.label8.Text = "Contraseña: ";
            // 
            // log_nombre
            // 
            this.log_nombre.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log_nombre.Location = new System.Drawing.Point(100, 310);
            this.log_nombre.Name = "log_nombre";
            this.log_nombre.Size = new System.Drawing.Size(100, 32);
            this.log_nombre.TabIndex = 12;
            this.log_nombre.TextChanged += new System.EventHandler(this.log_nombre_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria Math", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(20, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 67);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nombre: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria Math", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 73);
            this.label6.TabIndex = 10;
            this.label6.Text = "- Loguearse";
            // 
            // alta_contraseña
            // 
            this.alta_contraseña.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alta_contraseña.Location = new System.Drawing.Point(100, 192);
            this.alta_contraseña.Name = "alta_contraseña";
            this.alta_contraseña.Size = new System.Drawing.Size(100, 32);
            this.alta_contraseña.TabIndex = 9;
            this.alta_contraseña.TextChanged += new System.EventHandler(this.alta_contraseña_TextChanged);
            // 
            // alta_nombre
            // 
            this.alta_nombre.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alta_nombre.Location = new System.Drawing.Point(100, 136);
            this.alta_nombre.Name = "alta_nombre";
            this.alta_nombre.Size = new System.Drawing.Size(100, 32);
            this.alta_nombre.TabIndex = 8;
            this.alta_nombre.TextChanged += new System.EventHandler(this.alta_nombre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria Math", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 73);
            this.label5.TabIndex = 7;
            this.label5.Text = "- Darse de alta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria Math", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(7, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 67);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria Math", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 67);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(485, 558);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 70);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(169, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "PARCHIS";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 669);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaConectados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox alta_nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox log_contraseña;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox log_nombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox alta_contraseña;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Button darse_alta;
        private System.Windows.Forms.Button Consulta2;
        private System.Windows.Forms.Button Consulta1;
        private System.Windows.Forms.DataGridView TablaConectados;
        private System.Windows.Forms.Button dameconectados;
    }
}

