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
        public decimal Tarjeta {get; set;}
        public String NoTarjeta { get; set; }
        public decimal Cheque { get; set; }
        public String NoCheque { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Credito { get; set; }
        public DataTable table { get; set; }

        public FrmPago()
        {
            
            InitializeComponent();

            
        }
        
        private void FrmPago_Load(object sender, EventArgs e)
        {
            var Frm = new FrmFactura();
            BtnCobrar.Enabled = Enabled;
            LblTotal.Text = Total.ToString();
        }
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }  
        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void Calcular(Object sender,EventArgs e)
        {
            Efectivo = (TxtEfectivo.Text != "") ? Convert.ToDecimal(TxtEfectivo.Text) : 0;
            Cheque = (TxtCheque.Text != "") ? Convert.ToDecimal(TxtCheque.Text) : 0;
            Tarjeta = (TxtTarjeta.Text != "") ? Convert.ToDecimal(TxtTarjeta.Text) : 0;
            Credito = (TxtCredito.Text != "") ? Convert.ToDecimal(TxtCredito.Text) : 0;

            Total = (LblTotal.Text != "") ?
                (Efectivo + Tarjeta + Cheque + Credito)
                - Convert.ToDecimal(LblTotal.Text) : 0;

            TxtDevuelta.Text = Total.ToString();

            if (Total < 0)
                TxtDevuelta.BackColor = Color.Red;
            else
                TxtDevuelta.BackColor = Color.Green;

            if (Total >= 0)
            {
                BtnCobrar.Enabled = true;
                if (TxtEfectivo.Focused)
                {
                    TxtCheque.Enabled = false;
                    TxtNoCheque.Enabled = false;
                    TxtNoTarjeta.Enabled = false;
                    TxtTarjeta.Enabled = false;
                    TxtClienteid.Enabled = false;
                    TxtCredito.Enabled = false;
                }
                else if (TxtCheque.Focused)
                {
                    TxtEfectivo.Enabled = false;
                    TxtNoTarjeta.Enabled = false;
                    TxtTarjeta.Enabled = false;
                    TxtCredito.Enabled = false;
                    TxtClienteid.Enabled = false;

                }
                else if (TxtCredito.Focused)
                {
                    TxtEfectivo.Enabled = false;
                    TxtNoTarjeta.Enabled = false;
                    TxtTarjeta.Enabled = false;
                    TxtCheque.Enabled = false;
                    TxtNoCheque.Enabled = false;
                }
                else if (TxtTarjeta.Focused)
                {
                    TxtEfectivo.Enabled = false;
                    TxtNoTarjeta.Enabled = false;
                    TxtCheque.Enabled = false;
                    TxtNoCheque.Enabled = false;
                    TxtCredito.Enabled = false;
                    TxtClienteid.Enabled = false;
                }

            }
            else
            {
                Metodos Method = new Metodos();
                Method.EnableControls(panel1);
                BtnCobrar.Enabled = false;
            }

        }
      
    }
}
