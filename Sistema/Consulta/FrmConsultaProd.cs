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

namespace Sistema.Consulta
{
    public partial class FrmConsultaProd : Form
    {
        #region Propiedades
        public string idProduct { get; set; }

        #endregion

        public FrmConsultaProd()
        {
            InitializeComponent();
            CbAtributte.SelectedIndex = 0;

        }
        private void FrmConsultaProd_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        #region Metodos
        protected void CargarGrid()
        {
            BindingSource Bs = new BindingSource();
            var context = new FacturacionEntities();
            Bs.DataSource = context.ViewProduct.ToList();
            DGVProducts.DataSource = Bs;
            DGVProducts.Columns["CodigoProd"].HeaderText = "Codigo";
            DGVProducts.Columns["Precio1"].DefaultCellStyle.Format = "0.00#";
            DGVProducts.Columns["Precio2"].DefaultCellStyle.Format = "0.00#";
            DGVProducts.Columns["Precio3"].DefaultCellStyle.Format = "0.00#";
        }
        protected void busqueda(string filtro)
        {
            if (filtro != null)
            {
                var context = new FacturacionEntities();
                BindingSource Bs = new BindingSource();

                switch (CbAtributte.SelectedIndex)
                {

                    case 0:

                        Bs.DataSource =
                            context.ViewProduct.Where(q => q.CodigoProd == filtro).ToList();

                        break;
                    case 1:

                        Bs.DataSource =
                           context.ViewProduct.Where(q => q.NombreProd.StartsWith(filtro)).ToList();
                        break;
                }
                DGVProducts.DataSource = Bs;
                DGVProducts.Refresh();
            }
            else
                CargarGrid();

        }

        #endregion

        #region Eventos
        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            busqueda(TxtFiltro.Text);
        }
        private void DGVProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProduct = DGVProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            //MessageBox.Show(idProduct);
        }
        #endregion
        

    }
}
