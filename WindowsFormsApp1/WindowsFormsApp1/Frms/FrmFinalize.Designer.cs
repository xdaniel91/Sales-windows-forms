
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
            this.lst_principal = new System.Windows.Forms.ListBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_principal
            // 
            this.lst_principal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lst_principal.BackColor = System.Drawing.Color.LemonChiffon;
            this.lst_principal.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_principal.ForeColor = System.Drawing.Color.Black;
            this.lst_principal.FormattingEnabled = true;
            this.lst_principal.ItemHeight = 18;
            this.lst_principal.Location = new System.Drawing.Point(12, 137);
            this.lst_principal.Name = "lst_principal";
            this.lst_principal.Size = new System.Drawing.Size(437, 328);
            this.lst_principal.TabIndex = 2;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lblCustomer.Location = new System.Drawing.Point(9, 85);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(224, 31);
            this.lblCustomer.TabIndex = 3;
            this.lblCustomer.Text = "label1";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomer.Click += new System.EventHandler(this.lblCustomer_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(9, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 31);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label1";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(225, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(224, 31);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "label2";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(253, 433);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(192, 23);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "label1";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmFinalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 535);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lst_principal);
            this.Name = "FrmFinalize";
            this.Text = "FrmFinalize";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_principal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblData;
    }
}