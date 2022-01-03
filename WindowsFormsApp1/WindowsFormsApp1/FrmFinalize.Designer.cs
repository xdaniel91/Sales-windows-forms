
namespace WindowsFormsApp1
{
    partial class FrmFinalize
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
            this.lst_compras = new System.Windows.Forms.ListBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_compras
            // 
            this.lst_compras.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lst_compras.BackColor = System.Drawing.Color.Gray;
            this.lst_compras.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_compras.ForeColor = System.Drawing.Color.Black;
            this.lst_compras.FormattingEnabled = true;
            this.lst_compras.ItemHeight = 18;
            this.lst_compras.Location = new System.Drawing.Point(7, 43);
            this.lst_compras.Name = "lst_compras";
            this.lst_compras.Size = new System.Drawing.Size(323, 328);
            this.lst_compras.TabIndex = 2;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 387);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(35, 13);
            this.lblCustomer.TabIndex = 3;
            this.lblCustomer.Text = "label1";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 430);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "label2";
            // 
            // FrmFinalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 483);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lst_compras);
            this.Name = "FrmFinalize";
            this.Text = "FrmFinalize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_compras;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTotal;
    }
}