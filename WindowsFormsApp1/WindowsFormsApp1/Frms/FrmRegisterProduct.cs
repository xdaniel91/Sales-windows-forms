using Library.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmRegisterProduct : UserControl
    {
        string Connection = "C:\\Users\\DanielRodriguesCarva\\Documents\\FicharioProducts";
        //string Connection = "C:\\Users\\xdani\\OneDrive\\Documentos\\FicharioProducts";

        public FrmRegisterProduct()
        {
            InitializeComponent();

            lblName.Text = "Nome";
            lblPrice.Text = "Preço";
            lblQuantity.Text = "Quantidade";
            btnRegister.Text = "Registrar";
            lblId.Text = "Id";
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
                    var product = ReadFrm();
                    product.ValidaClasse();
                    product.IncluirFichario(Connection);
                    Utils.FeedLists();
                    MessageBox.Show("Produto adicionado!", "TimeShare Soluções");
                    txtMoeda.Text = "";
                    txtName.Text = "";
                    txtQuantity.Text = "";
                    txtId.Text = "";
                }
                catch (ValidationException vex)
                {

                    MessageBox.Show($"{vex.Message}", "TimeShare Soluções");
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o produto! {ex.Message}", "TimeShare Soluções");
                }
            }
        }
        Product ReadFrm()
        {
            var p = new Product(txtId.Text, txtName.Text, Convert.ToDouble(txtMoeda.Text.Replace(".", ",")), Convert.ToInt32(txtQuantity.Text));
            return p;
        }

    }
}


