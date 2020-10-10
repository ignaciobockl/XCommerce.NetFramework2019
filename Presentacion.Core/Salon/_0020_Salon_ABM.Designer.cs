namespace Presentacion.Core.Salon
{
    partial class _0020_Salon_ABM
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
            this.btnListaPrecios = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbListaPrecioSalon = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Location = new System.Drawing.Point(379, 126);
            this.btnListaPrecios.Margin = new System.Windows.Forms.Padding(2);
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.Size = new System.Drawing.Size(40, 20);
            this.btnListaPrecios.TabIndex = 93;
            this.btnListaPrecios.Text = "...";
            this.btnListaPrecios.UseVisualStyleBackColor = true;
            this.btnListaPrecios.Click += new System.EventHandler(this.BtnListaPrecios_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Lista de Precios";
            // 
            // cmbListaPrecioSalon
            // 
            this.cmbListaPrecioSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecioSalon.FormattingEnabled = true;
            this.cmbListaPrecioSalon.Location = new System.Drawing.Point(104, 126);
            this.cmbListaPrecioSalon.Name = "cmbListaPrecioSalon";
            this.cmbListaPrecioSalon.Size = new System.Drawing.Size(270, 21);
            this.cmbListaPrecioSalon.TabIndex = 91;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(357, 66);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(116, 13);
            this.label25.TabIndex = 90;
            this.label25.Text = "Campos Obligatorios (*)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(426, 173);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 20);
            this.label24.TabIndex = 89;
            this.label24.Text = "*";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(104, 173);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(316, 20);
            this.txtDescripcion.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Descripcion";
            // 
            // _0020_Salon_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 237);
            this.Controls.Add(this.btnListaPrecios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbListaPrecioSalon);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(492, 276);
            this.MinimumSize = new System.Drawing.Size(492, 276);
            this.Name = "_0020_Salon_ABM";
            this.Text = "Salon (Alta, Baja y Modificacion)";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.cmbListaPrecioSalon, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnListaPrecios, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListaPrecios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbListaPrecioSalon;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
    }
}