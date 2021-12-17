
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListaCompras = new System.Windows.Forms.Button();
            this.tbc_app = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListaCompras
            // 
            this.btnListaCompras.Location = new System.Drawing.Point(3, 0);
            this.btnListaCompras.Name = "btnListaCompras";
            this.btnListaCompras.Size = new System.Drawing.Size(75, 43);
            this.btnListaCompras.TabIndex = 1;
            this.btnListaCompras.Text = "button2";
            this.btnListaCompras.UseVisualStyleBackColor = true;
            this.btnListaCompras.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbc_app
            // 
            this.tbc_app.Location = new System.Drawing.Point(12, 61);
            this.tbc_app.Name = "tbc_app";
            this.tbc_app.SelectedIndex = 0;
            this.tbc_app.Size = new System.Drawing.Size(679, 521);
            this.tbc_app.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnListaCompras);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 43);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(110)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(767, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbc_app);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListaCompras;
        private System.Windows.Forms.TabControl tbc_app;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

