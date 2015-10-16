using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Vista
{
    public partial class FrmPago : Form
    {
        public decimal Total { get; set; }
        public DataTable table { get; set; }
        public FrmPago()
        {
            
            InitializeComponent();
            
        }

        private void GbEfectivo_Enter(object sender, EventArgs e)
        {

        }

        private void TxtEfectivo_TextChanged(object sender, EventArgs e)
        {
            Decimal Total = (TxtEfectivo.Text != "" && LblTotal.Text != "") ? Convert.ToDecimal(TxtEfectivo.Text) - Convert.ToDecimal(LblTotal.Text): 0;
            TxtDevuelta.Text = Total.ToString();
            if (Total < 0)
                TxtDevuelta.BackColor = Color.Red;
            else
                TxtDevuelta.BackColor = Color.Green;
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            var Frm = new FrmFactura();
            LblTotal.Text = Total.ToString();
        }

        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
