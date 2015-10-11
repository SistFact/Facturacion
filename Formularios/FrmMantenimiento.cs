using System;
using System.Drawing;
using System.IO;
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

        #region Propiedades y variables

        private bool Empty = true;
        private bool Validado = false;
        private bool Bstatus = true;
        string curdir = Path.GetDirectoryName(Application.ExecutablePath);
        

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
                    btnNuevo_Guardar.Image = Formularios.Properties.Resources.Add;

                    //  btnNuevo_Guardar.Image = Image.FromFile(Path.Combine(curdir, @"\Resources\Add.png") );

                    // string filename = Path.Combine(dir, @"MyImage.jpg");
                    //    btnNuevo_Guardar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Add.png");
                    //  btnNuevo_Guardar.TextImageRelation = TextImageRelation.ImageBeforeText;

                    // btnEditar_Cancelar.Text = "&Editar";
                    TpMessage.SetToolTip(btnEditar_Cancelar, "Editar Registro");
                    btnEditar_Cancelar.Image = Formularios.Properties.Resources.Edit;
                    //   btnEditar_Cancelar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Edit.png");

                    btnEditar_Cancelar.Enabled = Encontrado;
                    btnBorrar.Enabled = Encontrado;
                    DisableControls(this);

                }
                else
                {
                    // btnNuevo_Guardar.Text = "&Guardar";
                    TpMessage.SetToolTip(btnNuevo_Guardar, "Guardar Registro");
                    btnNuevo_Guardar.Image = Formularios.Properties.Resources.Save;

                    //    btnNuevo_Guardar.Image = System.Drawing.Image.FromFile(@"C:\Users\YsabelDalaly\Source\Repos\SistemaDispensario\SistemaDispensario\Imagenes\Icons Crud\Save.png");
                    // btnEditar_Cancelar.Text = "&Cancelar";
                    TpMessage.SetToolTip(btnEditar_Cancelar, "Cancelar Registro");
                    btnEditar_Cancelar.Image = Formularios.Properties.Resources.cancel;
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

        #region Constructores y Loader

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

        #endregion

        #region Metodos y funciones 
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

        #region Validaciones
             
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

     
        // Solo Para TextBox
        public bool isControlEmpty(Control con)
        {
            if (con.Text == "")
                return Empty;
            else
                Empty = false;
            return Empty;
        }

        
        public bool isValidateRNC(Control con,String txt) 
        {
        string rnc = con.Text;
        string peso =  "79865432";
        int suma = 0;
        int division = 0;
        if (rnc.Length != 9){
            EpError.SetError(con,txt);
            return Validado;
        }
        else
        {
            for (int i = 0; i < 8; i++) {
                //para verificar si es un dígito o no
                if (Char.IsDigit(rnc[i]) != true){
                    EpError.SetError(con,txt);
                    return Validado;
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
                return Validado;            
        }    
            Validado = true;
        return Validado;
    }

        public bool isValidateRNC1(Control con)
        {
            if (con.Text.Length.Equals(9))
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
            else
            {
                bool state = true;

                //Declaración de variables a nivel de método o función.
                int verificador = 0;
                int digito = 0;
                int digitoVerificador = 0;
                int digitoImpar = 0;
                int sumaPar = 0;
                int sumaImpar = 0;
                int longitud = Convert.ToInt32(con.Text.Length);
                /*Control de errores en el código*/

                //verificamos que la longitud del parametro sea igual a 11
                if (longitud == 11)
                {
                    digitoVerificador = Convert.ToInt32(con.Text.Substring(10, 1));
                    //recorremos en un ciclo for cada dígito de la cédula
                    for (int i = 9; i >= 0; i--)
                    {
                        //si el digito no es par multiplicamos por 2
                        digito = Convert.ToInt32(con.Text.Substring(i, 1));
                        if ((i % 2) != 0)
                        {
                            digitoImpar = digito * 2;
                            //si el digito obtenido es mayor a 10, restamos 9
                            if (digitoImpar >= 10)
                            {
                                digitoImpar = digitoImpar - 9;
                            }
                            sumaImpar = sumaImpar + digitoImpar;
                        }
                        /*En los demás casos sumamos el dígito y lo aculamos 
                          en la variable */
                        else
                        {
                            sumaPar = sumaPar + digito;
                        }
                    }
                    /*Obtenemos el verificador restandole a 10 el modulo 10 
                   de la suma total de los dígitos*/
                    verificador = 10 - ((sumaPar + sumaImpar) % 10);
                    /*si el verificador es igual a 10 y el dígito verificador
                    es igual a cero o el verificador y el dígito verificador 
                    son iguales retorna verdadero*/
                    if ((((verificador == 10) && (digitoVerificador == 0))
                         || (verificador == digitoVerificador)) && (con.Text != "00000000000"))
                    {

                        EpError.SetError(con, "");

                    }
                    else
                    {
                        EpError.SetError(con, "Cedula Invalida,Entre los Datos Correctos");
                        state = false;
                    }
                }
                else
                {
                    if (longitud < 11)
                    {
                        EpError.SetError(con, "La cédula debe contener once(11) digitos");
                        state = false;
                    }
                }
                return state;
        }
    }

        #endregion

    }
}

