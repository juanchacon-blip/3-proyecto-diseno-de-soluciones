namespace EnvioCliente.view
{
    partial class GUIEliminarSeguimiento
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEnvioCodigo = new System.Windows.Forms.Label();
            this.txtEnvioCodigo = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblOrden = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.lblDistanciaKm = new System.Windows.Forms.Label();
            this.txtDistanciaKm = new System.Windows.Forms.TextBox();
            this.lblFechaEvento = new System.Windows.Forms.Label();
            this.txtFechaEvento = new System.Windows.Forms.TextBox();
            this.lblConfirmado = new System.Windows.Forms.Label();
            this.txtConfirmado = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblCodigo.Location = new System.Drawing.Point(20, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblCodigo.Text = "Codigo:";
            this.txtCodigo.Location = new System.Drawing.Point(170, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 23);
            this.btnBuscar.Location = new System.Drawing.Point(380, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 27);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.lblEnvioCodigo.Location = new System.Drawing.Point(20, 68);
            this.lblEnvioCodigo.Name = "lblEnvioCodigo";
            this.lblEnvioCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblEnvioCodigo.Text = "Codigo del envio:";
            this.txtEnvioCodigo.Location = new System.Drawing.Point(170, 65);
            this.txtEnvioCodigo.Name = "txtEnvioCodigo";
            this.txtEnvioCodigo.Size = new System.Drawing.Size(200, 23);
            this.txtEnvioCodigo.ReadOnly = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 103);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(145, 20);
            this.lblUbicacion.Text = "Ubicacion:";
            this.txtUbicacion.Location = new System.Drawing.Point(170, 100);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(200, 23);
            this.txtUbicacion.ReadOnly = true;
            this.lblOrden.Location = new System.Drawing.Point(20, 138);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(145, 20);
            this.lblOrden.Text = "Orden:";
            this.txtOrden.Location = new System.Drawing.Point(170, 135);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(200, 23);
            this.txtOrden.ReadOnly = true;
            this.lblDistanciaKm.Location = new System.Drawing.Point(20, 173);
            this.lblDistanciaKm.Name = "lblDistanciaKm";
            this.lblDistanciaKm.Size = new System.Drawing.Size(145, 20);
            this.lblDistanciaKm.Text = "Distancia (km):";
            this.txtDistanciaKm.Location = new System.Drawing.Point(170, 170);
            this.txtDistanciaKm.Name = "txtDistanciaKm";
            this.txtDistanciaKm.Size = new System.Drawing.Size(200, 23);
            this.txtDistanciaKm.ReadOnly = true;
            this.lblFechaEvento.Location = new System.Drawing.Point(20, 208);
            this.lblFechaEvento.Name = "lblFechaEvento";
            this.lblFechaEvento.Size = new System.Drawing.Size(145, 20);
            this.lblFechaEvento.Text = "Fecha y hora evento:";
            this.txtFechaEvento.Location = new System.Drawing.Point(170, 205);
            this.txtFechaEvento.Name = "txtFechaEvento";
            this.txtFechaEvento.Size = new System.Drawing.Size(200, 23);
            this.txtFechaEvento.ReadOnly = true;
            this.lblConfirmado.Location = new System.Drawing.Point(20, 243);
            this.lblConfirmado.Name = "lblConfirmado";
            this.lblConfirmado.Size = new System.Drawing.Size(145, 20);
            this.lblConfirmado.Text = "Confirmado:";
            this.txtConfirmado.Location = new System.Drawing.Point(170, 240);
            this.txtConfirmado.Name = "txtConfirmado";
            this.txtConfirmado.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmado.ReadOnly = true;
            this.btnEliminar.Location = new System.Drawing.Point(170, 290);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Enabled = false;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnBuscar);
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
            this.Controls.Add(this.txtConfirmado);
            this.Controls.Add(this.btnEliminar);
            this.Name = "GUIEliminarSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Seguimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblEnvioCodigo;
        private System.Windows.Forms.TextBox txtEnvioCodigo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.Label lblDistanciaKm;
        private System.Windows.Forms.TextBox txtDistanciaKm;
        private System.Windows.Forms.Label lblFechaEvento;
        private System.Windows.Forms.TextBox txtFechaEvento;
        private System.Windows.Forms.Label lblConfirmado;
        private System.Windows.Forms.TextBox txtConfirmado;
        private System.Windows.Forms.Button btnEliminar;
    }
}
