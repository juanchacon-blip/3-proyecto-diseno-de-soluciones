using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvioCliente.controller;
using EnvioCliente.observer;

namespace EnvioCliente.view
{
    // Observador: se suscribe al subject y se refresca cuando otra ventana
    // adiciona, actualiza o elimina datos.
    public partial class GUIListarSeguimiento : Form, IObservador
    {
        // Recuerda la ultima consulta (todos o filtrado) para repetirla al ser notificado.
        private bool ultimoFueFiltro = false;
        // Mientras no se oprima Listar todos o Filtrar, la grilla permanece vacia.
        private bool consultado = false;
        private string filtroA = "";
        private string filtroB = "";

        public GUIListarSeguimiento()
        {
            InitializeComponent();
            dgvSeguimientos.CellFormatting += dgvSeguimientos_CellFormatting;
            EnviosSubject.Instance.Suscribir(this);
        }

        // Muestra la fecha ISO del servidor (2026-10-21T10:00:00) como dd/MM/yyyy HH:mm, igual que los formularios.
        private void dgvSeguimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || !(e.Value is string))
            {
                return;
            }

            if (dgvSeguimientos.Columns[e.ColumnIndex].DataPropertyName != "fechaEvento")
            {
                return;
            }

            DateTime fecha;
            if (DateTime.TryParse((string)e.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                e.Value = fecha.ToString("dd/MM/yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        private void GUIListarSeguimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            EnviosSubject.Instance.Desuscribir(this);
        }

        // Llamado por el Subject cuando los datos cambiaron.
        public async void Actualizar()
        {
            if (IsDisposed || !IsHandleCreated || !consultado)
            {
                return;
            }

            if (ultimoFueFiltro)
            {
                await ejecutarFiltro(filtroA, filtroB);
            }
            else
            {
                await listarTodos();
            }
        }

        private async void btnListarTodos_Click(object sender, EventArgs e)
        {
            txtEnvioCodigo.Text = "";
            txtUbicacion.Text = "";
            await listarTodos();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnvioCodigo.Text) &&
                string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Ingrese un cod. envio o un ubicacion para filtrar.");
                return;
            }

            await ejecutarFiltro(txtEnvioCodigo.Text.Trim(), txtUbicacion.Text.Trim());
        }

        private async Task listarTodos()
        {
            ultimoFueFiltro = false;
            consultado = true;

            try
            {
                dgvSeguimientos.DataSource = await SeguimientoController.Instance.ListarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ejecutarFiltro(string a, string b)
        {
            ultimoFueFiltro = true;
            consultado = true;
            filtroA = a;
            filtroB = b;

            try
            {
                dgvSeguimientos.DataSource = await SeguimientoController.Instance.FiltrarAsync(a, b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
