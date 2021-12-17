
namespace WindowsFormsApp1
{
    partial class FrmCupom
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
            this.lstCupom = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstCupom
            // 
            this.lstCupom.FormattingEnabled = true;
            this.lstCupom.Location = new System.Drawing.Point(9, 12);
            this.lstCupom.Name = "lstCupom";
            this.lstCupom.Size = new System.Drawing.Size(306, 277);
            this.lstCupom.TabIndex = 0;
            // 
            // FrmCupom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 298);
            this.Controls.Add(this.lstCupom);
            this.Name = "FrmCupom";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCupom;
    }
}