using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Controls
{
    public class txtMoeda : TextBox
    {

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = Color.White;
            if (this.Text == "") return;
            try
            {
               Convert.ToDouble(this.Text.Replace("R$ ", ""));                
            }
            catch(Exception)
            {
                this.Text = "";
                MessageBox.Show("Valor inválido");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "";
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.TextAlign = HorizontalAlignment.Left;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 8) return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }         
        }
    }
}
