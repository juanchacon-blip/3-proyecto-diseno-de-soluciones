using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIAdicionarEnvio : Form
    {
        public GUIAdicionarEnvio()
        {
            InitializeComponent();
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            double v_precio;
            int? v_codigoPostalNacional = null;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtOrigen.Text) ||
                string.IsNullOrWhiteSpace(txtDestino.Text) ||
                string.IsNullOrWhiteSpace(txtDepartamentoDestino.Text))
            {
                MessageBox.Show("Complete los campos obligatorios: codigo, origen, destino, departamento de destino.");
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out v_precio) || v_precio <= 0)
            {
                MessageBox.Show("El precio debe ser un numero mayor que cero.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtCodigoPostalNacional.Text))
            {
                int parsed;
                if (!int.TryParse(txtCodigoPostalNacional.Text, out parsed) || parsed < 1 || parsed > 999999)
                {
                    MessageBox.Show("El codigo postal debe ser un numero entero entre 1 y 999999.");
                    return;
                }
                v_codigoPostalNacional = parsed;
            }

            try
            {
                await EnvioController.Instance.AdicionarAsync(new EnvioInput
                {
                    codigo = txtCodigo.Text.Trim(),
                    origen = txtOrigen.Text.Trim(),
                    destino = txtDestino.Text.Trim(),
                    precio = v_precio,
                    fechaSalida = txtFechaSalida.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    departamentoDestino = txtDepartamentoDestino.Text.Trim(),
                    codigoPostalNacional = v_codigoPostalNacional
                });

                MessageBox.Show("Envio adicionado correctamente.");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Deja la ventana lista para repetir el proceso; el usuario la cierra cuando quiera.
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtPrecio.Text = "";
            txtFechaSalida.Value = DateTime.Now;
            txtDepartamentoDestino.Text = "";
            txtCodigoPostalNacional.Text = "";
            txtCodigo.Focus();
        }
    }
}
