namespace Sistema.Vista
{
    partial class FrmComprobante
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
            this.DGVComprobantes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVComprobantes)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVComprobantes
            // 
            this.DGVComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVComprobantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVComprobantes.Location = new System.Drawing.Point(12, 12);
            this.DGVComprobantes.Name = "DGVComprobantes";
            this.DGVComprobantes.Size = new System.Drawing.Size(621, 275);
            this.DGVComprobantes.TabIndex = 3;
            this.DGVComprobantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVComprobantes_CellClick);
            this.DGVComprobantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVComprobantes_CellContentClick);
            this.DGVComprobantes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVComprobantes_EditingControlShowing);
            // 
            // FrmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 354);
            this.Controls.Add(this.DGVComprobantes);
            this.Name = "FrmComprobante";
            this.Text = "Comprobantes Fiscales (DGII)";
            this.Load += new System.EventHandler(this.FrmComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVComprobantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVComprobantes;
    }
}