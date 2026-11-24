using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;

namespace EnvioCliente.view
{
    public partial class GUIEliminarSeguimiento : Form
    {
        // Codigo del registro que se busco y cuya informacion se esta mostrando.
        // Eliminar siempre opera sobre este codigo, no sobre lo que haya en el cuadro de texto.
        private string codigoBuscado = null;

        public GUIEliminarSeguimiento()
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
                var obj = await SeguimientoController.Instance.BuscarPorCodigoAsync(txtCodigo.Text);

                if (obj == null)
                {
                    MessageBox.Show("No existe el seguimiento con ese codigo.");
                    codigoBuscado = null;
                    btnEliminar.Enabled = false;
                    return;
                }

                codigoBuscado = obj.codigo;
                txtEnvioCodigo.Text = obj.envioCodigo;
                txtUbicacion.Text = obj.ubicacion;
                txtOrden.Text = obj.orden.ToString();
                txtDistanciaKm.Text = obj.distanciaKm.ToString(CultureInfo.CurrentCulture);
                txtFechaEvento.Text = DateTime.Parse(obj.fechaEvento, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm");
                txtConfirmado.Text = (obj.confirmado ? "Si" : "No");

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
                MessageBox.Show("Primero busque el seguimiento que desea eliminar.");
                return;
            }

            try
            {
                await SeguimientoController.Instance.EliminarAsync(codigoBuscado);

                MessageBox.Show("Seguimiento eliminado correctamente.");
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
            txtEnvioCodigo.Text = "";
            txtUbicacion.Text = "";
            txtOrden.Text = "";
            txtDistanciaKm.Text = "";
            txtFechaEvento.Text = "";
            txtConfirmado.Text = "";
            codigoBuscado = null;
            btnEliminar.Enabled = false;
            txtCodigo.Focus();
        }
    }
}
