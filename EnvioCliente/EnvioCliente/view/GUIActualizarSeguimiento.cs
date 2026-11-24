using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIActualizarSeguimiento : Form
    {
        // Codigo del registro que se busco y cuya informacion se esta mostrando.
        // Actualizar siempre opera sobre este codigo, no sobre lo que haya en el cuadro de texto.
        private string codigoBuscado = null;

        public GUIActualizarSeguimiento()
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
                var obj = await SeguimientoController.Instance.BuscarPorCodigoAsync(txtCodigo.Text);

                if (obj == null)
                {
                    MessageBox.Show("No existe el seguimiento con ese codigo.");
                    codigoBuscado = null;
                    habilitarCampos(false);
                    return;
                }

                codigoBuscado = obj.codigo;
                txtEnvioCodigo.Text = obj.envioCodigo;
                txtUbicacion.Text = obj.ubicacion;
                txtOrden.Text = obj.orden.ToString();
                txtDistanciaKm.Text = obj.distanciaKm.ToString(CultureInfo.CurrentCulture);
                txtFechaEvento.Value = DateTime.Parse(obj.fechaEvento, CultureInfo.InvariantCulture);
                chkConfirmado.Checked = obj.confirmado;

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
                MessageBox.Show("Primero busque el seguimiento que desea actualizar.");
                return;
            }

            int v_orden;
            double v_distanciaKm;

            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Complete los campos obligatorios: ubicacion.");
                return;
            }

            if (!int.TryParse(txtOrden.Text, out v_orden) || v_orden < 1)
            {
                MessageBox.Show("El orden debe ser un numero entero mayor o igual a 1.");
                return;
            }

            if (!double.TryParse(txtDistanciaKm.Text, out v_distanciaKm) || v_distanciaKm < 0)
            {
                MessageBox.Show("La distancia debe ser un numero mayor o igual a cero.");
                return;
            }


            try
            {
                await SeguimientoController.Instance.ActualizarAsync(new SeguimientoInput
                {
                    codigo = codigoBuscado,
                    envioCodigo = txtEnvioCodigo.Text.Trim(),
                    ubicacion = txtUbicacion.Text.Trim(),
                    orden = v_orden,
                    distanciaKm = v_distanciaKm,
                    fechaEvento = txtFechaEvento.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    confirmado = chkConfirmado.Checked
                });

                MessageBox.Show("Seguimiento actualizado correctamente.");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void habilitarCampos(bool habilitar)
        {
            txtUbicacion.Enabled = habilitar;
            txtOrden.Enabled = habilitar;
            txtDistanciaKm.Enabled = habilitar;
            txtFechaEvento.Enabled = habilitar;
            chkConfirmado.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
        }

        // Deja la ventana lista para repetir el proceso; el usuario la cierra cuando quiera.
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtEnvioCodigo.Text = "";
            txtUbicacion.Text = "";
            txtOrden.Text = "";
            txtDistanciaKm.Text = "";
            txtFechaEvento.Value = DateTime.Now;
            chkConfirmado.Checked = false;
            codigoBuscado = null;
            habilitarCampos(false);
            txtCodigo.Focus();
        }
    }
}
