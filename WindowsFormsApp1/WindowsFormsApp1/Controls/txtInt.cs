using System.Windows.Forms;

namespace WindowsFormsApp1.Controls
{
    class txtInt : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "";
            }
        }
      
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 8) return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
