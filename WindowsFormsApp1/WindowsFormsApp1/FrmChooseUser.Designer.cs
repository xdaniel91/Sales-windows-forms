
namespace WindowsFormsApp1
{
    partial class FrmChooseUser
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
            this.lst_cliente = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_cliente
            // 
            this.lst_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lst_cliente.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lst_cliente.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_cliente.ForeColor = System.Drawing.Color.Black;
            this.lst_cliente.FormattingEnabled = true;
            this.lst_cliente.ItemHeight = 18;
            this.lst_cliente.Location = new System.Drawing.Point(12, 2);
            this.lst_cliente.Name = "lst_cliente";
            this.lst_cliente.Size = new System.Drawing.Size(290, 256);
            this.lst_cliente.TabIndex = 10;
            this.lst_cliente.DoubleClick += new System.EventHandler(this.lst_cliente_DoubleClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 274);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(290, 34);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Selecionar Cliente";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // FrmChooseUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 328);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lst_cliente);
            this.Name = "FrmChooseUser";
            this.Text = "Selecionar cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_cliente;
        private System.Windows.Forms.Button btnSelect;
    }
}