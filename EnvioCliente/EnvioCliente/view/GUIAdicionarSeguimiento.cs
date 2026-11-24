using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIAdicionarSeguimiento : Form
    {
        public GUIAdicionarSeguimiento()
        {
            InitializeComponent();
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            int v_orden;
            double v_distanciaKm;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtEnvioCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Complete los campos obligatorios: codigo, codigo del envio, ubicacion.");
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
                await SeguimientoController.Instance.AdicionarAsync(new SeguimientoInput
                {
                    codigo = txtCodigo.Text.Trim(),
                    envioCodigo = txtEnvioCodigo.Text.Trim(),
                    ubicacion = txtUbicacion.Text.Trim(),
                    orden = v_orden,
                    distanciaKm = v_distanciaKm,
                    fechaEvento = txtFechaEvento.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    confirmado = chkConfirmado.Checked
                });

                MessageBox.Show("Seguimiento adicionado correctamente.");
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
            txtFechaEvento.Value = DateTime.Now;
            chkConfirmado.Checked = false;
            txtCodigo.Focus();
        }
    }
}
