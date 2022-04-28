﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Telefono { get; set; }
        public string CorreoDeRespaldo { get; set; }
        public string Contrasennia { get; set; }
        public string Cedula { get; set; }
        public bool Activo { get; set; }

        public UsuarioRol MiRol { get; set; }

        public Usuario()
        {
            MiRol = new UsuarioRol();
        }

        public bool Agregar()
        {
            bool R = false;

            //paso 1.6.1 y 1.6.2 
            //Conexion MiCnn3 = new Conexion();

            //Encriptador MiEncriptador = new Encriptador();

            //string PassWordEncriptado = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);

            //lista de parametros que se enviarán al SP
            MiCnn3.ListaParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn3.ListaParametros.Add(new SqlParameter("@Email", this.NombreUsuario));
            MiCnn3.ListaParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn3.ListaParametros.Add(new SqlParameter("@CorreoRespaldo", this.CorreoDeRespaldo));
            MiCnn3.ListaParametros.Add(new SqlParameter("@Contrasennia", PassWordEncriptado));
            MiCnn3.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn3.ListaParametros.Add(new SqlParameter("@IdRolUsuario", this.MiRol.IDUsuarioRol));

            //paso 1.6.3 y 1.6.4
            int Resultado = MiCnn3.EjecutarUpdateDeleteInsert("SpUsuariosAgregar");

            //paso 1.6.5
            if (Resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Editar()
        {
            bool R = false;

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            //paso 1.3.1 y 1.3.2 
            //Conexion MiCnn = new Conexion();

            //se deben agregar los params si el SP los requiere
            // MiCnn.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));

            //paso 1.3.4
            //DataTable Consulta = MiCnn.EjecutarSelect("SpUsuariosConsultarPorCedula");

            //paso 1.3.5
            if (Consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;

            //paso 1.4.1 y 1.4.2 
            // Conexion MiCnn2 = new Conexion();

            //se deben agregar los params si el SP los requiere
            //MiCnn2.ListaParametros.Add(new SqlParameter("@Email", this.NombreUsuario));

            //paso 1.4.4
            // DataTable Consulta = MiCnn2.EjecutarSelect("SpUsuariosConsultarPorEmail");

            //paso 1.4.5
            if (Consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;

        }

        public bool ConsultarPorID()
        {
            bool R = false;

            return R;

        }

        public Usuario ConsultarPorID(int pIdUsuario)
        {
            Usuario R = new Usuario();

            //Conexion MyCnn = new Conexion();

            // MyCnn.ListaParametros.Add(new SqlParameter("@id", pIdUsuario));

            DataTable DatosDeUsuario = new DataTable();

            //DatosDeUsuario = MyCnn.EjecutarSelect("SpUsuariosConsultarPorID");

            if (DatosDeUsuario != null && DatosDeUsuario.Rows.Count > 0)
            {
                DataRow MisDatos = DatosDeUsuario.Rows[0];

                R.IDUsuario = Convert.ToInt32(MisDatos["IDUsuario"]);
                R.Nombre = Convert.ToString(MisDatos["Nombre"]);
                R.NombreUsuario = Convert.ToString(MisDatos["NombreUsuario"]);
                R.Cedula = Convert.ToString(MisDatos["Cedula"]);
                R.Telefono = Convert.ToString(MisDatos["Telefono"]);
                R.CorreoDeRespaldo = Convert.ToString(MisDatos["CorreoDeRespaldo"]);
                R.Contrasennia = Convert.ToString(MisDatos["Contrasennia"]);

                R.Activo = Convert.ToBoolean(MisDatos["Activo"]);

                R.MiRol.IDUsuarioRol = Convert.ToInt32(MisDatos["IDUsuarioRol"]);
                R.MiRol.Rol = Convert.ToString(MisDatos["Rol"]);
            }

            return R;

        }


        public DataTable ListarActivos()
        {
            DataTable R = new DataTable();

            //paso 2.1 y 2.2 
            //Conexion MiCnn = new Conexion();

            //paso 2.3 y 2.4
            //R = MiCnn.EjecutarSelect("SpUsuariosListarActivos");

            return R;
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            return R;
        }
    }
}
