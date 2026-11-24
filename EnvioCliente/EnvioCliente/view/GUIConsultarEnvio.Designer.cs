namespace EnvioCliente.view
{
    partial class GUIConsultarEnvio
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
            this.lblOrigen = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblResCodigo = new System.Windows.Forms.Label();
            this.txtResCodigo = new System.Windows.Forms.TextBox();
            this.lblResOrigen = new System.Windows.Forms.Label();
            this.txtResOrigen = new System.Windows.Forms.TextBox();
            this.lblResDestino = new System.Windows.Forms.Label();
            this.txtResDestino = new System.Windows.Forms.TextBox();
            this.lblResPrecio = new System.Windows.Forms.Label();
            this.txtResPrecio = new System.Windows.Forms.TextBox();
            this.lblResFechaSalida = new System.Windows.Forms.Label();
            this.txtResFechaSalida = new System.Windows.Forms.TextBox();
            this.lblResDepartamentoDestino = new System.Windows.Forms.Label();
            this.txtResDepartamentoDestino = new System.Windows.Forms.TextBox();
            this.lblResCodigoPostalNacional = new System.Windows.Forms.Label();
            this.txtResCodigoPostalNacional = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.lblCodigo.Location = new System.Drawing.Point(20, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(145, 20);
            this.lblCodigo.Text = "Codigo:";
            this.txtCodigo.Location = new System.Drawing.Point(170, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 23);
            this.lblOrigen.Location = new System.Drawing.Point(20, 58);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(145, 20);
            this.lblOrigen.Text = "Origen:";
            this.txtOrigen.Location = new System.Drawing.Point(170, 55);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(200, 23);
            this.lblDestino.Location = new System.Drawing.Point(20, 93);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(145, 20);
            this.lblDestino.Text = "Destino:";
            this.txtDestino.Location = new System.Drawing.Point(170, 90);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(200, 23);
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
            this.lblResOrigen.Location = new System.Drawing.Point(20, 248);
            this.lblResOrigen.Name = "lblResOrigen";
            this.lblResOrigen.Size = new System.Drawing.Size(145, 20);
            this.lblResOrigen.Text = "Origen:";
            this.txtResOrigen.Location = new System.Drawing.Point(170, 245);
            this.txtResOrigen.Name = "txtResOrigen";
            this.txtResOrigen.Size = new System.Drawing.Size(200, 23);
            this.txtResOrigen.ReadOnly = true;
            this.lblResDestino.Location = new System.Drawing.Point(20, 283);
            this.lblResDestino.Name = "lblResDestino";
            this.lblResDestino.Size = new System.Drawing.Size(145, 20);
            this.lblResDestino.Text = "Destino:";
            this.txtResDestino.Location = new System.Drawing.Point(170, 280);
            this.txtResDestino.Name = "txtResDestino";
            this.txtResDestino.Size = new System.Drawing.Size(200, 23);
            this.txtResDestino.ReadOnly = true;
            this.lblResPrecio.Location = new System.Drawing.Point(20, 318);
            this.lblResPrecio.Name = "lblResPrecio";
            this.lblResPrecio.Size = new System.Drawing.Size(145, 20);
            this.lblResPrecio.Text = "Precio:";
            this.txtResPrecio.Location = new System.Drawing.Point(170, 315);
            this.txtResPrecio.Name = "txtResPrecio";
            this.txtResPrecio.Size = new System.Drawing.Size(200, 23);
            this.txtResPrecio.ReadOnly = true;
            this.lblResFechaSalida.Location = new System.Drawing.Point(20, 353);
            this.lblResFechaSalida.Name = "lblResFechaSalida";
            this.lblResFechaSalida.Size = new System.Drawing.Size(145, 20);
            this.lblResFechaSalida.Text = "Fecha y hora salida:";
            this.txtResFechaSalida.Location = new System.Drawing.Point(170, 350);
            this.txtResFechaSalida.Name = "txtResFechaSalida";
            this.txtResFechaSalida.Size = new System.Drawing.Size(200, 23);
            this.txtResFechaSalida.ReadOnly = true;
            this.lblResDepartamentoDestino.Location = new System.Drawing.Point(20, 388);
            this.lblResDepartamentoDestino.Name = "lblResDepartamentoDestino";
            this.lblResDepartamentoDestino.Size = new System.Drawing.Size(145, 20);
            this.lblResDepartamentoDestino.Text = "Departamento destino:";
            this.txtResDepartamentoDestino.Location = new System.Drawing.Point(170, 385);
            this.txtResDepartamentoDestino.Name = "txtResDepartamentoDestino";
            this.txtResDepartamentoDestino.Size = new System.Drawing.Size(200, 23);
            this.txtResDepartamentoDestino.ReadOnly = true;
            this.lblResCodigoPostalNacional.Location = new System.Drawing.Point(20, 423);
            this.lblResCodigoPostalNacional.Name = "lblResCodigoPostalNacional";
            this.lblResCodigoPostalNacional.Size = new System.Drawing.Size(145, 20);
            this.lblResCodigoPostalNacional.Text = "Codigo postal (opc.):";
            this.txtResCodigoPostalNacional.Location = new System.Drawing.Point(170, 420);
            this.txtResCodigoPostalNacional.Name = "txtResCodigoPostalNacional";
            this.txtResCodigoPostalNacional.Size = new System.Drawing.Size(200, 23);
            this.txtResCodigoPostalNacional.ReadOnly = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 475);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblResCodigo);
            this.Controls.Add(this.txtResCodigo);
            this.Controls.Add(this.lblResOrigen);
            this.Controls.Add(this.txtResOrigen);
            this.Controls.Add(this.lblResDestino);
            this.Controls.Add(this.txtResDestino);
            this.Controls.Add(this.lblResPrecio);
            this.Controls.Add(this.txtResPrecio);
            this.Controls.Add(this.lblResFechaSalida);
            this.Controls.Add(this.txtResFechaSalida);
            this.Controls.Add(this.lblResDepartamentoDestino);
            this.Controls.Add(this.txtResDepartamentoDestino);
            this.Controls.Add(this.lblResCodigoPostalNacional);
            this.Controls.Add(this.txtResCodigoPostalNacional);
            this.Name = "GUIConsultarEnvio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Envio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblResCodigo;
        private System.Windows.Forms.TextBox txtResCodigo;
        private System.Windows.Forms.Label lblResOrigen;
        private System.Windows.Forms.TextBox txtResOrigen;
        private System.Windows.Forms.Label lblResDestino;
        private System.Windows.Forms.TextBox txtResDestino;
        private System.Windows.Forms.Label lblResPrecio;
        private System.Windows.Forms.TextBox txtResPrecio;
        private System.Windows.Forms.Label lblResFechaSalida;
        private System.Windows.Forms.TextBox txtResFechaSalida;
        private System.Windows.Forms.Label lblResDepartamentoDestino;
        private System.Windows.Forms.TextBox txtResDepartamentoDestino;
        private System.Windows.Forms.Label lblResCodigoPostalNacional;
        private System.Windows.Forms.TextBox txtResCodigoPostalNacional;
    }
}
