﻿using System;
using System.Linq;
using System.Windows.Forms;
using LugTp.Entities;

namespace LugTp.UI
{
    public partial class AlumnosForm : Form
    {
        public AlumnosForm()
        {
            InitializeComponent();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            var alumno = new Alumno(txtNombre.Text,
                                     txtApellido.Text,
                                     txtDireccion.Text,
                                     txtTelefono.Text,
                                     txtLegajo.Text,
                                     chbAlDia.Checked);

            Form1.Context.Alumnos.Add(alumno);
            Form1.Context.SaveChange();
            CleanWindow();
            LoadData();
        }



        private void CheckCompleteForm()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)
                ||
                string.IsNullOrWhiteSpace(txtApellido.Text)
                ||
                string.IsNullOrWhiteSpace(txtDireccion.Text)
                ||
                string.IsNullOrWhiteSpace(txtTelefono.Text)
                ||
                string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                btnAccion.Enabled = false;
            }
            else
            {
                btnAccion.Enabled = true;
            }
        }

        private void CleanWindow()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            chbAlDia.Checked = false;
            txtLegajo.Text = string.Empty;
        }

        private void LoadData()
        {
            grvDocentes.Rows.Clear();
            var alumnos = Form1.Context.Alumnos.GetAll();

            alumnos?.ToList().ForEach(alumno =>
            {
                grvDocentes.Rows.Add(alumno.Id,
                    alumno.Nombre,
                    alumno.Apellido,
                    alumno.Legajo,
                    alumno.CuotaAlDia,
                    alumno.Telefono,
                    alumno.Direccion);
            });
        }

        private void AlumnosForm_Load(object sender, EventArgs e)
        {
            grvDocentes.Columns.Add("Id", "Id");
            grvDocentes.Columns.Add("Nombre", "Nombre");
            grvDocentes.Columns["Nombre"].Width = 100;

            grvDocentes.Columns.Add("Apellido", "Apellido");
            grvDocentes.Columns["Apellido"].Width = 100;

            grvDocentes.Columns.Add("Legajo", "Legajo");
            grvDocentes.Columns["Legajo"].Width = 100;

            grvDocentes.Columns.Add("CuotaAlDia", "CuotaAlDia");
            grvDocentes.Columns["CuotaAlDia"].Width = 100;

            grvDocentes.Columns.Add("Telefono", "Telefono");
            grvDocentes.Columns["Telefono"].Width = 100;

            grvDocentes.Columns.Add("Direccion", "Direccion");
            grvDocentes.Columns["Direccion"].Width = 100;

            grvDocentes.RowHeadersVisible = false;
            grvDocentes.AllowUserToAddRows = false;
            grvDocentes.AllowUserToDeleteRows = false;
            grvDocentes.EditMode = DataGridViewEditMode.EditProgrammatically;
            grvDocentes.MultiSelect = false;
            grvDocentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            LoadData();
            if (grvDocentes.Rows.Count > 0)
                grvDocentes.Rows[0].Selected = true;

            CheckBtnEnables();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            CheckCompleteForm();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            CheckCompleteForm();

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            CheckCompleteForm();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            CheckCompleteForm();
        }

        private void txtLegajo_TextChanged(object sender, EventArgs e)
        {

            CheckCompleteForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var idToDelete = int.Parse(grvDocentes.SelectedRows[0].Cells["Id"].Value.ToString());
            var alumnoToDelete = Form1.Context.Alumnos.First(x => x.Id == idToDelete);
            Form1.Context.Alumnos.Delete(alumnoToDelete);
            Form1.Context.SaveChange();
            LoadData();
        }



        private void CheckBtnEnables()
        {
            if (grvDocentes.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnActualizar.Enabled = true;
                txtNombre.Text = grvDocentes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtApellido.Text = grvDocentes.SelectedRows[0].Cells["Apellido"].Value.ToString();
                txtDireccion.Text = grvDocentes.SelectedRows[0].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = grvDocentes.SelectedRows[0].Cells["Telefono"].Value.ToString();
                chbAlDia.Checked = bool.Parse(grvDocentes.SelectedRows[0].Cells["CuotaAlDia"].Value.ToString());
                txtLegajo.Text = grvDocentes.SelectedRows[0].Cells["Legajo"].Value.ToString();
            }
            else
            {
                btnEliminar.Enabled = false;
                btnActualizar.Enabled = false;
            }
        }

        private void grvDocentes_SelectionChanged(object sender, EventArgs e)
        {
            CheckBtnEnables();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            var idToDelete = int.Parse(grvDocentes.SelectedRows[0].Cells["Id"].Value.ToString());
            var alumnoToUpdate = Form1.Context.Alumnos.First(x => x.Id == idToDelete);
            alumnoToUpdate.Nombre = txtNombre.Text;
            alumnoToUpdate.Apellido = txtApellido.Text;
            alumnoToUpdate.Direccion = txtDireccion.Text;
            alumnoToUpdate.Telefono = txtTelefono.Text;
            alumnoToUpdate.CuotaAlDia = chbAlDia.Checked;
            alumnoToUpdate.Legajo = txtLegajo.Text;
            Form1.Context.Alumnos.Update(alumnoToUpdate);
            Form1.Context.SaveChange();
            LoadData();
        }


    }
}