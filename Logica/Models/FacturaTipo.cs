using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    class FacturaTipo
    {

        //primero se escriben los atributos simples. 
        //luego los atributos compuestos, después las operaciones (métodos y funciones) 
        // constructor si es necesario. 

        //1. Atributos

        // un atributo con su respectivo set y get
        private int iDFacturaTipo;
        public int IDFacturaTipo
        {
            get { return iDFacturaTipo; }
            set { iDFacturaTipo = value; }
        }

        //Otra opción para escribir una propiedad es por medio de la forma simplificada de c#
        public string Tipo { get; set; }

        

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //TODO: Escribir código para llenar R con los
            //datos necesarios

            return R;
        }

    }
}
