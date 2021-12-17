
namespace WindowsFormsApp1
{
    partial class ListaCompras
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaCompras));
            this.lst_produtos = new System.Windows.Forms.ListBox();
            this.lst_compras = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnQuantidade = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFinzaliar = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_produtos
            // 
            this.lst_produtos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lst_produtos.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_produtos.FormattingEnabled = true;
            this.lst_produtos.ItemHeight = 18;
            this.lst_produtos.Location = new System.Drawing.Point(20, 24);
            this.lst_produtos.Name = "lst_produtos";
            this.lst_produtos.Size = new System.Drawing.Size(254, 310);
            this.lst_produtos.TabIndex = 0;
            this.lst_produtos.DoubleClick += new System.EventHandler(this.lst_produtos_DoubleClick);
            // 
            // lst_compras
            // 
            this.lst_compras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lst_compras.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_compras.FormattingEnabled = true;
            this.lst_compras.ItemHeight = 18;
            this.lst_compras.Location = new System.Drawing.Point(305, 24);
            this.lst_compras.Name = "lst_compras";
            this.lst_compras.Size = new System.Drawing.Size(248, 274);
            this.lst_compras.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(305, 304);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(248, 41);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuantidade
            // 
            this.btnQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("btnQuantidade.Image")));
            this.btnQuantidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuantidade.Location = new System.Drawing.Point(192, 344);
            this.btnQuantidade.Name = "btnQuantidade";
            this.btnQuantidade.Size = new System.Drawing.Size(82, 31);
            this.btnQuantidade.TabIndex = 3;
            this.btnQuantidade.Text = "button1";
            this.btnQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuantidade.UseVisualStyleBackColor = true;
            this.btnQuantidade.Click += new System.EventHandler(this.btnIniciarCompra_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(305, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnFinzaliar
            // 
            this.btnFinzaliar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinzaliar.Image")));
            this.btnFinzaliar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinzaliar.Location = new System.Drawing.Point(471, 349);
            this.btnFinzaliar.Name = "btnFinzaliar";
            this.btnFinzaliar.Size = new System.Drawing.Size(82, 31);
            this.btnFinzaliar.TabIndex = 5;
            this.btnFinzaliar.Text = "button3";
            this.btnFinzaliar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinzaliar.UseVisualStyleBackColor = true;
            this.btnFinzaliar.Click += new System.EventHandler(this.btnFinzaliar_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(132, 349);
            this.txtQuantity.Mask = "0000";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(32, 23);
            this.txtQuantity.TabIndex = 6;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(17, 349);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(93, 23);
            this.lblQuantidade.TabIndex = 7;
            this.lblQuantidade.Text = "label1";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(110)))), ((int)(((byte)(170)))));
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnFinzaliar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnQuantidade);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lst_compras);
            this.Controls.Add(this.lst_produtos);
            this.Name = "ListaCompras";
            this.Size = new System.Drawing.Size(566, 444);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_produtos;
        private System.Windows.Forms.ListBox lst_compras;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnQuantidade;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFinzaliar;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantidade;
    }
}
