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
    public partial class FrmCargo : Form
    {
        Cargo cargo = new Cargo();
        public byte _idCargo = 0;

        public FrmCargo()
        {
            InitializeComponent();
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {

            cboEstados.DataSource = EstadoBL.ObtenerTodos();
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";

            cboEstados.SelectedItem = null;
            cboEstados.SelectedText = "Seleccionar";

            if (_idCargo > 0) {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            cargo = CargoBL.ObtenerPorId(_idCargo);

            if (cargo.Id > 0)
            {
                textNombreCargo.Text = cargo.Nombre;
                cboEstados.SelectedValue = cargo.IdEstado;
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

            if (textNombreCargo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nombre Estado es requerido");
                validar = true;
            }

            var idEstado = (cboEstados.SelectedValue == null) ? 0 : (byte)cboEstados.SelectedValue;

            if(idEstado == 0) {
                MessageBox.Show("Seleccione un estado");
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
                    cargo.Nombre = textNombreCargo.Text;
                    cargo.IdEstado = (byte)cboEstados.SelectedValue;

                    if (_idCargo <= 0)
                    {
                        if (CargoBL.Guardar(cargo) > 0)
                        {
                            MessageBox.Show("Se guardo correctamente");
                            this.Close();
                        }
                    }
                    else
                    {
                        if (CargoBL.Modificar(cargo) > 0)
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
