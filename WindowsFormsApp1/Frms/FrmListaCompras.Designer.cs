
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
            this.dgv_clientexitem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientexitem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_clientexitem
            // 
            this.dgv_clientexitem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_clientexitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientexitem.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dgv_clientexitem.Location = new System.Drawing.Point(17, 25);
            this.dgv_clientexitem.MultiSelect = false;
            this.dgv_clientexitem.Name = "dgv_clientexitem";
            this.dgv_clientexitem.ReadOnly = true;
            this.dgv_clientexitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_clientexitem.Size = new System.Drawing.Size(593, 362);
            this.dgv_clientexitem.TabIndex = 26;
            // 
            // FrmListaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_clientexitem);
            this.Name = "FrmListaCompras";
            this.Size = new System.Drawing.Size(624, 411);
            this.Load += new System.EventHandler(this.FrmListaCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientexitem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_clientexitem;
    }
}
