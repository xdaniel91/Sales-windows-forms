
namespace WindowsFormsApp1
{
    partial class FrmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrder));
            this.lst_produtos = new System.Windows.Forms.ListBox();
            this.lst_compras = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnQuantidade = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFinzaliar = new System.Windows.Forms.Button();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantity = new WindowsFormsApp1.Controls.txtInt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_produtos
            // 
            this.lst_produtos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lst_produtos.BackColor = System.Drawing.Color.Gray;
            this.lst_produtos.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_produtos.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lst_produtos.FormattingEnabled = true;
            this.lst_produtos.ItemHeight = 18;
            this.lst_produtos.Location = new System.Drawing.Point(3, 3);
            this.lst_produtos.Name = "lst_produtos";
            this.lst_produtos.Size = new System.Drawing.Size(280, 292);
            this.lst_produtos.TabIndex = 0;
            this.lst_produtos.DoubleClick += new System.EventHandler(this.lst_produtos_DoubleClick);
            // 
            // lst_compras
            // 
            this.lst_compras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_compras.BackColor = System.Drawing.Color.Gray;
            this.lst_compras.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_compras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lst_compras.FormattingEnabled = true;
            this.lst_compras.ItemHeight = 18;
            this.lst_compras.Location = new System.Drawing.Point(302, 3);
            this.lst_compras.Name = "lst_compras";
            this.lst_compras.Size = new System.Drawing.Size(323, 292);
            this.lst_compras.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(302, 305);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(323, 41);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total R$";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuantidade
            // 
            this.btnQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("btnQuantidade.Image")));
            this.btnQuantidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuantidade.Location = new System.Drawing.Point(201, 305);
            this.btnQuantidade.Name = "btnQuantidade";
            this.btnQuantidade.Size = new System.Drawing.Size(82, 31);
            this.btnQuantidade.TabIndex = 3;
            this.btnQuantidade.Text = "button1";
            this.btnQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuantidade.UseVisualStyleBackColor = true;
            this.btnQuantidade.Click += new System.EventHandler(this.btnIniciarCompra_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(302, 359);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(105, 31);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "button2";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFinzaliar
            // 
            this.btnFinzaliar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinzaliar.BackColor = System.Drawing.Color.Transparent;
            this.btnFinzaliar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinzaliar.Image")));
            this.btnFinzaliar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinzaliar.Location = new System.Drawing.Point(520, 359);
            this.btnFinzaliar.Name = "btnFinzaliar";
            this.btnFinzaliar.Size = new System.Drawing.Size(105, 31);
            this.btnFinzaliar.TabIndex = 5;
            this.btnFinzaliar.Text = "button3";
            this.btnFinzaliar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinzaliar.UseVisualStyleBackColor = false;
            this.btnFinzaliar.Click += new System.EventHandler(this.btnFinzaliar_Click);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQuantidade.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(8, 310);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(93, 23);
            this.lblQuantidade.TabIndex = 7;
            this.lblQuantidade.Text = "label1";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQuantity.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(107, 311);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(48, 22);
            this.txtQuantity.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lst_produtos);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.lst_compras);
            this.panel1.Controls.Add(this.lblQuantidade);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnFinzaliar);
            this.panel1.Controls.Add(this.btnQuantidade);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 398);
            this.panel1.TabIndex = 9;
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panel1);
            this.Name = "FrmOrder";
            this.Size = new System.Drawing.Size(637, 404);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_produtos;
        private System.Windows.Forms.ListBox lst_compras;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnQuantidade;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFinzaliar;
        private System.Windows.Forms.Label lblQuantidade;
        private Controls.txtInt txtQuantity;
        private System.Windows.Forms.Panel panel1;
    }
}
