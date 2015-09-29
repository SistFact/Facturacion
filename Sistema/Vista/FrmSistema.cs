using Sistema.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class FrmSistema : Form
    {
        public FrmSistema()
        {
            InitializeComponent();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FrmCategoria = new FrmCategoria();
            FrmCategoria.MdiParent = this;
            FrmCategoria.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new FrmCliente();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new FrmProducto();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new FrmComprobante();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Frm = new FrmFactura();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void FrmSistema_Load(object sender, EventArgs e)
        {

        }
    }
}
