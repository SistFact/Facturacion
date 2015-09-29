using   System;
using System.Windows.Forms;

namespace Formularios
{

    /* Este una libreria de diferentes tipos de formulario con el objetivo de
       reutilizar el codigo, Ejemplo para todos los formularios los botones (Crud)
       hara el mismo efecto y tendra los mismo resultado.. entonces todos los cambios 
       o modalidad que se haga aqui afecta a los demas formulario solo si el formulario hereda
       de esta libreria.
     */
    public partial class FrmMantenimiento : Form
    {

        public FrmMantenimiento()
        {
            InitializeComponent();
            Encontrado = false;
            Modalidad = "VIEW";
        }
        private void FrmMantenimiento_Load(object sender, EventArgs e)
        {
            this.Modalidad = "VIEW";
        }

        #region Propiedades

        private string modalidad = "VIEW";
        public string Modalidad
        {
            get { return modalidad; }
            set
            {

                if (value == "VIEW")
                {
                    //btnNuevo_Guardar.Text = "&Nuevo";
                    TpMessage.SetToolTip(btnNuevo_Guardar, "Nuevo Registro");
                //    btnNuevo_Guardar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Add.png");

                    //  btnNuevo_Guardar.TextImageRelation = TextImageRelation.ImageBeforeText;
                    // btnEditar_Cancelar.Text = "&Editar";
                    TpMessage.SetToolTip(btnEditar_Cancelar, "Editar Registro");
                 //   btnEditar_Cancelar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Edit.png");

                    btnEditar_Cancelar.Enabled = Encontrado;
                    btnBorrar.Enabled = Encontrado;
                    DisableControls(this);

                }
                else
                {
                    // btnNuevo_Guardar.Text = "&Guardar";
                    TpMessage.SetToolTip(btnNuevo_Guardar, "Guardar Registro");
                //    btnNuevo_Guardar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Save.png");
                    // btnEditar_Cancelar.Text = "&Cancelar";
                    TpMessage.SetToolTip(btnEditar_Cancelar, "Cancelar Registro");
                 //   btnEditar_Cancelar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\cancel.png");
                    // btnNuevo_Guardar.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btnEditar_Cancelar.Enabled = true;
                    btnBorrar.Enabled = false;
                    EnableControls(this);
                }
                modalidad = value;
            }
        }
        private bool encontrado = false;
        public bool Encontrado
        {
            get { return encontrado; }
            set
            {
                btnBorrar.Enabled = value;
                if (Modalidad == "VIEW")
                {
                    btnEditar_Cancelar.Enabled = value;
                }
                encontrado = value;
            }
        }

        #endregion

        #region Metodos
        private void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableControls(c);
            }


            if (con is TextBox || con is ComboBox || con is MaskedTextBox || con is RadioButton)
            {
                con.Enabled = true;
            }

        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }


            if (con is TextBox || con is CheckBox || con is ComboBox || con is MaskedTextBox || con is RadioButton)
            {
                con.Enabled = false;
            }

        }
        public void CleanControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                CleanControls(c);
            }

            if (con is TextBox)
            {
                con.Text = "";
            }
        }

        #endregion

        #region Protected Virtual
        protected virtual void nuevo()
        {
        }
        protected virtual void guardar()
        {
            try
            {
                if (this.Modalidad == "NEW")
                {
                    Insertar();
                }
                else
                {
                    Actualizar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "AVISO");
            }
        }
        protected virtual void borrar()
        {
        }
        protected virtual void despuesdeguardar()
        {
        }
        protected virtual void editar()
        {
        }
        protected virtual void cancelar()
        {
        }
        protected virtual void despuesdecancelar()
        {
        }
        protected virtual void Insertar()
        {
        }
        protected virtual void Actualizar()
        {
        }
        #endregion

        #region Botones
        private void btnNuevo_Guardar_Click(object sender, EventArgs e)
        {
            if (this.Modalidad == "VIEW")
            {
                this.Modalidad = "NEW";
                this.nuevo();
            }
            else
            {
                if (Bstatus == true)
                {
                    this.guardar();
                    this.Modalidad = "VIEW";
                    this.despuesdeguardar();
                }
                else
                {
                    MessageBox.Show("Llene los datos necesarios");
                }
            }
        }
        private void btnEditar_Cancelar_Click(object sender, EventArgs e)
        {
            if (this.Modalidad == "VIEW")
            {
                this.Modalidad = "EDIT";
                this.editar();
            }
            else
            {
                this.Modalidad = "VIEW";
                this.cancelar();
                this.despuesdecancelar();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.Modalidad = "VIEW";
            this.borrar();
        }

        #endregion

        #region Validacion

        private bool Bstatus = true;
        public bool isValidateEmpty(Control Atxt, String Txt)
        {
            Bstatus = true;
            if (Atxt.Text == "")
            {
                EpError.SetError(Atxt, Txt);
                Bstatus = false;
            }
            else
            {
                EpError.SetError(Atxt, "");
                return Bstatus;
            }
            return Bstatus;
        }
        private bool Empty = true;
        // Solo Para TextBox
        public bool isControlEmpty(Control con)
        {
            if (con.Text == "")
                return Empty;
            else
                Empty = false;
            return Empty;
        }
        bool Validate = false;
        public bool isValidateRNC(Control con,String txt) 
        {
        string rnc = con.Text;
        string peso =  "79865432";
        int suma = 0;
        int division = 0;
        if (rnc.Length != 9){
            EpError.SetError(con,txt);
            return Validate;
        }
        else
        {
            for (int i = 0; i < 8; i++) {
                //para verificar si es un dígito o no
                if (Char.IsDigit(rnc[i]) != true){
                    EpError.SetError(con,txt);
                    return Validate;
                }
                suma = suma + ((int.Parse(rnc[i].ToString())) * (int.Parse(peso[i].ToString())));
            }
            division = suma / 11;
            int resto = suma - (division * 11);
            int digito = 0;
            
            if (resto == 0 )
                digito = 2;
            else if (resto == 1)
                digito = 1;
            else 
                digito = 11 - resto;
            
            if (digito != int.Parse(rnc[8].ToString()))
                return Validate;            
        }    
            Validate = true;
        return Validate;
    }

        public bool isValidateRNC1(Control con) 
        {
            bool state = true;
            char[] rnc = con.Text.ToCharArray();
            char[] peso = { '7', '9', '8', '6', '5', '4', '3', '2' };
            int suma = 0;
            int division = 0;
            if (rnc.Length != 9)
            {
                EpError.SetError(con, "Son 9 Digitos");
                state = false;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Char.IsDigit(rnc[i]) != true)
                    {
                        EpError.SetError(con, "Solo Digitos");
                        state = false;
                    }
                    suma = suma + ((int)Char.GetNumericValue(rnc[i]) * (int)Char.GetNumericValue(peso[i]));

                }
                division = suma / 11;
                int resto = suma - (division * 11);
                int digito = 0;

                if (resto == 0)
                    digito = 2;
                else if (resto == 1)
                    digito = 1;
                else
                    digito = 11 - resto;
                if (digito != (int)Char.GetNumericValue(rnc[8]))
                {
                    EpError.SetError(con, "No es Valido");
                    state = false;
                }
            }
            if (state != false)
                // Se implementa cuando todo es valido 
                // dejarlo sin ningun texto para que no presente el icono del error.
                EpError.SetError(con, "");
            return state;
        }

        #endregion

    }
}

