using Formularios;
using Sistema.Data;
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
    public partial class FrmFactura : Form
    {
       Consulta.FrmConsultaProd Frm = new Consulta.FrmConsultaProd();
        public FrmFactura()
        {
            InitializeComponent();
        }

        #region Propierty
        private void FrmFactura_Load(object sender, EventArgs e) 
        {
          
        }
        public string Prop_idProducts { get; set; }
        public string Prop_NameProducts { get; set; }
        public string Prop_PriceProducts1 { get; set; }
        public string Prop_PriceProducts2 { get; set; }
        public string Prop_PriceProducts3 { get; set; }
        public string Prop_Unidad { get; set; }
        public int Prop_Cant { get; set; }
        public double Prop_TExento { get; set; }
        public double Prop_TGravado { get; set; }
        public double Prop_Titbis { get; set; }
        public double Prop_TPagar { get; set; }

        // Filas
        public double Prop_ISI { get; set; }
        public double Prop_ITBISTASA { get; set; }
        public double Prop_ITBIS { get; set; }
        public double Prop_Total { get; set; }

        #endregion

        #region Property with fields

        //private double _Prop_ITBIS;
        //private double _Prop_Total;
        
        /// <summary>
        ///  Calculos totales fila
        /// </summary>
        /// 
        private void calculo_fila() {
            // Impuesto sin importe
            this.Prop_ISI = Prop_Cant * double.Parse(Prop_PriceProducts1);
            // Impuesto
            this.Prop_ITBIS = Prop_ISI * Prop_ITBISTASA;
            // Total de impuesto sin importe + impuesto
          //  if (Prop_ITBIS != 0)
            this.Prop_Total = Prop_ISI + Prop_ITBIS;
            // Total de Exento
           
        }

        #endregion

        #region Eventos
        private void BtnTab_Click(object sender, EventArgs e)
        {
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                Prop_idProducts = Frm.idProduct;
                this.TxtCod.Text = Prop_idProducts;
                buscarProd(TxtCod.Text);
                this.TxtDescrip.Text = Prop_NameProducts;
                this.TxtPrecio.Text = Prop_PriceProducts1;
            }
           
        }
        private void TxtCod_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            Prop_Cant = int.Parse(TxtCantidad.Text);
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtCod.Text != "" && TxtCantidad.Text != "")
            {
                this.calculo_fila();
                //DataGridView row = (DataGridView)DGVFact.Rows[0].Clone();
                // this.DGVFact.Rows.Add("one", "two", "three");

                // Creo una fila
                DataGridViewRow row = (DataGridViewRow)DGVFact.Rows[0].Clone();

                // Agrego la fila al DataGridView
                int rowIndex = DGVFact.Rows.Add(row);

                // Leo la Nueva Fila y la pongo en row
                row = this.DGVFact.Rows[rowIndex];

                row.Cells["Codigo"].Value = TxtCod.Text;
                row.Cells["Cant"].Value = Prop_Cant;
                row.Cells["UnidadMed"].Value = Prop_Unidad;
                row.Cells["Descripcion"].Value = Prop_NameProducts;
                row.Cells["Precio"].Value = Prop_PriceProducts1;
                row.Cells["Importe"].Value = this.Prop_ISI;
                row.Cells["Impuesto"].Value = this.Prop_ITBIS;
                row.Cells["Total"].Value = this.Prop_Total;


                Prop_TGravado = DGVFact.Rows.Cast<DataGridViewRow>()
                        .Where(r => Convert.ToDouble(r.Cells["Impuesto"].Value) > 0)
                        .Sum(t => Convert.ToDouble(t.Cells["Importe"].Value));

                Prop_TExento = DGVFact.Rows.Cast<DataGridViewRow>()
                        .Where(r => Convert.ToDouble(r.Cells["Impuesto"].Value) == 0)
                        .Sum(t => Convert.ToDouble(t.Cells["Importe"].Value));

                Prop_Titbis = DGVFact.Rows.Cast<DataGridViewRow>()
                       .Sum(t => Convert.ToDouble(t.Cells["Impuesto"].Value));

                Prop_TPagar = Prop_TGravado + Prop_TExento + Prop_Titbis;

                txtTotalGravado.Text = Prop_TGravado.ToString();
                txtTotalExento.Text = Prop_TExento.ToString();
                txtTotalItbis.Text = Prop_Titbis.ToString();
                txtTotalPagar.Text = Prop_TPagar.ToString();
            }
            else
            {
                MessageBox.Show("Especifique la Cantidad");
            }
        }
        private void TxtCod_Leave(object sender, EventArgs e)
        {
            buscarProd(TxtCod.Text);
            this.TxtDescrip.Text = Prop_NameProducts;
            this.TxtPrecio.Text = Prop_PriceProducts1;
        }

        #endregion

        #region Metodos
        public void buscarProd(String id)
          {
              try
              {
                  using (var context = new FacturacionEntities())
                  {
                      var orecord = context.Producto
                          .Where(b => b.CodigoProd == id)
                          .FirstOrDefault();

                      if (orecord != null)
                      {
                          this.Prop_NameProducts = orecord.NombreProd.ToString();
                          this.Prop_Unidad = orecord.UnidadProd.ToString();
                          this.Prop_PriceProducts1 = orecord.Precio1.ToString();
                          this.Prop_PriceProducts2 = orecord.Precio2.ToString();
                          this.Prop_PriceProducts3 = orecord.Precio3.ToString();
                          this.Prop_ITBISTASA = (double)orecord.Impuesto.Value;
                         
                          //this.TxtCodigo.Text = orecord.Codigo.ToString();
                          //this.Prop_idProducts = orecord.CodigoProd.ToString();
                          //this.CbCategoria.SelectedValue = orecord.CategoriaProd.ToString();
                          //this.TxtCantMin.Text = orecord.CantidadMin.ToString();
                          //this.TxtExistencia.Text = orecord.ExistenciaProd.ToString();
                          //this.TxtCosto.Text = orecord.CostoProd.ToString();
                          //this.TxtNota.Text = orecord.Nota.ToString();
                          //this.chkEstado.Checked = (orecord.EstadoProd == true) ? true : false;
                          //this.Encontrado = true;
                          //btnBorrar.Enabled = chkEstado.Checked == true;
                      }
                      else
                      {
                          // this.Encontrado = false;
                          MessageBox.Show("Id de Producto no existe.", "AVISO");
                          using (var Method = new Formularios.FrmMantenimiento())
                          {
                              Method.CleanControls(groupBox1);
                          }
                      }
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          }
        
        #endregion

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            FrmPago Frm = new FrmPago();
            Frm.ShowDialog();
        }



    }
}
