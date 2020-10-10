namespace Presentacion.Core.Precio
{
    partial class _00026_Precio_ABM
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
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaActualizacion = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraVenta = new System.Windows.Forms.DateTimePicker();
            this.cmbListaPrecio = new System.Windows.Forms.ComboBox();
            this.checkBActivarHoraVenta = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnListaPrecios = new System.Windows.Forms.Button();
            this.btnArticulos = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.Location = new System.Drawing.Point(160, 89);
            this.nudPrecioCosto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(200, 22);
            this.nudPrecioCosto.TabIndex = 4;
            // 
            // dtpFechaActualizacion
            // 
            this.dtpFechaActualizacion.Location = new System.Drawing.Point(160, 118);
            this.dtpFechaActualizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaActualizacion.Name = "dtpFechaActualizacion";
            this.dtpFechaActualizacion.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaActualizacion.TabIndex = 6;
            // 
            // dtpHoraVenta
            // 
            this.dtpHoraVenta.Enabled = false;
            this.dtpHoraVenta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraVenta.Location = new System.Drawing.Point(159, 241);
            this.dtpHoraVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpHoraVenta.Name = "dtpHoraVenta";
            this.dtpHoraVenta.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraVenta.TabIndex = 7;
            this.dtpHoraVenta.Value = new System.DateTime(2019, 12, 12, 19, 54, 0, 0);
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(160, 146);
            this.cmbListaPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(200, 24);
            this.cmbListaPrecio.TabIndex = 8;
            // 
            // checkBActivarHoraVenta
            // 
            this.checkBActivarHoraVenta.AutoSize = true;
            this.checkBActivarHoraVenta.Location = new System.Drawing.Point(159, 213);
            this.checkBActivarHoraVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBActivarHoraVenta.Name = "checkBActivarHoraVenta";
            this.checkBActivarHoraVenta.Size = new System.Drawing.Size(164, 21);
            this.checkBActivarHoraVenta.TabIndex = 10;
            this.checkBActivarHoraVenta.Text = "Activa Hora de Venta";
            this.checkBActivarHoraVenta.UseVisualStyleBackColor = true;
            this.checkBActivarHoraVenta.CheckedChanged += new System.EventHandler(this.CheckBActivarHoraVenta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Precio Costo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha Actualizacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Lista de Precios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Articulo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Hora Venta";
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Location = new System.Drawing.Point(367, 149);
            this.btnListaPrecios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.Size = new System.Drawing.Size(43, 23);
            this.btnListaPrecios.TabIndex = 17;
            this.btnListaPrecios.Text = "...";
            this.btnListaPrecios.UseVisualStyleBackColor = true;
            this.btnListaPrecios.Click += new System.EventHandler(this.BtnListaPrecios_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Location = new System.Drawing.Point(367, 181);
            this.btnArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(43, 23);
            this.btnArticulos.TabIndex = 18;
            this.btnArticulos.Text = "...";
            this.btnArticulos.UseVisualStyleBackColor = true;
            this.btnArticulos.Click += new System.EventHandler(this.BtnArticulos_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(368, 91);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 25);
            this.label24.TabIndex = 87;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(400, 250);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(158, 17);
            this.label25.TabIndex = 86;
            this.label25.Text = "Campos Obligatorios (*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(368, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 25);
            this.label7.TabIndex = 88;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(417, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 25);
            this.label8.TabIndex = 89;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(416, 175);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 25);
            this.label9.TabIndex = 90;
            this.label9.Text = "*";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(160, 180);
            this.txtArticulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.ReadOnly = true;
            this.txtArticulo.Size = new System.Drawing.Size(199, 22);
            this.txtArticulo.TabIndex = 91;
            // 
            // _00026_Precio_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 295);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btnArticulos);
            this.Controls.Add(this.btnListaPrecios);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBActivarHoraVenta);
            this.Controls.Add(this.cmbListaPrecio);
            this.Controls.Add(this.dtpHoraVenta);
            this.Controls.Add(this.dtpFechaActualizacion);
            this.Controls.Add(this.nudPrecioCosto);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "_00026_Precio_ABM";
            this.Text = "Precio (Alta, Baja, Modificacion)";
            this.Controls.SetChildIndex(this.nudPrecioCosto, 0);
            this.Controls.SetChildIndex(this.dtpFechaActualizacion, 0);
            this.Controls.SetChildIndex(this.dtpHoraVenta, 0);
            this.Controls.SetChildIndex(this.cmbListaPrecio, 0);
            this.Controls.SetChildIndex(this.checkBActivarHoraVenta, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.btnListaPrecios, 0);
            this.Controls.SetChildIndex(this.btnArticulos, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtArticulo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPrecioCosto;
        private System.Windows.Forms.DateTimePicker dtpFechaActualizacion;
        private System.Windows.Forms.DateTimePicker dtpHoraVenta;
        private System.Windows.Forms.ComboBox cmbListaPrecio;
        private System.Windows.Forms.CheckBox checkBActivarHoraVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnListaPrecios;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArticulo;
    }
}