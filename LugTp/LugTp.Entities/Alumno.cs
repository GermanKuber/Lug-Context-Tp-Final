﻿namespace LugTp.UI.Entities
{
    public class Alumno : Persona
    {
        public string Legajo { get; set; }
        public bool CuotaAlDia { get; set; }


        public Alumno(string nombre, string apellido, string direccion, string telefono, string legajo, bool cuotaAlDia) : base(nombre, apellido, direccion, telefono)
        {
            Legajo = legajo;
            CuotaAlDia = cuotaAlDia;
        }
    }
}