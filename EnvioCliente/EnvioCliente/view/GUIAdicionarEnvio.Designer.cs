namespace EnvioCliente.view
{
    partial class GUIAdicionarEnvio
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
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.txtFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.lblDepartamentoDestino = new System.Windows.Forms.Label();
            this.txtDepartamentoDestino = new System.Windows.Forms.TextBox();
            this.lblCodigoPostalNacional = new System.Windows.Forms.Label();
            this.txtCodigoPostalNacional = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
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
            this.lblPrecio.Location = new System.Drawing.Point(20, 128);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(145, 20);
            this.lblPrecio.Text = "Precio:";
            this.txtPrecio.Location = new System.Drawing.Point(170, 125);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(200, 23);
            this.lblFechaSalida.Location = new System.Drawing.Point(20, 163);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(145, 20);
            this.lblFechaSalida.Text = "Fecha y hora salida:";
            this.txtFechaSalida.Location = new System.Drawing.Point(170, 160);
            this.txtFechaSalida.Name = "txtFechaSalida";
            this.txtFechaSalida.Size = new System.Drawing.Size(200, 23);
            this.txtFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaSalida.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtFechaSalida.ShowUpDown = false;
            this.lblDepartamentoDestino.Location = new System.Drawing.Point(20, 198);
            this.lblDepartamentoDestino.Name = "lblDepartamentoDestino";
            this.lblDepartamentoDestino.Size = new System.Drawing.Size(145, 20);
            this.lblDepartamentoDestino.Text = "Departamento destino:";
            this.txtDepartamentoDestino.Location = new System.Drawing.Point(170, 195);
            this.txtDepartamentoDestino.Name = "txtDepartamentoDestino";
            this.txtDepartamentoDestino.Size = new System.Drawing.Size(200, 23);
            this.lblCodigoPostalNacional.Location = new System.Drawing.Point(20, 233);
            this.lblCodigoPostalNacional.Name = "lblCodigoPostalNacional";
            this.lblCodigoPostalNacional.Size = new System.Drawing.Size(145, 20);
            this.lblCodigoPostalNacional.Text = "Codigo postal (opc.):";
            this.txtCodigoPostalNacional.Location = new System.Drawing.Point(170, 230);
            this.txtCodigoPostalNacional.Name = "txtCodigoPostalNacional";
            this.txtCodigoPostalNacional.Size = new System.Drawing.Size(200, 23);
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
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblFechaSalida);
            this.Controls.Add(this.txtFechaSalida);
            this.Controls.Add(this.lblDepartamentoDestino);
            this.Controls.Add(this.txtDepartamentoDestino);
            this.Controls.Add(this.lblCodigoPostalNacional);
            this.Controls.Add(this.txtCodigoPostalNacional);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "GUIAdicionarEnvio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Envio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.DateTimePicker txtFechaSalida;
        private System.Windows.Forms.Label lblDepartamentoDestino;
        private System.Windows.Forms.TextBox txtDepartamentoDestino;
        private System.Windows.Forms.Label lblCodigoPostalNacional;
        private System.Windows.Forms.TextBox txtCodigoPostalNacional;
        private System.Windows.Forms.Button btnAdicionar;
    }
}
