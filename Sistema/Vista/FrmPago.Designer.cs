namespace Sistema.Vista
{
    partial class FrmPago
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
            this.TxtEfectivo = new System.Windows.Forms.TextBox();
            this.BtnCobrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtDevuelta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtClienteid = new System.Windows.Forms.TextBox();
            this.TxtNoCheque = new System.Windows.Forms.TextBox();
            this.TxtNoTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTarjeta = new System.Windows.Forms.TextBox();
            this.TxtCredito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCheque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtEfectivo
            // 
            this.TxtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEfectivo.Location = new System.Drawing.Point(148, 70);
            this.TxtEfectivo.Name = "TxtEfectivo";
            this.TxtEfectivo.Size = new System.Drawing.Size(208, 38);
            this.TxtEfectivo.TabIndex = 0;
            this.TxtEfectivo.TextChanged += new System.EventHandler(this.Calcular);
            // 
            // BtnCobrar
            // 
            this.BtnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCobrar.Location = new System.Drawing.Point(429, 286);
            this.BtnCobrar.Name = "BtnCobrar";
            this.BtnCobrar.Size = new System.Drawing.Size(125, 51);
            this.BtnCobrar.TabIndex = 0;
            this.BtnCobrar.Text = "Cobrar";
            this.BtnCobrar.UseVisualStyleBackColor = true;
            this.BtnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(560, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 51);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnCancelar);
            // 
            // TxtDevuelta
            // 
            this.TxtDevuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDevuelta.Location = new System.Drawing.Point(246, 299);
            this.TxtDevuelta.Name = "TxtDevuelta";
            this.TxtDevuelta.Size = new System.Drawing.Size(162, 38);
            this.TxtDevuelta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Devuelta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor a Pagar :";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(224, 16);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(67, 31);
            this.LblTotal.TabIndex = 5;
            this.LblTotal.Text = "0.00";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TxtClienteid);
            this.panel1.Controls.Add(this.TxtNoCheque);
            this.panel1.Controls.Add(this.TxtNoTarjeta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtTarjeta);
            this.panel1.Controls.Add(this.TxtCredito);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtCheque);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtEfectivo);
            this.panel1.Controls.Add(this.LblTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(21, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 266);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(482, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TxtClienteid
            // 
            this.TxtClienteid.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClienteid.Location = new System.Drawing.Point(362, 197);
            this.TxtClienteid.Name = "TxtClienteid";
            this.TxtClienteid.Size = new System.Drawing.Size(114, 38);
            this.TxtClienteid.TabIndex = 16;
            // 
            // TxtNoCheque
            // 
            this.TxtNoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNoCheque.Location = new System.Drawing.Point(362, 155);
            this.TxtNoCheque.Name = "TxtNoCheque";
            this.TxtNoCheque.Size = new System.Drawing.Size(282, 38);
            this.TxtNoCheque.TabIndex = 15;
            // 
            // TxtNoTarjeta
            // 
            this.TxtNoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNoTarjeta.Location = new System.Drawing.Point(362, 114);
            this.TxtNoTarjeta.Name = "TxtNoTarjeta";
            this.TxtNoTarjeta.Size = new System.Drawing.Size(282, 38);
            this.TxtNoTarjeta.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tarjeta";
            // 
            // TxtTarjeta
            // 
            this.TxtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTarjeta.Location = new System.Drawing.Point(148, 114);
            this.TxtTarjeta.Name = "TxtTarjeta";
            this.TxtTarjeta.Size = new System.Drawing.Size(208, 38);
            this.TxtTarjeta.TabIndex = 12;
            this.TxtTarjeta.TextChanged += new System.EventHandler(this.Calcular);
            // 
            // TxtCredito
            // 
            this.TxtCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCredito.Location = new System.Drawing.Point(148, 197);
            this.TxtCredito.Name = "TxtCredito";
            this.TxtCredito.Size = new System.Drawing.Size(208, 38);
            this.TxtCredito.TabIndex = 11;
            this.TxtCredito.TextChanged += new System.EventHandler(this.Calcular);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "Credito";
            // 
            // TxtCheque
            // 
            this.TxtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCheque.Location = new System.Drawing.Point(148, 155);
            this.TxtCheque.Name = "TxtCheque";
            this.TxtCheque.Size = new System.Drawing.Size(208, 38);
            this.TxtCheque.TabIndex = 9;
            this.TxtCheque.TextChanged += new System.EventHandler(this.Calcular);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cheque";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 31);
            this.label5.TabIndex = 7;
            this.label5.Text = "Efectivo";
            // 
            // FrmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 353);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDevuelta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnCobrar);
            this.Name = "FrmPago";
            this.Text = "FrmPago";
            this.Load += new System.EventHandler(this.FrmPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtEfectivo;
        private System.Windows.Forms.Button BtnCobrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtDevuelta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtClienteid;
        private System.Windows.Forms.TextBox TxtNoCheque;
        private System.Windows.Forms.TextBox TxtNoTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTarjeta;
        private System.Windows.Forms.TextBox TxtCredito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCheque;
        private System.Windows.Forms.Label label6;
    }
}