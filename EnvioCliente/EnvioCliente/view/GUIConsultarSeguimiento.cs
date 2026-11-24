using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIConsultarSeguimiento : Form
    {
        public GUIConsultarSeguimiento()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string envioCodigo = txtEnvioCodigo.Text.Trim();
            string ubicacion = txtUbicacion.Text.Trim();

            int criterios = (codigo != "" ? 1 : 0) + (envioCodigo != "" ? 1 : 0) + (ubicacion != "" ? 1 : 0);

            if (criterios == 0)
            {
                MessageBox.Show("Ingrese al menos un criterio de busqueda (codigo, codigo del envio, ubicacion).");
                return;
            }

            if (criterios > 2)
            {
                MessageBox.Show("Ingrese maximo dos criterios de busqueda.");
                return;
            }

            try
            {
                var obj = await SeguimientoController.Instance
                    .BuscarPorCriteriosAsync(codigo, envioCodigo, ubicacion);

                if (obj == null)
                {
                    MessageBox.Show("No se encontro ningun seguimiento con los criterios ingresados.");
                    limpiarResultado();
                    return;
                }

                mostrar(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtEnvioCodigo.Text = "";
            txtUbicacion.Text = "";
            limpiarResultado();
            txtCodigo.Focus();
        }

        private void mostrar(SeguimientoData obj)
        {
            txtResCodigo.Text = obj.codigo;
            txtResEnvioCodigo.Text = obj.envioCodigo;
            txtResUbicacion.Text = obj.ubicacion;
            txtResOrden.Text = obj.orden.ToString();
            txtResDistanciaKm.Text = obj.distanciaKm.ToString(CultureInfo.CurrentCulture);
            txtResFechaEvento.Text = DateTime.Parse(obj.fechaEvento, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm");
            txtResConfirmado.Text = (obj.confirmado ? "Si" : "No");
        }

        private void limpiarResultado()
        {
            txtResCodigo.Text = "";
            txtResEnvioCodigo.Text = "";
            txtResUbicacion.Text = "";
            txtResOrden.Text = "";
            txtResDistanciaKm.Text = "";
            txtResFechaEvento.Text = "";
            txtResConfirmado.Text = "";
        }
    }
}
