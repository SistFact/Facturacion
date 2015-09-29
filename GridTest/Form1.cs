using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comprobanteTipoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.comprobanteTipoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.facturacionDataSet);

        }

        private void comprobanteTipoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.comprobanteTipoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.facturacionDataSet);

        }

        private void comprobanteTipoBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.comprobanteTipoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.facturacionDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facturacionDataSet.comprobanteTipo' table. You can move, or remove it, as needed.
            this.comprobanteTipoTableAdapter.Fill(this.facturacionDataSet.comprobanteTipo);

        }
    }
}
