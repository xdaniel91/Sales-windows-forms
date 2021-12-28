using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmRegisterProduct : UserControl
    {
        public FrmRegisterProduct()
        {
            InitializeComponent();

            lblName.Text = "Nome";
            lblPrice.Text = "Preço";
            lblQuantity.Text = "Quantidade";
            btnRegister.Text = "Registrar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMoeda.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtQuantity.Text) || int.Parse(txtQuantity.Text) <= 0)
            {
                MessageBox.Show("Insira valores válidos");
            }
            else
            {
                try
                {           
                    var p = new Produto(txtId.Text ,txtName.Text, Convert.ToDouble(txtMoeda.Text.Replace(".",",")), Convert.ToInt32(txtQuantity.Text));
                    DataBase.lista_produtos.Add(p);
                    MessageBox.Show("Produto adicionado!", "Time Share Soluções");
                    txtMoeda.Text = "";
                    txtName.Text = "";
                    txtQuantity.Text = "";
                    txtId.Text = "";                
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o produto! {ex.Message}", "Time Share Soluções");
                }
            }
        }

    }
}


