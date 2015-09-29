using Sistema.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Sistema.Vista
{
    public partial class FrmCliente : Formularios.FrmMantenimiento
    {
        public string oldid = "";
        public FrmCliente()
        {
            InitializeComponent();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            TxtCodigo.Enabled = true;
        }

        #region Overrride
        protected override void despuesdeguardar()
        {
            this.TxtCodigo.Enabled = true;
        }
        protected override void despuesdecancelar()
        {
            this.TxtCodigo.Enabled = true;
            int id;
            if (int.TryParse(oldid, out id))
            {
                // buscar(oldid);
            }
            else
            {
                oldid = "";
                this.TxtCodigo.Text = "";
            }
        }
        protected override void nuevo()
        {
            oldid = TxtCodigo.Text;
            CleanControls(panel1);
            TxtCodigo.Enabled = false;
            TxtCodigo.Text = "NUEVO";
        }
        protected override void editar()
        {
            // base.isControlEmpty(TxtCodigo);
            chkEstado.Enabled = true;
        }
        protected override void borrar()
        {
            try
            {
                using (var context = new FacturacionEntities())
                {

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        protected override void Actualizar()
        {
            try
            {
                using (var context = new FacturacionEntities())
                {
                    context.ModificacionCliente
                        (int.Parse(TxtCodigo.Text),
                        TxtNombre.Text,
                        MTxtRNC.Text,
                        TxtDireccion.Text,
                        MTxtTelefono.Text,
                        MTxtTelefonoMov.Text,
                        TxtEmail.Text,
                        TxtContacto.Text,
                        chkEstado.Checked,
                        int.Parse(TxtPrecio.Text));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        protected override void Insertar()
        {
            try
            {
                using (var context = new FacturacionEntities())
                {
                    var cli = context.InsercionCliente(
                        TxtNombre.Text,
                        MTxtRNC.Text,
                        TxtDireccion.Text,
                        MTxtTelefono.Text,
                        MTxtTelefonoMov.Text,
                        TxtEmail.Text,
                        TxtContacto.Text,
                        chkEstado.Checked,
                        int.Parse(TxtPrecio.Text));
                    context.SaveChanges();
                    this.TxtCodigo.Text = cli.SingleOrDefault().Value.ToString();
                    MessageBox.Show("Registro Creado Satisfactoriamente");
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region Metodos
        public void buscar(String strid)
        {
            try
            {
                using (var context = new FacturacionEntities())
                {
                    int id;
                    if (!int.TryParse(strid, out id)) return;
                    var orecord = context.Cliente.Find(id);
                    if (orecord != null)
                    {
                        this.TxtCodigo.Text = orecord.CodCliente.ToString();
                        this.TxtNombre.Text = orecord.NombreCliente.ToString();
                        this.TxtDireccion.Text = orecord.Direccion.ToString();
                        this.MTxtTelefono.Text = orecord.Telefono.ToString();
                        this.MTxtTelefonoMov.Text = orecord.TelMovil.ToString();
                        this.MTxtRNC.Text = orecord.RNC.ToString();
                        this.TxtContacto.Text = orecord.Contacto.ToString();
                        this.TxtEmail.Text = orecord.Email.ToString();
                        this.TxtPrecio.Text = orecord.TipoPrecio.ToString();
                        this.chkEstado.Checked = (orecord.EstadoCli == true) ? true : false;
                        this.Encontrado = true;

                        btnBorrar.Enabled = chkEstado.Checked == true;
                    }
                    else
                    {
                        this.Encontrado = false;
                        MessageBox.Show("Id de Cliente no existe.", "AVISO");
                        CleanControls(panel1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Eventos
        private void TxtCodigo_Leave(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(TxtCodigo.Text, out id))
            {
                buscar(TxtCodigo.Text);
            }
            else
            {
                this.TxtCodigo.Text = "";
            }
        }
        #endregion

        #region Validacion
        private void MTxtRNC_Validating(object sender, CancelEventArgs e)
        {
            if (base.isValidateRNC1(MTxtRNC) != true)
                this.btnNuevo_Guardar.Enabled = false;

            else
                this.btnNuevo_Guardar.Enabled = true;
            //e.Cancel = true;
        }

        #endregion








    }
}
