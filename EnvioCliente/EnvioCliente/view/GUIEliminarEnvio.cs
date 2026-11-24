using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;

namespace EnvioCliente.view
{
    public partial class GUIEliminarEnvio : Form
    {
        // Codigo del registro que se busco y cuya informacion se esta mostrando.
        // Eliminar siempre opera sobre este codigo, no sobre lo que haya en el cuadro de texto.
        private string codigoBuscado = null;

        public GUIEliminarEnvio()
        {
            InitializeComponent();

            // Si el usuario cambia el codigo despues de buscar, debe buscar de nuevo.
            txtCodigo.TextChanged += (s, e) =>
            {
                if (codigoBuscado != null && !string.Equals(txtCodigo.Text.Trim(), codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    codigoBuscado = null;
                    btnEliminar.Enabled = false;
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
                    btnEliminar.Enabled = false;
                    return;
                }

                codigoBuscado = obj.codigo;
                txtOrigen.Text = obj.origen;
                txtDestino.Text = obj.destino;
                txtPrecio.Text = obj.precio.ToString(CultureInfo.CurrentCulture);
                txtFechaSalida.Text = DateTime.Parse(obj.fechaSalida, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm");
                txtDepartamentoDestino.Text = obj.departamentoDestino;
                txtCodigoPostalNacional.Text = (obj.codigoPostalNacional.HasValue ? obj.codigoPostalNacional.Value.ToString() : "");

                btnEliminar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codigoBuscado == null)
            {
                MessageBox.Show("Primero busque el envio que desea eliminar.");
                return;
            }

            try
            {
                await EnvioController.Instance.EliminarAsync(codigoBuscado);

                MessageBox.Show("Envio eliminado correctamente.");
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
            txtFechaSalida.Text = "";
            txtDepartamentoDestino.Text = "";
            txtCodigoPostalNacional.Text = "";
            codigoBuscado = null;
            btnEliminar.Enabled = false;
            txtCodigo.Focus();
        }
    }
}
