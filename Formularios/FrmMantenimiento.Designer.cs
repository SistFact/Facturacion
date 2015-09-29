namespace Formularios
{
    partial class FrmMantenimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenimiento));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnEditar_Cancelar = new System.Windows.Forms.Button();
            this.btnNuevo_Guardar = new System.Windows.Forms.Button();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.TpMessage = new System.Windows.Forms.ToolTip(this.components);
            this.EpError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EpError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(317, 249);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 56);
            this.btnSalir.TabIndex = 15;
            this.TpMessage.SetToolTip(this.btnSalir, "Salir de la Ventana");
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.Location = new System.Drawing.Point(172, 249);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 56);
            this.btnBorrar.TabIndex = 13;
            this.TpMessage.SetToolTip(this.btnBorrar, "Borrar Registro");
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnEditar_Cancelar
            // 
            this.btnEditar_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar_Cancelar.Location = new System.Drawing.Point(92, 249);
            this.btnEditar_Cancelar.Name = "btnEditar_Cancelar";
            this.btnEditar_Cancelar.Size = new System.Drawing.Size(75, 56);
            this.btnEditar_Cancelar.TabIndex = 12;
            this.btnEditar_Cancelar.UseVisualStyleBackColor = true;
            this.btnEditar_Cancelar.Click += new System.EventHandler(this.btnEditar_Cancelar_Click);
            // 
            // btnNuevo_Guardar
            // 
            this.btnNuevo_Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo_Guardar.Location = new System.Drawing.Point(12, 249);
            this.btnNuevo_Guardar.Name = "btnNuevo_Guardar";
            this.btnNuevo_Guardar.Size = new System.Drawing.Size(75, 56);
            this.btnNuevo_Guardar.TabIndex = 11;
            this.btnNuevo_Guardar.UseVisualStyleBackColor = true;
            this.btnNuevo_Guardar.Click += new System.EventHandler(this.btnNuevo_Guardar_Click);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(333, 12);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 16;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // EpError
            // 
            this.EpError.ContainerControl = this;
            // 
            // FrmMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 317);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnEditar_Cancelar);
            this.Controls.Add(this.btnNuevo_Guardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMantenimiento";
            this.Load += new System.EventHandler(this.FrmMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnSalir;
        protected System.Windows.Forms.Button btnBorrar;
        protected System.Windows.Forms.Button btnEditar_Cancelar;
        protected System.Windows.Forms.Button btnNuevo_Guardar;
        protected System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ToolTip TpMessage;
        private System.Windows.Forms.ErrorProvider EpError;



    }
}