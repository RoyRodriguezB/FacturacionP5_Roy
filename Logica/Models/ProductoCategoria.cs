using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class ProductoCategoria
    {
        public int IDProductoCategoria { get; set; }
        public string Categoria { get; set; }

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            //TODO: Escribir código para llenar R con los
            //datos necesarios

            return R;
        }
    }
}
