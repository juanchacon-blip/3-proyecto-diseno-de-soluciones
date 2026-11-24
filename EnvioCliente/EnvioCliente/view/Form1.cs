using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EnvioCliente.view
{
    public partial class Form1 : Form
    {
        // Ventanas abiertas (una por caso de uso). Son no modales: se pueden tener varias a la vez.
        private readonly Dictionary<Type, Form> ventanasAbiertas = new Dictionary<Type, Form>();

        public Form1()
        {
            InitializeComponent();
        }

        // Abre la ventana del caso de uso sin bloquear las demas. Si ya esta abierta, la trae al frente.
        private void abrir<T>() where T : Form, new()
        {
            Form ventana;
            if (ventanasAbiertas.TryGetValue(typeof(T), out ventana) && !ventana.IsDisposed)
            {
                if (ventana.WindowState == FormWindowState.Minimized)
                {
                    ventana.WindowState = FormWindowState.Normal;
                }
                ventana.Activate();
                return;
            }

            ventana = new T();
            ventanasAbiertas[typeof(T)] = ventana;

            // En cascada, para que las ventanas no queden una encima de otra.
            int n = ventanasAbiertas.Values.Count(v => !v.IsDisposed) - 1;
            ventana.StartPosition = FormStartPosition.Manual;
            ventana.Location = new Point(Location.X + 40 + 30 * (n % 8), Location.Y + 60 + 30 * (n % 8));
            ventana.Show(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIAdicionarPaquete>();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIConsultarPaquete>();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIListarPaquete>();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIActualizarPaquete>();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIEliminarPaquete>();
        }

        private void adicionarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIAdicionarEnvio>();
        }

        private void consultarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIConsultarEnvio>();
        }

        private void listarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIListarEnvio>();
        }

        private void actualizarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIActualizarEnvio>();
        }

        private void eliminarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIEliminarEnvio>();
        }

        private void adicionarSeguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIAdicionarSeguimiento>();
        }

        private void consultarSeguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIConsultarSeguimiento>();
        }

        private void listarSeguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIListarSeguimiento>();
        }

        private void actualizarSeguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIActualizarSeguimiento>();
        }

        private void eliminarSeguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir<GUIEliminarSeguimiento>();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Gestión de Paquetes\nVersión 2.0\n\nIntegrantes:\n" +
                "Juan Esteban Molano Polanco codigo 2220232008\n" +
                "Juan Pablo Chacon codigo 2220232030\n" +
                "Johan Daniel Esterling codigo 2220241033",
                "Acerca de...");
        }
    }
}
