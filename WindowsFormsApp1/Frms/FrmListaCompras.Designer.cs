
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPesquisarID = new System.Windows.Forms.Button();
            this.btnPesquisarNome = new System.Windows.Forms.Button();
            this.btnPesquisarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientexitem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_clientexitem
            // 
            this.dgv_clientexitem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_clientexitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientexitem.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dgv_clientexitem.Location = new System.Drawing.Point(3, 221);
            this.dgv_clientexitem.MultiSelect = false;
            this.dgv_clientexitem.Name = "dgv_clientexitem";
            this.dgv_clientexitem.ReadOnly = true;
            this.dgv_clientexitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_clientexitem.Size = new System.Drawing.Size(626, 362);
            this.dgv_clientexitem.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 20);
            this.textBox2.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(230, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 30;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarID
            // 
            this.btnPesquisarID.Location = new System.Drawing.Point(71, 19);
            this.btnPesquisarID.Name = "btnPesquisarID";
            this.btnPesquisarID.Size = new System.Drawing.Size(90, 20);
            this.btnPesquisarID.TabIndex = 31;
            this.btnPesquisarID.Text = "pesquisar por id";
            this.btnPesquisarID.UseVisualStyleBackColor = true;
            this.btnPesquisarID.Click += new System.EventHandler(this.btnPesquisarID_Click);
            // 
            // btnPesquisarNome
            // 
            this.btnPesquisarNome.Location = new System.Drawing.Point(213, 66);
            this.btnPesquisarNome.Name = "btnPesquisarNome";
            this.btnPesquisarNome.Size = new System.Drawing.Size(126, 20);
            this.btnPesquisarNome.TabIndex = 32;
            this.btnPesquisarNome.Text = "pesquisar por nome";
            this.btnPesquisarNome.UseVisualStyleBackColor = true;
            this.btnPesquisarNome.Click += new System.EventHandler(this.btnPesquisarNome_Click);
            // 
            // btnPesquisarData
            // 
            this.btnPesquisarData.Location = new System.Drawing.Point(249, 113);
            this.btnPesquisarData.Name = "btnPesquisarData";
            this.btnPesquisarData.Size = new System.Drawing.Size(122, 20);
            this.btnPesquisarData.TabIndex = 33;
            this.btnPesquisarData.Text = "Pesquisar por data";
            this.btnPesquisarData.UseVisualStyleBackColor = true;
            this.btnPesquisarData.Click += new System.EventHandler(this.btnPesquisarData_Click);
            // 
            // FrmListaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPesquisarData);
            this.Controls.Add(this.btnPesquisarNome);
            this.Controls.Add(this.btnPesquisarID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgv_clientexitem);
            this.Name = "FrmListaCompras";
            this.Size = new System.Drawing.Size(632, 586);
            this.Load += new System.EventHandler(this.FrmListaCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientexitem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_clientexitem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPesquisarID;
        private System.Windows.Forms.Button btnPesquisarNome;
        private System.Windows.Forms.Button btnPesquisarData;
    }
}
