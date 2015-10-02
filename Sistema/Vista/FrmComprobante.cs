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
            btnAceptar.Enabled = false;
        }
        protected void CargarGrid()
        {
            var context = new FacturacionEntities();
            BindingSource Bs = new BindingSource();
            Bs.DataSource = context.comprobanteTipo.ToList();
            DGVComprobantes.DataSource = Bs;
            // Columna De Encabezado
            DGVComprobantes.Columns["inv_movencabezado"].Visible = false;
            DGVComprobantes.Columns["idNCF"].ReadOnly = true;
            DGVComprobantes.Columns["Descripcion"].ReadOnly = true;
            DGVComprobantes.Columns["factura"].ReadOnly = true;
            DGVComprobantes.Columns["Cambio"].Visible = false;
            
            // La Columna 6 es Cambio.
            /*
            DataGridViewTextBoxColumn CbCol = new DataGridViewTextBoxColumn();
            CbCol.Name = "Cambio";
            CbCol.HeaderText = "Cambio";
            DGVComprobantes.Columns.Add(CbCol);
            DGVComprobantes.Refresh();
            */
            /*
            foreach (DataGridViewRow row in DGVComprobantes.Rows)
            {
                DGVComprobantes["Cambio", row.Index].Value = 0;
            }
            */
            /*
            DataGridViewImageColumn delbut = new DataGridViewImageColumn();
            delbut.Image = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\icoSave.gif");
            delbut.Width = 20;
            delbut.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            */
        }
    
        #region DataGridView

        private void UpdateComprobante(string id, string pre, int sec, int lim)
        {
            using (var context = new FacturacionEntities())
            {
                var oRecord = context.comprobanteTipo.SingleOrDefault
                       (t => t.idNCF == id);

                oRecord.prefijo = pre;
                oRecord.secuencia = sec;
                oRecord.limite = lim;
                /*
                var Comp = from b in context.comprobanteTipo
                           where b.idNCF == id
                           select b;
                foreach (var Comprobante in Comp)
                {
                    Comprobante.prefijo = pre;
                    Comprobante.secuencia = sec;
                    Comprobante.limite = lim;
                }
                */
                context.SaveChanges();
            }

        }
        private void DGVComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
 
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Hacer un proceso que recorra el grid completo y que 
            // Mande a actualizar a la base de datos cada una de las filas
            // donde se hicieron cambios.

            int i = 0;
            foreach (DataGridViewRow row in DGVComprobantes.Rows)
            {
                    if (row.IsNewRow)
                        break;

                if ((bool)row.Cells["Cambio"].Value != false)
                {
                    try

                    {
                        string id = row.Cells["idNCF"].Value.ToString().Trim();
                        string pre = row.Cells["prefijo"].Value.ToString().Trim();
                        int sec = int.Parse(row.Cells["secuencia"].Value.ToString());
                        int lim = int.Parse(row.Cells["limite"].Value.ToString());
                        UpdateComprobante(id, pre, sec, lim);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(">" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }     
                } 
            }
            MessageBox.Show("Se a realizado " + i + " Cambio");
            i = 0;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //DGVComprobantes.Refresh();
            CargarGrid();
            if(btnAceptar.Enabled !=true)
            btnAceptar.Enabled = false;
            // Recargar todo el grid de nuevo sin guardar los cambios.
        }
        private void DGVComprobantes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                DGVComprobantes[6,e.RowIndex].Value = true;
            if(btnAceptar.Enabled != true)
                btnAceptar.Enabled = true;
                /*
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
                        MessageBox.Show("Unable to save the record. There might be a blank cell. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                */
            
           
        }
    }
}