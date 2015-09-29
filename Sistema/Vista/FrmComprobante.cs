using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using Sistema.Data;namespace Sistema.Vista
{
    public partial class FrmComprobante : Form
    {
        public FrmComprobante()
        {
            InitializeComponent();
        }

        private void FrmComprobante_Load(object sender, EventArgs e)
        {
            CargarGrid();
            
        }

        protected void CargarGrid() 
        {
            var context = new FacturacionEntities();
            BindingSource Bs = new BindingSource();
            Bs.DataSource = context.comprobanteTipo.ToList();
            DGVComprobantes.DataSource = Bs;
            DGVComprobantes.Columns[6].Visible = false;
            DGVComprobantes.Columns[0].ReadOnly = true;
            DGVComprobantes.Columns[1].ReadOnly = true;
            DGVComprobantes.Columns[5].ReadOnly = true;
            
            DataGridViewImageColumn delbut = new DataGridViewImageColumn();
            delbut.Image = Image.FromFile(Environment.CurrentDirectory + "/images/icoSave.gif");
            delbut.Width = 20;
            delbut.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGVComprobantes.Columns.Add(delbut);
        }

        #region DataGridView


        private void UpdateComprobante(string id, string pre, int sec, int lim)
        {
            using (var context = new FacturacionEntities())
            {
                var Comp = from b in context.comprobanteTipo
                           where b.idNCF == id
                           select b;
                foreach (var Comprobante in Comp)
                {
                    Comprobante.prefijo = pre;
                    Comprobante.secuencia = sec;
                    Comprobante.limite = lim;
                }
                context.SaveChanges();
            }

        }
        private void DGVComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DialogResult Result = MessageBox.Show("Esta Seguro que Quieres Modificar el Registro?", "Confirmacion", MessageBoxButtons.OKCancel);
                if (Result == DialogResult.OK)
                {
                    try
                    {
                        string id = DGVComprobantes.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string pre = DGVComprobantes.Rows[e.RowIndex].Cells[3].Value.ToString();
                        int sec = int.Parse(DGVComprobantes.Rows[e.RowIndex].Cells[4].Value.ToString());
                        int lim = int.Parse(DGVComprobantes.Rows[e.RowIndex].Cells[5].Value.ToString());
                        UpdateComprobante(id, pre, sec, lim);
                        MessageBox.Show("Registro Modificado");
                        DGVComprobantes.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to save the record. There might be a blank cell. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void DGVComprobantes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGVComprobantes.CurrentCell.ColumnIndex == 4 || DGVComprobantes.CurrentCell.ColumnIndex == 5)
            {
                e.Control.KeyPress += new KeyPressEventHandler(DGVComprobantes_KeyPress);
            }

        }
        private void DGVComprobantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }


        #endregion

        private void DGVComprobantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

    }
}
