namespace Presentacion.Core.Kiosko
{
    partial class _00049_Kiosko
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nudUnidades = new System.Windows.Forms.NumericUpDown();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labels = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsusarioLogueado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtClienteApellido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClienteDni = new System.Windows.Forms.TextBox();
            this.pnlFacturacion = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nudSubTotal = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmpleadoNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmpleadoLegajo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.nudPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.pnlCliente.SuspendLayout();
            this.pnlFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).BeginInit();
            this.pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioUnitario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 32);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(160, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(193, 32);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(413, 22);
            this.txtDescripcion.TabIndex = 1;
            // 
            // nudUnidades
            // 
            this.nudUnidades.Location = new System.Drawing.Point(764, 32);
            this.nudUnidades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudUnidades.Name = "nudUnidades";
            this.nudUnidades.Size = new System.Drawing.Size(108, 22);
            this.nudUnidades.TabIndex = 3;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(13, 63);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersWidth = 51;
            this.dgvGrilla.RowTemplate.Height = 24;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(1008, 318);
            this.dgvGrilla.TabIndex = 6;
            this.dgvGrilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGrilla_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Codigo / Cod. Barra";
            // 
            // labels
            // 
            this.labels.AutoSize = true;
            this.labels.BackColor = System.Drawing.Color.Transparent;
            this.labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labels.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labels.Location = new System.Drawing.Point(195, 11);
            this.labels.Name = "labels";
            this.labels.Size = new System.Drawing.Size(93, 17);
            this.labels.TabIndex = 8;
            this.labels.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(625, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Precio Unitario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(765, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Unidades";
            // 
            // txtUsusarioLogueado
            // 
            this.txtUsusarioLogueado.Location = new System.Drawing.Point(3, 25);
            this.txtUsusarioLogueado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsusarioLogueado.Name = "txtUsusarioLogueado";
            this.txtUsusarioLogueado.Size = new System.Drawing.Size(181, 22);
            this.txtUsusarioLogueado.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(17, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(225, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cliente";
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCliente.Location = new System.Drawing.Point(197, 22);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(65, 113);
            this.btnCliente.TabIndex = 15;
            this.btnCliente.Text = "Buscar Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.BackColor = System.Drawing.Color.White;
            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Location = new System.Drawing.Point(11, 22);
            this.cmbTipoComprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(129, 24);
            this.cmbTipoComprobante.TabIndex = 16;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.BackColor = System.Drawing.Color.White;
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(11, 69);
            this.cmbFormaPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(129, 24);
            this.cmbFormaPago.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(11, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tipo Comprobante";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(7, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Forma Pago";
            // 
            // pnlCliente
            // 
            this.pnlCliente.BackColor = System.Drawing.Color.Lavender;
            this.pnlCliente.Controls.Add(this.label10);
            this.pnlCliente.Controls.Add(this.txtClienteApellido);
            this.pnlCliente.Controls.Add(this.label9);
            this.pnlCliente.Controls.Add(this.txtClienteNombre);
            this.pnlCliente.Controls.Add(this.label8);
            this.pnlCliente.Controls.Add(this.btnCliente);
            this.pnlCliente.Controls.Add(this.txtClienteDni);
            this.pnlCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlCliente.Location = new System.Drawing.Point(225, 423);
            this.pnlCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(279, 149);
            this.pnlCliente.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(3, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Apellido";
            // 
            // txtClienteApellido
            // 
            this.txtClienteApellido.Location = new System.Drawing.Point(5, 113);
            this.txtClienteApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClienteApellido.Name = "txtClienteApellido";
            this.txtClienteApellido.Size = new System.Drawing.Size(169, 22);
            this.txtClienteApellido.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(3, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Nombre";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(5, 68);
            this.txtClienteNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(169, 22);
            this.txtClienteNombre.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "DNI";
            // 
            // txtClienteDni
            // 
            this.txtClienteDni.Location = new System.Drawing.Point(5, 23);
            this.txtClienteDni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClienteDni.Name = "txtClienteDni";
            this.txtClienteDni.Size = new System.Drawing.Size(169, 22);
            this.txtClienteDni.TabIndex = 22;
            this.txtClienteDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtClienteDni_KeyPress);
            // 
            // pnlFacturacion
            // 
            this.pnlFacturacion.BackColor = System.Drawing.Color.Lavender;
            this.pnlFacturacion.Controls.Add(this.label18);
            this.pnlFacturacion.Controls.Add(this.nudTotal);
            this.pnlFacturacion.Controls.Add(this.label17);
            this.pnlFacturacion.Controls.Add(this.nudDescuento);
            this.pnlFacturacion.Controls.Add(this.label16);
            this.pnlFacturacion.Controls.Add(this.nudSubTotal);
            this.pnlFacturacion.Controls.Add(this.label15);
            this.pnlFacturacion.Controls.Add(this.dtpFecha);
            this.pnlFacturacion.Controls.Add(this.label6);
            this.pnlFacturacion.Controls.Add(this.cmbTipoComprobante);
            this.pnlFacturacion.Controls.Add(this.cmbFormaPago);
            this.pnlFacturacion.Controls.Add(this.label7);
            this.pnlFacturacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlFacturacion.Location = new System.Drawing.Point(513, 423);
            this.pnlFacturacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFacturacion.Name = "pnlFacturacion";
            this.pnlFacturacion.Size = new System.Drawing.Size(404, 149);
            this.pnlFacturacion.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(192, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 17);
            this.label18.TabIndex = 29;
            this.label18.Text = "Total";
            // 
            // nudTotal
            // 
            this.nudTotal.Location = new System.Drawing.Point(275, 110);
            this.nudTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(120, 22);
            this.nudTotal.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(192, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 17);
            this.label17.TabIndex = 27;
            this.label17.Text = "Descuento";
            // 
            // nudDescuento
            // 
            this.nudDescuento.Location = new System.Drawing.Point(275, 64);
            this.nudDescuento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(120, 22);
            this.nudDescuento.TabIndex = 26;
            this.nudDescuento.Click += new System.EventHandler(this.NudDescuento_Click);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NudDescuento_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(192, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 17);
            this.label16.TabIndex = 25;
            this.label16.Text = "SubTotal";
            // 
            // nudSubTotal
            // 
            this.nudSubTotal.Location = new System.Drawing.Point(275, 23);
            this.nudSubTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSubTotal.Name = "nudSubTotal";
            this.nudSubTotal.Size = new System.Drawing.Size(120, 22);
            this.nudSubTotal.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(11, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 17);
            this.label15.TabIndex = 21;
            this.label15.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(11, 119);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(129, 22);
            this.dtpFecha.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(513, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 19);
            this.label11.TabIndex = 22;
            this.label11.Text = "Facturacion";
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.Lavender;
            this.pnlUsuario.Controls.Add(this.label14);
            this.pnlUsuario.Controls.Add(this.txtEmpleadoNombre);
            this.pnlUsuario.Controls.Add(this.label13);
            this.pnlUsuario.Controls.Add(this.txtEmpleadoLegajo);
            this.pnlUsuario.Controls.Add(this.label12);
            this.pnlUsuario.Controls.Add(this.txtUsusarioLogueado);
            this.pnlUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlUsuario.Location = new System.Drawing.Point(16, 423);
            this.pnlUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(200, 149);
            this.pnlUsuario.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(3, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 17);
            this.label14.TabIndex = 32;
            this.label14.Text = "Nombre";
            // 
            // txtEmpleadoNombre
            // 
            this.txtEmpleadoNombre.Location = new System.Drawing.Point(3, 114);
            this.txtEmpleadoNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmpleadoNombre.Name = "txtEmpleadoNombre";
            this.txtEmpleadoNombre.Size = new System.Drawing.Size(181, 22);
            this.txtEmpleadoNombre.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(3, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Legajo";
            // 
            // txtEmpleadoLegajo
            // 
            this.txtEmpleadoLegajo.Location = new System.Drawing.Point(3, 69);
            this.txtEmpleadoLegajo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmpleadoLegajo.Name = "txtEmpleadoLegajo";
            this.txtEmpleadoLegajo.Size = new System.Drawing.Size(181, 22);
            this.txtEmpleadoLegajo.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(3, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "Logueado";
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.Lavender;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCobrar.Location = new System.Drawing.Point(929, 423);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(99, 149);
            this.btnCobrar.TabIndex = 28;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            // 
            // nudPrecioUnitario
            // 
            this.nudPrecioUnitario.Location = new System.Drawing.Point(623, 32);
            this.nudPrecioUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudPrecioUnitario.Name = "nudPrecioUnitario";
            this.nudPrecioUnitario.Size = new System.Drawing.Size(133, 22);
            this.nudPrecioUnitario.TabIndex = 29;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLimpiar.Image = global::Presentacion.Core.Properties.Resources.escoba;
            this.btnLimpiar.Location = new System.Drawing.Point(888, 2);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(57, 57);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregar.Image = global::Presentacion.Core.Properties.Resources.shopping_cart;
            this.btnAgregar.Location = new System.Drawing.Point(961, 2);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(56, 57);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            this.btnAgregar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BtnAgregar_KeyPress);
            // 
            // _00049_Kiosko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1036, 592);
            this.Controls.Add(this.nudPrecioUnitario);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlFacturacion);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labels);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.nudUnidades);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "_00049_Kiosko";
            this.Text = "_00049_Kiosko";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.pnlFacturacion.ResumeLayout(false);
            this.pnlFacturacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).EndInit();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioUnitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown nudUnidades;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsusarioLogueado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtClienteApellido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClienteDni;
        private System.Windows.Forms.Panel pnlFacturacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmpleadoNombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmpleadoLegajo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudSubTotal;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.NumericUpDown nudPrecioUnitario;
    }
}