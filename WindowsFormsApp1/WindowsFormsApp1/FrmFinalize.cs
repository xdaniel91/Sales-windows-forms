using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmFinalize : Form
    {
        public ListBox lst_principal { get; set; }
        public Label LabelTotal { get; set; }
        public Label LabelCustomer  { get; set; }
      
        public FrmFinalize()
        {
            InitializeComponent();
            lblCustomer.Text = LabelCustomer.Text;
            lblTotal = LabelTotal;
        }
    }
}