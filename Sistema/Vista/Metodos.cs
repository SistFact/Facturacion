using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Vista
{
    class Metodos
    {
        public Metodos() { }
        public void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableControls(c);
            }

            if (con is TextBox)
            {
                con.Enabled = true;
            }

        }

    }
}
