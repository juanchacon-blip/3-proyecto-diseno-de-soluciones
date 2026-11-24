namespace EnvioCliente.view
{
    partial class GUIAdicionarSeguimiento
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblEnvioCodigo = new System.Windows.Forms.Label();
            this.txtEnvioCodigo = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblOrden = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.lblDistanciaKm = new System.Windows.Forms.Label();
            this.txtDistanciaKm = new System.Windows.Forms.TextBox();
            this.lblFechaEvento = new System.Windows.Forms.Label();
            this.txtFechaEvento = new System.Windows.Forms.DateTimePicker();
            this.lblConfirmado = new System.Windows.Forms.Label();
            this.chkConfirmado = new System.Windows.Forms.CheckBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblCodigo.Location = new System.Drawing.Point(20, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblCodigo.Text = "Codigo:";
            this.txtCodigo.Location = new System.Drawing.Point(170, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 23);
            this.lblEnvioCodigo.Location = new System.Drawing.Point(20, 58);
            this.lblEnvioCodigo.Name = "lblEnvioCodigo";
            this.lblEnvioCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblEnvioCodigo.Text = "Codigo del envio:";
            this.txtEnvioCodigo.Location = new System.Drawing.Point(170, 55);
            this.txtEnvioCodigo.Name = "txtEnvioCodigo";
            this.txtEnvioCodigo.Size = new System.Drawing.Size(200, 23);
            this.lblUbicacion.Location = new System.Drawing.Point(20, 93);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(145, 20);
            this.lblUbicacion.Text = "Ubicacion:";
            this.txtUbicacion.Location = new System.Drawing.Point(170, 90);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(200, 23);
            this.lblOrden.Location = new System.Drawing.Point(20, 128);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(145, 20);
            this.lblOrden.Text = "Orden:";
            this.txtOrden.Location = new System.Drawing.Point(170, 125);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(200, 23);
            this.lblDistanciaKm.Location = new System.Drawing.Point(20, 163);
            this.lblDistanciaKm.Name = "lblDistanciaKm";
            this.lblDistanciaKm.Size = new System.Drawing.Size(145, 20);
            this.lblDistanciaKm.Text = "Distancia (km):";
            this.txtDistanciaKm.Location = new System.Drawing.Point(170, 160);
            this.txtDistanciaKm.Name = "txtDistanciaKm";
            this.txtDistanciaKm.Size = new System.Drawing.Size(200, 23);
            this.lblFechaEvento.Location = new System.Drawing.Point(20, 198);
            this.lblFechaEvento.Name = "lblFechaEvento";
            this.lblFechaEvento.Size = new System.Drawing.Size(145, 20);
            this.lblFechaEvento.Text = "Fecha y hora evento:";
            this.txtFechaEvento.Location = new System.Drawing.Point(170, 195);
            this.txtFechaEvento.Name = "txtFechaEvento";
            this.txtFechaEvento.Size = new System.Drawing.Size(200, 23);
            this.txtFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaEvento.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtFechaEvento.ShowUpDown = false;
            this.lblConfirmado.Location = new System.Drawing.Point(20, 233);
            this.lblConfirmado.Name = "lblConfirmado";
            this.lblConfirmado.Size = new System.Drawing.Size(145, 20);
            this.lblConfirmado.Text = "Confirmado:";
            this.chkConfirmado.Location = new System.Drawing.Point(170, 227);
            this.chkConfirmado.Name = "chkConfirmado";
            this.chkConfirmado.Size = new System.Drawing.Size(200, 23);
            this.chkConfirmado.Text = "Esta confirmado";
            this.chkConfirmado.UseVisualStyleBackColor = true;
            this.btnAdicionar.Location = new System.Drawing.Point(170, 280);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 30);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 340);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblEnvioCodigo);
            this.Controls.Add(this.txtEnvioCodigo);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.lblOrden);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.lblDistanciaKm);
            this.Controls.Add(this.txtDistanciaKm);
            this.Controls.Add(this.lblFechaEvento);
            this.Controls.Add(this.txtFechaEvento);
            this.Controls.Add(this.lblConfirmado);
            this.Controls.Add(this.chkConfirmado);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "GUIAdicionarSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Seguimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblEnvioCodigo;
        private System.Windows.Forms.TextBox txtEnvioCodigo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.Label lblDistanciaKm;
        private System.Windows.Forms.TextBox txtDistanciaKm;
        private System.Windows.Forms.Label lblFechaEvento;
        private System.Windows.Forms.DateTimePicker txtFechaEvento;
        private System.Windows.Forms.Label lblConfirmado;
        private System.Windows.Forms.CheckBox chkConfirmado;
        private System.Windows.Forms.Button btnAdicionar;
    }
}
