
namespace WindowsFormsApp1.Frms
{
    partial class FrmListaCompras
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
            this.lst_orders = new System.Windows.Forms.ListBox();
            this.lst_infos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_orders
            // 
            this.lst_orders.BackColor = System.Drawing.Color.PapayaWhip;
            this.lst_orders.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_orders.FormattingEnabled = true;
            this.lst_orders.ItemHeight = 18;
            this.lst_orders.Location = new System.Drawing.Point(18, 59);
            this.lst_orders.Name = "lst_orders";
            this.lst_orders.Size = new System.Drawing.Size(253, 490);
            this.lst_orders.TabIndex = 0;
            this.lst_orders.DoubleClick += new System.EventHandler(this.DoubleClick);
            // 
            // lst_infos
            // 
            this.lst_infos.BackColor = System.Drawing.Color.PapayaWhip;
            this.lst_infos.Font = new System.Drawing.Font("Arial", 12F);
            this.lst_infos.FormattingEnabled = true;
            this.lst_infos.ItemHeight = 18;
            this.lst_infos.Location = new System.Drawing.Point(362, 59);
            this.lst_infos.Name = "lst_infos";
            this.lst_infos.Size = new System.Drawing.Size(593, 490);
            this.lst_infos.TabIndex = 1;
            // 
            // FrmListaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_infos);
            this.Controls.Add(this.lst_orders);
            this.Name = "FrmListaCompras";
            this.Size = new System.Drawing.Size(1031, 628);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_orders;
        private System.Windows.Forms.ListBox lst_infos;
    }
}
