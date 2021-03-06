﻿using System;
using System.Windows.Forms;
using LugTp.Data;

namespace LugTp.UI
{
    public partial class Form1 : Form
    {
        public static ContextLug Context { get; set; }    = new ContextLug();
        public Form1()
        {
            InitializeComponent();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docentesForm = new Docentes();
            docentesForm.MdiParent = this;
            docentesForm.MinimizeBox = false;
            docentesForm.MaximizeBox = false;
            docentesForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docentesForm = new AlumnosForm();
            docentesForm.MdiParent = this;
            docentesForm.MinimizeBox = false;
            docentesForm.MaximizeBox = false;
            docentesForm.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docentesForm = new CursoForm();
            docentesForm.MdiParent = this;
            docentesForm.MinimizeBox = false;
            docentesForm.MaximizeBox = false;
            docentesForm.Show();
        }
    }
}
