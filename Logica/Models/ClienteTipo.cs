using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    class ClienteTipo
    {
        public int IDClienteTipo { get; set; }
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
