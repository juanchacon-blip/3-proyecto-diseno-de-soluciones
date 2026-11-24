using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIActualizarEnvio : Form
    {
        // Codigo del registro que se busco y cuya informacion se esta mostrando.
        // Actualizar siempre opera sobre este codigo, no sobre lo que haya en el cuadro de texto.
        private string codigoBuscado = null;

        public GUIActualizarEnvio()
        {
            InitializeComponent();

            // Si el usuario cambia el codigo despues de buscar, debe buscar de nuevo.
            txtCodigo.TextChanged += (s, e) =>
            {
                if (codigoBuscado != null && !string.Equals(txtCodigo.Text.Trim(), codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    codigoBuscado = null;
                    habilitarCampos(false);
                }
            };
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = await EnvioController.Instance.BuscarPorCodigoAsync(txtCodigo.Text);

                if (obj == null)
                {
                    MessageBox.Show("No existe el envio con ese codigo.");
                    codigoBuscado = null;
                    habilitarCampos(false);
                    return;
                }

                codigoBuscado = obj.codigo;
                txtOrigen.Text = obj.origen;
                txtDestino.Text = obj.destino;
                txtPrecio.Text = obj.precio.ToString(CultureInfo.CurrentCulture);
                txtFechaSalida.Value = DateTime.Parse(obj.fechaSalida, CultureInfo.InvariantCulture);
                txtDepartamentoDestino.Text = obj.departamentoDestino;
                txtCodigoPostalNacional.Text = (obj.codigoPostalNacional.HasValue ? obj.codigoPostalNacional.Value.ToString() : "");

                habilitarCampos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (codigoBuscado == null)
            {
                MessageBox.Show("Primero busque el envio que desea actualizar.");
                return;
            }

            double v_precio;
            int? v_codigoPostalNacional = null;

            if (string.IsNullOrWhiteSpace(txtOrigen.Text) ||
                string.IsNullOrWhiteSpace(txtDestino.Text) ||
                string.IsNullOrWhiteSpace(txtDepartamentoDestino.Text))
            {
                MessageBox.Show("Complete los campos obligatorios: origen, destino, departamento de destino.");
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
                await EnvioController.Instance.ActualizarAsync(new EnvioInput
                {
                    codigo = codigoBuscado,
                    origen = txtOrigen.Text.Trim(),
                    destino = txtDestino.Text.Trim(),
                    precio = v_precio,
                    fechaSalida = txtFechaSalida.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    departamentoDestino = txtDepartamentoDestino.Text.Trim(),
                    codigoPostalNacional = v_codigoPostalNacional
                });

                MessageBox.Show("Envio actualizado correctamente.");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void habilitarCampos(bool habilitar)
        {
            txtOrigen.Enabled = habilitar;
            txtDestino.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtFechaSalida.Enabled = habilitar;
            txtDepartamentoDestino.Enabled = habilitar;
            txtCodigoPostalNacional.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
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
            codigoBuscado = null;
            habilitarCampos(false);
            txtCodigo.Focus();
        }
    }
}
