using Sistema.Data;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sistema.Vista
{
    public partial class FrmCategoria : Formularios.FrmMantenimiento
    {

        public string oldid = "";
        public FrmCategoria()
        {
            InitializeComponent();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
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
                    bool chk = chkEstado.Checked = false;
                    context.EliminacionCat(int.Parse(TxtCodigo.Text),chk);
                    context.SaveChanges();
                }
            }   catch(Exception e)
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
                    context.ModificacionCat(int.Parse(TxtCodigo.Text), TxtDescripcion.Text,chkEstado.Checked);
                    context.SaveChanges();
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
                
                    var cat = context.InsercionCat(TxtDescripcion.Text, chkEstado.Checked);
                    context.SaveChanges();
                    this.TxtCodigo.Text =  cat.SingleOrDefault().Value.ToString(); 
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message + " " + e.StackTrace);
            }
        }
        #endregion

    #region Metodos
        public void buscar(String strid)
        {
            // Completar este metodo
            try
            {
                using (var context = new FacturacionEntities())
                {
                    int id;
                    if (!int.TryParse(strid, out id)) return;
                    var orecord = context.CategoriaProd.Find(id);
                    if (orecord != null)
                    {
                        this.TxtCodigo.Text = orecord.CodCategoria.ToString();
                        this.TxtDescripcion.Text = orecord.Descripcion;
                        this.chkEstado.Checked = (orecord.Estado == true) ? true : false;
                        this.Encontrado = true;

                        btnBorrar.Enabled = chkEstado.Checked == true;
                    }
                    else
                    {
                        this.Encontrado = false;
                        MessageBox.Show("Id de Categoria no existe.", "AVISO");
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
        private void TxtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            base.isValidateEmpty(TxtDescripcion, "Introduce los datos");
        }   


        #endregion
    
    }
}
