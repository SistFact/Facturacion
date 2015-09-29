using Sistema.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema.Vista
{
    public partial class FrmProducto : Formularios.FrmMantenimiento
    {
        Consulta.FrmConsultaProd Frm = new Consulta.FrmConsultaProd();
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarComboCat();
            this.CbCategoria.SelectedValue = 1;
        }
        private void BtnTab_Click(object sender, EventArgs e)
        {
            if (Frm.ShowDialog() == DialogResult.OK)
            {
               TxtCodigoProd.Text = Frm.idProduct;
               buscarProd(Frm.idProduct);
            }
        }

            public string oldid = "";
        
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
                    context.ModificacionProd
                        (TxtCodigoProd.Text,
                        TxtNombre.Text,
                        decimal.Parse(TxtPrecio1.Text),
                        decimal.Parse(TxtPrecio2.Text),
                        decimal.Parse(TxtPrecio3.Text),
                        chkEstado.Checked,
                        int.Parse(TxtExistencia.Text),
                        (int) CbCategoria.SelectedValue,
                        TxtUnidad.Text,
                        int.Parse(TxtCantMin.Text),
                        decimal.Parse(TxtImpuesto.Text),
                        decimal.Parse(TxtCosto.Text),
                        TxtNota.Text);
                     context.SaveChanges();
                    MessageBox.Show("Registro Modificado Satisfactoriamente");
                    CleanControls(panel1);
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
                       var Prod = context.InsercionProd
                        (TxtCodigoProd.Text,
                        TxtNombre.Text,
                        decimal.Parse(TxtPrecio1.Text),
                        decimal.Parse(TxtPrecio2.Text),
                        decimal.Parse(TxtPrecio3.Text),
                        chkEstado.Checked,
                        int.Parse(TxtExistencia.Text),
                        (int) CbCategoria.SelectedValue,
                        TxtUnidad.Text,
                        int.Parse(TxtCantMin.Text),
                        decimal.Parse(TxtImpuesto.Text),
                        decimal.Parse(TxtCosto.Text),
                        TxtNota.Text);
                        context.SaveChanges();
                        this.TxtCodigo.Text = Prod.SingleOrDefault().Value.ToString();
                    MessageBox.Show("Registro Creado Satisfactoriamente");
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + e.StackTrace,"Error");
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
                    var orecord = context.Producto.Find(id);
                    if (orecord != null)
                    {
                        this.TxtCodigo.Text = orecord.Codigo.ToString();
                        this.TxtCodigoProd.Text = orecord.CodigoProd.ToString();
                        this.TxtNombre.Text = orecord.NombreProd.ToString();
                        this.CbCategoria.SelectedValue = orecord.CategoriaProd.ToString();
                        this.TxtUnidad.Text = orecord.UnidadProd.ToString();
                        this.TxtCantMin.Text = orecord.CantidadMin.ToString();
                        this.TxtExistencia.Text = orecord.ExistenciaProd.ToString();
                        this.TxtPrecio1.Text = orecord.Precio1.ToString();
                        this.TxtPrecio2.Text = orecord.Precio2.ToString();
                        this.TxtPrecio3.Text = orecord.Precio3.ToString();
                        this.TxtCosto.Text = orecord.CostoProd.ToString();
                        this.TxtImpuesto.Text = orecord.Impuesto.ToString();
                        this.TxtNota.Text = orecord.Nota.ToString();
                        this.chkEstado.Checked = (orecord.EstadoProd == true) ? true : false;
                        this.Encontrado = true;

                        btnBorrar.Enabled = chkEstado.Checked == true;
                    }
                    else
                    {
                        this.Encontrado = false;
                        MessageBox.Show("Id de Producto no existe.", "AVISO");
                        CleanControls(panel1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
                        this.TxtCodigo.Text = orecord.Codigo.ToString();
                        this.TxtCodigoProd.Text = orecord.CodigoProd;
                        this.TxtNombre.Text = orecord.NombreProd;
                        this.CbCategoria.SelectedValue = orecord.CodCategoria;
                        this.TxtUnidad.Text = orecord.UnidadProd;
                        this.TxtCantMin.Text = orecord.CantidadMin.ToString();
                        this.TxtExistencia.Text = orecord.ExistenciaProd.ToString();
                        this.TxtPrecio1.Text = orecord.Precio1.ToString();
                        this.TxtPrecio2.Text = orecord.Precio2.ToString();
                        this.TxtPrecio3.Text = orecord.Precio3.ToString();
                        this.TxtCosto.Text = orecord.CostoProd.ToString();
                        this.TxtImpuesto.Text = orecord.Impuesto.ToString();
                        this.TxtNota.Text = orecord.Nota;
                        this.chkEstado.Checked = (orecord.EstadoProd == true) ? true : false;
                        this.Encontrado = true;

                        btnBorrar.Enabled = chkEstado.Checked == true;
                    }
                    else
                    {
                        this.Encontrado = false;
                        MessageBox.Show("Id de Producto no existe.", "AVISO");
                        CleanControls(panel1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void CargarComboCat() 
        {
            var context = new FacturacionEntities();
            //var TFarmacos = from q in context.TiposFarmacos select q;
            var orecord =
                from q in context.CategoriaProd
                where q.Estado == true
                select q;

            CbCategoria.DataSource = orecord.ToList();
            CbCategoria.DisplayMember = "Descripcion";
            CbCategoria.ValueMember = "CodCategoria";        
        }
        #endregion

        #region Eventos
        private void TxtCodigo_Leave(object sender, EventArgs e)
        {
        }
        private void TxtCodigoProd_Leave(object sender, EventArgs e)
        {
            this.buscarProd(TxtCodigoProd.Text);
        }

        #endregion

    





    }
}
