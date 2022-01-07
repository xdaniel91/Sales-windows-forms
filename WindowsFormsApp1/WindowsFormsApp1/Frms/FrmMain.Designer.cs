
namespace WindowsFormsApp1
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnIniciarCompra = new System.Windows.Forms.Button();
            this.tbc_app = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnUserRegister = new System.Windows.Forms.Button();
            this.BtnRegisterProduct = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.picbox_Menu = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Menu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarCompra
            // 
            this.btnIniciarCompra.BackColor = System.Drawing.Color.Turquoise;
            this.btnIniciarCompra.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCompra.Location = new System.Drawing.Point(1, 66);
            this.btnIniciarCompra.Name = "btnIniciarCompra";
            this.btnIniciarCompra.Size = new System.Drawing.Size(81, 43);
            this.btnIniciarCompra.TabIndex = 1;
            this.btnIniciarCompra.Text = "button2";
            this.btnIniciarCompra.UseVisualStyleBackColor = false;
            this.btnIniciarCompra.Click += new System.EventHandler(this.btnListaCompras_Click);
            // 
            // tbc_app
            // 
            this.tbc_app.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_app.Location = new System.Drawing.Point(88, 53);
            this.tbc_app.Name = "tbc_app";
            this.tbc_app.SelectedIndex = 0;
            this.tbc_app.Size = new System.Drawing.Size(1297, 756);
            this.tbc_app.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnListaClientes);
            this.panel1.Controls.Add(this.btnCompras);
            this.panel1.Controls.Add(this.btnUserRegister);
            this.panel1.Controls.Add(this.BtnRegisterProduct);
            this.panel1.Controls.Add(this.btnIniciarCompra);
            this.panel1.Location = new System.Drawing.Point(1, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 752);
            this.panel1.TabIndex = 3;
            // 
            // btnListaClientes
            // 
            this.btnListaClientes.BackColor = System.Drawing.Color.Turquoise;
            this.btnListaClientes.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaClientes.Location = new System.Drawing.Point(1, 216);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(81, 43);
            this.btnListaClientes.TabIndex = 5;
            this.btnListaClientes.Text = "button2";
            this.btnListaClientes.UseVisualStyleBackColor = false;
            this.btnListaClientes.Click += new System.EventHandler(this.btnListaClientes_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Turquoise;
            this.btnCompras.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.Location = new System.Drawing.Point(1, 166);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(81, 43);
            this.btnCompras.TabIndex = 4;
            this.btnCompras.Text = "button2";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnUserRegister
            // 
            this.btnUserRegister.BackColor = System.Drawing.Color.Turquoise;
            this.btnUserRegister.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRegister.Location = new System.Drawing.Point(1, 116);
            this.btnUserRegister.Name = "btnUserRegister";
            this.btnUserRegister.Size = new System.Drawing.Size(81, 43);
            this.btnUserRegister.TabIndex = 3;
            this.btnUserRegister.Text = "button2";
            this.btnUserRegister.UseVisualStyleBackColor = false;
            this.btnUserRegister.Click += new System.EventHandler(this.btnRegistroCliente_Click);
            // 
            // BtnRegisterProduct
            // 
            this.BtnRegisterProduct.BackColor = System.Drawing.Color.Turquoise;
            this.BtnRegisterProduct.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegisterProduct.Location = new System.Drawing.Point(1, 16);
            this.BtnRegisterProduct.Name = "BtnRegisterProduct";
            this.BtnRegisterProduct.Size = new System.Drawing.Size(82, 43);
            this.BtnRegisterProduct.TabIndex = 2;
            this.BtnRegisterProduct.Text = "button1";
            this.BtnRegisterProduct.UseVisualStyleBackColor = false;
            this.BtnRegisterProduct.Click += new System.EventHandler(this.btnRegistroProduto_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(1352, 26);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(32, 29);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // picbox_Menu
            // 
            this.picbox_Menu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picbox_Menu.Image = ((System.Drawing.Image)(resources.GetObject("picbox_Menu.Image")));
            this.picbox_Menu.Location = new System.Drawing.Point(1, -1);
            this.picbox_Menu.Name = "picbox_Menu";
            this.picbox_Menu.Size = new System.Drawing.Size(82, 56);
            this.picbox_Menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_Menu.TabIndex = 3;
            this.picbox_Menu.TabStop = false;
            this.picbox_Menu.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picbox_Menu.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(87, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1297, 56);
            this.label1.TabIndex = 4;
            this.label1.Text = "TimeShare Soluções";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1384, 811);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picbox_Menu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbc_app);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_Menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarCompra;
        private System.Windows.Forms.TabControl tbc_app;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnRegisterProduct;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.PictureBox picbox_Menu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUserRegister;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnListaClientes;
    }
}

