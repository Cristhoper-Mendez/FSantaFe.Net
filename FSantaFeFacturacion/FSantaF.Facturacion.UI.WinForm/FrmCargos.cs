﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSantaF.Facturacion.LogicaDeNegocio;
using FSantaFe.Facturacion.EntidadesDeNegocio;
using FSantaF.Facturacion.UI.WinForm.UTILIDADES;

namespace FSantaF.Facturacion.UI.WinForm
{
    public partial class FrmCargos : Form
    {
        public FrmCargos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCargo frmCargo = new FrmCargo();

            frmCargo.StartPosition = FormStartPosition.CenterScreen;
            frmCargo.ShowDialog();

            MostrarCargos();
        }

        private void FrmCargos_Load(object sender, EventArgs e)
        {
            var listaEstados = EstadoBL.ObtenerTodos();

            listaEstados.Insert(0, new Estado { Id = 0, Nombre = "Seleccionar" });

            cboEstados.DataSource = listaEstados;
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";



            MostrarCargos();
        }

        private void MostrarCargos() {
            dgvCargos.DataSource = CargoBL.ObtenerTodos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvCargos);

            if (id > 0)
            {
                FrmCargo frmCargo = new FrmCargo();
                frmCargo.StartPosition = FormStartPosition.CenterScreen;
                frmCargo._idCargo = id;
                frmCargo.ShowDialog();
                MostrarCargos();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un Estado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvCargos);

            if (id > 0)
            {
                if (MessageBox.Show("Deseas eliminar el registro", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes
                  )
                {
                    if (CargoBL.Eliminar(new Cargo { Id = id }) > 0)
                    {
                        MessageBox.Show("Registro eliminado");
                        MostrarCargos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo
            {
                Nombre = textNombreCargo.Text,
                IdEstado = (byte)cboEstados.SelectedValue
            };

            dgvCargos.DataSource = CargoBL.Buscar(cargo);
        }
    }
}
