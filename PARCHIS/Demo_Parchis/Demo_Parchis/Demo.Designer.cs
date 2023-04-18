
namespace Demo_Parchis
{
    partial class Demo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablero = new System.Windows.Forms.PictureBox();
            this.dado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.Image = global::Demo_Parchis.Properties.Resources.tablero_parchis_clasico;
            this.tablero.InitialImage = global::Demo_Parchis.Properties.Resources.tablero_parchis_clasico;
            this.tablero.Location = new System.Drawing.Point(257, 15);
            this.tablero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(536, 492);
            this.tablero.TabIndex = 0;
            this.tablero.TabStop = false;
            // 
            // dado
            // 
            this.dado.Location = new System.Drawing.Point(820, 47);
            this.dado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dado.Name = "dado";
            this.dado.Size = new System.Drawing.Size(100, 28);
            this.dado.TabIndex = 1;
            this.dado.Text = "Dado";
            this.dado.UseVisualStyleBackColor = true;
            this.dado.Click += new System.EventHandler(this.dado_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dado);
            this.Controls.Add(this.tablero);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Demo";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Demo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tablero;
        private System.Windows.Forms.Button dado;
    }
}