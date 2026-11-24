namespace EnvioCliente.view
{
    partial class GUIListarSeguimiento
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEnvioCodigo = new System.Windows.Forms.Label();
            this.txtEnvioCodigo = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnListarTodos = new System.Windows.Forms.Button();
            this.dgvSeguimientos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimientos)).BeginInit();
            this.SuspendLayout();
            this.lblEnvioCodigo.Location = new System.Drawing.Point(20, 23);
            this.lblEnvioCodigo.Name = "lblEnvioCodigo";
            this.lblEnvioCodigo.Size = new System.Drawing.Size(70, 20);
            this.lblEnvioCodigo.Text = "Cod. envio:";
            this.txtEnvioCodigo.Location = new System.Drawing.Point(95, 17);
            this.txtEnvioCodigo.Name = "txtEnvioCodigo";
            this.txtEnvioCodigo.Size = new System.Drawing.Size(130, 23);
            this.lblUbicacion.Location = new System.Drawing.Point(240, 23);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(80, 20);
            this.lblUbicacion.Text = "Ubicacion:";
            this.txtUbicacion.Location = new System.Drawing.Point(325, 17);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(190, 23);
            this.btnFiltrar.Location = new System.Drawing.Point(530, 15);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 25);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            this.btnListarTodos.Location = new System.Drawing.Point(630, 15);
            this.btnListarTodos.Name = "btnListarTodos";
            this.btnListarTodos.Size = new System.Drawing.Size(110, 25);
            this.btnListarTodos.Text = "Listar todos";
            this.btnListarTodos.UseVisualStyleBackColor = true;
            this.btnListarTodos.Click += new System.EventHandler(this.btnListarTodos_Click);
            this.dgvSeguimientos.Location = new System.Drawing.Point(20, 55);
            this.dgvSeguimientos.Name = "dgvSeguimientos";
            this.dgvSeguimientos.Size = new System.Drawing.Size(720, 350);
            this.dgvSeguimientos.AllowUserToAddRows = false;
            this.dgvSeguimientos.AllowUserToDeleteRows = false;
            this.dgvSeguimientos.ReadOnly = true;
            this.dgvSeguimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 430);
            this.Controls.Add(this.lblEnvioCodigo);
            this.Controls.Add(this.txtEnvioCodigo);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnListarTodos);
            this.Controls.Add(this.dgvSeguimientos);
            this.Name = "GUIListarSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar Seguimientos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIListarSeguimiento_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblEnvioCodigo;
        private System.Windows.Forms.TextBox txtEnvioCodigo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnListarTodos;
        private System.Windows.Forms.DataGridView dgvSeguimientos;
    }
}
