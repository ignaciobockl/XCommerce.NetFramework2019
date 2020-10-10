namespace Presentacion.Core.Cliente
{
    partial class _00046_PagarCuentaCorriente
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudDeudaFinal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDeuda = new System.Windows.Forms.NumericUpDown();
            this.nudSaldo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.linkCliente = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeudaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Deuda Final";
            // 
            // nudDeudaFinal
            // 
            this.nudDeudaFinal.Enabled = false;
            this.nudDeudaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDeudaFinal.Location = new System.Drawing.Point(171, 130);
            this.nudDeudaFinal.Name = "nudDeudaFinal";
            this.nudDeudaFinal.Size = new System.Drawing.Size(74, 22);
            this.nudDeudaFinal.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Saldo Abonado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Deuda";
            // 
            // nudDeuda
            // 
            this.nudDeuda.Enabled = false;
            this.nudDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDeuda.Location = new System.Drawing.Point(292, 25);
            this.nudDeuda.Name = "nudDeuda";
            this.nudDeuda.Size = new System.Drawing.Size(74, 22);
            this.nudDeuda.TabIndex = 19;
            // 
            // nudSaldo
            // 
            this.nudSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSaldo.Location = new System.Drawing.Point(292, 54);
            this.nudSaldo.Name = "nudSaldo";
            this.nudSaldo.Size = new System.Drawing.Size(74, 22);
            this.nudSaldo.TabIndex = 18;
            this.nudSaldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NudSaldo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cliente";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(10, 10);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(28, 16);
            this.lblDni.TabIndex = 16;
            this.lblDni.Text = "Dni";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(10, 77);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(140, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(10, 29);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(140, 20);
            this.txtDni.TabIndex = 14;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDni_KeyPress);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(292, 89);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(74, 31);
            this.btnPagar.TabIndex = 13;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // linkCliente
            // 
            this.linkCliente.AutoSize = true;
            this.linkCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCliente.Location = new System.Drawing.Point(7, 98);
            this.linkCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkCliente.Name = "linkCliente";
            this.linkCliente.Size = new System.Drawing.Size(243, 15);
            this.linkCliente.TabIndex = 24;
            this.linkCliente.TabStop = true;
            this.linkCliente.Text = "(Si el cliente no sabe su dni presionar aqui)";
            this.linkCliente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCliente_LinkClicked);
            // 
            // _00046_PagarCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 172);
            this.Controls.Add(this.linkCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudDeudaFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDeuda);
            this.Controls.Add(this.nudSaldo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnPagar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "_00046_PagarCuentaCorriente";
            this.Text = "Pagar Cuenta Corriente";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeudaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDeudaFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDeuda;
        private System.Windows.Forms.NumericUpDown nudSaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.LinkLabel linkCliente;
    }
}