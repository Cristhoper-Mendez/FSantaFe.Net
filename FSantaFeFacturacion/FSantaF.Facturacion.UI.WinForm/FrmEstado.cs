using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSantaFe.Facturacion.EntidadesDeNegocio;
using FSantaF.Facturacion.LogicaDeNegocio;

namespace FSantaF.Facturacion.UI.WinForm
{
    public partial class FrmEstado : Form
    {
        Estado estado = new Estado();

        public byte _idEstado = 0;

        public FrmEstado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmEstado_Load(object sender, EventArgs e)
        {
            if (_idEstado > 0)
            {
                CargarDatos();
            }
            else
            {

            }
        }

        private void CargarDatos()
        {
            estado = EstadoBL.ObtenerEstadoId(_idEstado);

            if (estado.Id > 0)
            {
                textNombreEstado.Text = estado.Nombre;
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
                this.Close();
            }
        }

        private bool ValidarDatosForm()
        {
            bool validar = false;

            if (textNombreEstado.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nombre Estado es requerido");
                validar = true;
            }

            return validar;
        }

        private void Guardar()
        {
            try
            {
                if (!ValidarDatosForm())
                {
                    estado.Nombre = textNombreEstado.Text;

                    if(_idEstado <= 0) {
                        if (EstadoBL.Guardar(estado) > 0) {
                            MessageBox.Show("Se guardo correctamente");
                            this.Close();
                        }
                    } else {
                        if (EstadoBL.Modificar(estado) > 0)
                        {
                            MessageBox.Show("Se guardo correctamente");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar Guardar");

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
