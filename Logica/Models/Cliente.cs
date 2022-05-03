using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        //atributos compuestos
        public ClienteTipo MiTipo { get; set; }

        //constructor de la clase para instanciar el atributo compuesto simple
        public Cliente()
        {
            //dentro de este ctor instanciamos los objetos compuestos
            MiTipo = new ClienteTipo();

        }

        public bool Agregar(string pNombre, string pCedula, string pTelefono = "", string pEmail = "")
        {
            bool R = false;

            //cuando se usa esta forma el paso de valores se realiza por acá. 
            Nombre = pNombre;
            Cedula = pCedula;
            Telefono = pTelefono;
            Email = pEmail;

            //TODO: ejecutar el SP para el insert en tabla de cliente

            return R;
        }

        public bool Editar(int pIDCliente, string pNombre, string pCedula, string pTelefono = "", string pEmail = "")
        {
            bool R = false;



            return R;
        }

        public bool Eliminar(int pIDCliente)
        {
            bool R = false;



            return R;
        }

        public bool ConsultarPorCedula(string pCedula)
        {
            bool R = false;



            return R;

        }

        public bool ConsultarPorID(int pIDCliente)
        {
            bool R = false;



            return R;

        }

        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            DataTable R = new DataTable();

            Conexion MyCnn = new Conexion();
            //parametro de almacenamiento almacenado semana 13
            MyCnn.ListaParametros.Add(new SqlParameter("@filtro", Filtro));

            R = MyCnn.EjecutarSelect("SpClientesListar");

            return R;
        }

    }
}
