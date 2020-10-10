namespace Presentacion.Core.Caja
{
    partial class _0045_CerrarCaja
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.nudCierre = new System.Windows.Forms.NumericUpDown();
            this.nudDiferencia = new System.Windows.Forms.NumericUpDown();
            this.nudSistema = new System.Windows.Forms.NumericUpDown();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMontoCierre = new System.Windows.Forms.Label();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCierre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSistema)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(16, 12);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 16);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario: ";
            // 
            // nudCierre
            // 
            this.nudCierre.Location = new System.Drawing.Point(122, 46);
            this.nudCierre.Name = "nudCierre";
            this.nudCierre.Size = new System.Drawing.Size(120, 20);
            this.nudCierre.TabIndex = 1;
            this.nudCierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NudCierre_KeyPress);
            // 
            // nudDiferencia
            // 
            this.nudDiferencia.Location = new System.Drawing.Point(122, 98);
            this.nudDiferencia.Name = "nudDiferencia";
            this.nudDiferencia.Size = new System.Drawing.Size(120, 20);
            this.nudDiferencia.TabIndex = 2;
            // 
            // nudSistema
            // 
            this.nudSistema.Location = new System.Drawing.Point(122, 72);
            this.nudSistema.Name = "nudSistema";
            this.nudSistema.Size = new System.Drawing.Size(120, 20);
            this.nudSistema.TabIndex = 3;
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCierre.Location = new System.Drawing.Point(16, 11);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(52, 16);
            this.lblFechaCierre.TabIndex = 4;
            this.lblFechaCierre.Text = "Fecha: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Diferencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monto Sistema";
            // 
            // lblMontoCierre
            // 
            this.lblMontoCierre.AutoSize = true;
            this.lblMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoCierre.Location = new System.Drawing.Point(12, 50);
            this.lblMontoCierre.Name = "lblMontoCierre";
            this.lblMontoCierre.Size = new System.Drawing.Size(84, 16);
            this.lblMontoCierre.TabIndex = 7;
            this.lblMontoCierre.Text = "Monto Cierre";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.Lavender;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.Location = new System.Drawing.Point(33, 129);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(193, 47);
            this.btnCerrarCaja.TabIndex = 8;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.BtnCerrarCaja_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(-4, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 3);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblFechaCierre);
            this.panel2.Location = new System.Drawing.Point(-4, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 41);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblUsuario);
            this.panel4.Location = new System.Drawing.Point(-4, -3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(261, 40);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Location = new System.Drawing.Point(-1, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 3);
            this.panel3.TabIndex = 11;
            // 
            // _0045_CerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(253, 225);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.lblMontoCierre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSistema);
            this.Controls.Add(this.nudDiferencia);
            this.Controls.Add(this.nudCierre);
            this.Name = "_0045_CerrarCaja";
            this.Text = "Cierre de Caja";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCierre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSistema)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.NumericUpDown nudCierre;
        private System.Windows.Forms.NumericUpDown nudDiferencia;
        private System.Windows.Forms.NumericUpDown nudSistema;
        private System.Windows.Forms.Label lblFechaCierre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMontoCierre;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}