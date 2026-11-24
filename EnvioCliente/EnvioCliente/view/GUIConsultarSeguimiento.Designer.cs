namespace EnvioCliente.view
{
    partial class GUIConsultarSeguimiento
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblResCodigo = new System.Windows.Forms.Label();
            this.txtResCodigo = new System.Windows.Forms.TextBox();
            this.lblResEnvioCodigo = new System.Windows.Forms.Label();
            this.txtResEnvioCodigo = new System.Windows.Forms.TextBox();
            this.lblResUbicacion = new System.Windows.Forms.Label();
            this.txtResUbicacion = new System.Windows.Forms.TextBox();
            this.lblResOrden = new System.Windows.Forms.Label();
            this.txtResOrden = new System.Windows.Forms.TextBox();
            this.lblResDistanciaKm = new System.Windows.Forms.Label();
            this.txtResDistanciaKm = new System.Windows.Forms.TextBox();
            this.lblResFechaEvento = new System.Windows.Forms.Label();
            this.txtResFechaEvento = new System.Windows.Forms.TextBox();
            this.lblResConfirmado = new System.Windows.Forms.Label();
            this.txtResConfirmado = new System.Windows.Forms.TextBox();
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
            this.btnConsultar.Location = new System.Drawing.Point(170, 130);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnLimpiar.Location = new System.Drawing.Point(280, 130);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.lblResultado.Location = new System.Drawing.Point(20, 180);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(140, 20);
            this.lblResultado.Text = "Resultado:";
            this.lblResCodigo.Location = new System.Drawing.Point(20, 213);
            this.lblResCodigo.Name = "lblResCodigo";
            this.lblResCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblResCodigo.Text = "Codigo:";
            this.txtResCodigo.Location = new System.Drawing.Point(170, 210);
            this.txtResCodigo.Name = "txtResCodigo";
            this.txtResCodigo.Size = new System.Drawing.Size(200, 23);
            this.txtResCodigo.ReadOnly = true;
            this.lblResEnvioCodigo.Location = new System.Drawing.Point(20, 248);
            this.lblResEnvioCodigo.Name = "lblResEnvioCodigo";
            this.lblResEnvioCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblResEnvioCodigo.Text = "Codigo del envio:";
            this.txtResEnvioCodigo.Location = new System.Drawing.Point(170, 245);
            this.txtResEnvioCodigo.Name = "txtResEnvioCodigo";
            this.txtResEnvioCodigo.Size = new System.Drawing.Size(200, 23);
            this.txtResEnvioCodigo.ReadOnly = true;
            this.lblResUbicacion.Location = new System.Drawing.Point(20, 283);
            this.lblResUbicacion.Name = "lblResUbicacion";
            this.lblResUbicacion.Size = new System.Drawing.Size(145, 20);
            this.lblResUbicacion.Text = "Ubicacion:";
            this.txtResUbicacion.Location = new System.Drawing.Point(170, 280);
            this.txtResUbicacion.Name = "txtResUbicacion";
            this.txtResUbicacion.Size = new System.Drawing.Size(200, 23);
            this.txtResUbicacion.ReadOnly = true;
            this.lblResOrden.Location = new System.Drawing.Point(20, 318);
            this.lblResOrden.Name = "lblResOrden";
            this.lblResOrden.Size = new System.Drawing.Size(145, 20);
            this.lblResOrden.Text = "Orden:";
            this.txtResOrden.Location = new System.Drawing.Point(170, 315);
            this.txtResOrden.Name = "txtResOrden";
            this.txtResOrden.Size = new System.Drawing.Size(200, 23);
            this.txtResOrden.ReadOnly = true;
            this.lblResDistanciaKm.Location = new System.Drawing.Point(20, 353);
            this.lblResDistanciaKm.Name = "lblResDistanciaKm";
            this.lblResDistanciaKm.Size = new System.Drawing.Size(145, 20);
            this.lblResDistanciaKm.Text = "Distancia (km):";
            this.txtResDistanciaKm.Location = new System.Drawing.Point(170, 350);
            this.txtResDistanciaKm.Name = "txtResDistanciaKm";
            this.txtResDistanciaKm.Size = new System.Drawing.Size(200, 23);
            this.txtResDistanciaKm.ReadOnly = true;
            this.lblResFechaEvento.Location = new System.Drawing.Point(20, 388);
            this.lblResFechaEvento.Name = "lblResFechaEvento";
            this.lblResFechaEvento.Size = new System.Drawing.Size(145, 20);
            this.lblResFechaEvento.Text = "Fecha y hora evento:";
            this.txtResFechaEvento.Location = new System.Drawing.Point(170, 385);
            this.txtResFechaEvento.Name = "txtResFechaEvento";
            this.txtResFechaEvento.Size = new System.Drawing.Size(200, 23);
            this.txtResFechaEvento.ReadOnly = true;
            this.lblResConfirmado.Location = new System.Drawing.Point(20, 423);
            this.lblResConfirmado.Name = "lblResConfirmado";
            this.lblResConfirmado.Size = new System.Drawing.Size(145, 20);
            this.lblResConfirmado.Text = "Confirmado:";
            this.txtResConfirmado.Location = new System.Drawing.Point(170, 420);
            this.txtResConfirmado.Name = "txtResConfirmado";
            this.txtResConfirmado.Size = new System.Drawing.Size(200, 23);
            this.txtResConfirmado.ReadOnly = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 475);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblEnvioCodigo);
            this.Controls.Add(this.txtEnvioCodigo);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblResCodigo);
            this.Controls.Add(this.txtResCodigo);
            this.Controls.Add(this.lblResEnvioCodigo);
            this.Controls.Add(this.txtResEnvioCodigo);
            this.Controls.Add(this.lblResUbicacion);
            this.Controls.Add(this.txtResUbicacion);
            this.Controls.Add(this.lblResOrden);
            this.Controls.Add(this.txtResOrden);
            this.Controls.Add(this.lblResDistanciaKm);
            this.Controls.Add(this.txtResDistanciaKm);
            this.Controls.Add(this.lblResFechaEvento);
            this.Controls.Add(this.txtResFechaEvento);
            this.Controls.Add(this.lblResConfirmado);
            this.Controls.Add(this.txtResConfirmado);
            this.Name = "GUIConsultarSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Seguimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblEnvioCodigo;
        private System.Windows.Forms.TextBox txtEnvioCodigo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblResCodigo;
        private System.Windows.Forms.TextBox txtResCodigo;
        private System.Windows.Forms.Label lblResEnvioCodigo;
        private System.Windows.Forms.TextBox txtResEnvioCodigo;
        private System.Windows.Forms.Label lblResUbicacion;
        private System.Windows.Forms.TextBox txtResUbicacion;
        private System.Windows.Forms.Label lblResOrden;
        private System.Windows.Forms.TextBox txtResOrden;
        private System.Windows.Forms.Label lblResDistanciaKm;
        private System.Windows.Forms.TextBox txtResDistanciaKm;
        private System.Windows.Forms.Label lblResFechaEvento;
        private System.Windows.Forms.TextBox txtResFechaEvento;
        private System.Windows.Forms.Label lblResConfirmado;
        private System.Windows.Forms.TextBox txtResConfirmado;
    }
}
