namespace Presentacion.Core.Mesa.Control
{
    partial class MesaControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNumeroMesa = new System.Windows.Forms.Label();
            this.MenuControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAbrirMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCerrarMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.MenuControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumeroMesa
            // 
            this.lblNumeroMesa.ContextMenuStrip = this.MenuControl;
            this.lblNumeroMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumeroMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroMesa.Location = new System.Drawing.Point(0, 0);
            this.lblNumeroMesa.Name = "lblNumeroMesa";
            this.lblNumeroMesa.Size = new System.Drawing.Size(100, 67);
            this.lblNumeroMesa.TabIndex = 0;
            this.lblNumeroMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumeroMesa.DoubleClick += new System.EventHandler(this.LblNumeroMesa_DoubleClick);
            // 
            // MenuControl
            // 
            this.MenuControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbrirMesa,
            this.MenuCerrarMesa});
            this.MenuControl.Name = "MenuControl";
            this.MenuControl.Size = new System.Drawing.Size(181, 70);
            // 
            // MenuAbrirMesa
            // 
            this.MenuAbrirMesa.Name = "MenuAbrirMesa";
            this.MenuAbrirMesa.Size = new System.Drawing.Size(180, 22);
            this.MenuAbrirMesa.Text = "Abrir Mesa";
            this.MenuAbrirMesa.Click += new System.EventHandler(this.MenuAbrirMesa_Click);
            // 
            // MenuCerrarMesa
            // 
            this.MenuCerrarMesa.Name = "MenuCerrarMesa";
            this.MenuCerrarMesa.Size = new System.Drawing.Size(180, 22);
            this.MenuCerrarMesa.Text = "Cerrar Mesa";
            this.MenuCerrarMesa.Click += new System.EventHandler(this.MenuCerrarMesa_Click_1);
            // 
            // lblPrecio
            // 
            this.lblPrecio.ContextMenuStrip = this.MenuControl;
            this.lblPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(0, 67);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(100, 33);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNumeroMesa);
            this.Name = "ControlMesa";
            this.Size = new System.Drawing.Size(100, 100);
            this.MenuControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroMesa;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ContextMenuStrip MenuControl;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrirMesa;
        private System.Windows.Forms.ToolStripMenuItem MenuCerrarMesa;
    }
}
