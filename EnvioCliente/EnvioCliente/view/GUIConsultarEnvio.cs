using System;
using System.Globalization;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.model;

namespace EnvioCliente.view
{
    public partial class GUIConsultarEnvio : Form
    {
        public GUIConsultarEnvio()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string origen = txtOrigen.Text.Trim();
            string destino = txtDestino.Text.Trim();

            int criterios = (codigo != "" ? 1 : 0) + (origen != "" ? 1 : 0) + (destino != "" ? 1 : 0);

            if (criterios == 0)
            {
                MessageBox.Show("Ingrese al menos un criterio de busqueda (codigo, origen, destino).");
                return;
            }

            if (criterios > 2)
            {
                MessageBox.Show("Ingrese maximo dos criterios de busqueda.");
                return;
            }

            try
            {
                var obj = await EnvioController.Instance
                    .BuscarPorCriteriosAsync(codigo, origen, destino);

                if (obj == null)
                {
                    MessageBox.Show("No se encontro ningun envio con los criterios ingresados.");
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
            txtOrigen.Text = "";
            txtDestino.Text = "";
            limpiarResultado();
            txtCodigo.Focus();
        }

        private void mostrar(EnvioData obj)
        {
            txtResCodigo.Text = obj.codigo;
            txtResOrigen.Text = obj.origen;
            txtResDestino.Text = obj.destino;
            txtResPrecio.Text = obj.precio.ToString(CultureInfo.CurrentCulture);
            txtResFechaSalida.Text = DateTime.Parse(obj.fechaSalida, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm");
            txtResDepartamentoDestino.Text = obj.departamentoDestino;
            txtResCodigoPostalNacional.Text = (obj.codigoPostalNacional.HasValue ? obj.codigoPostalNacional.Value.ToString() : "");
        }

        private void limpiarResultado()
        {
            txtResCodigo.Text = "";
            txtResOrigen.Text = "";
            txtResDestino.Text = "";
            txtResPrecio.Text = "";
            txtResFechaSalida.Text = "";
            txtResDepartamentoDestino.Text = "";
            txtResCodigoPostalNacional.Text = "";
        }
    }
}
