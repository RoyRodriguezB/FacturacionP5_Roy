using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal CantidadEnStock { get; set; }
        public decimal PrecioUnitario { get; set; }

        //atributos compuestos
        UnidadMedida MiUnidadMedida { get; set; }
        ProductoCategoria MiCategoria { get; set; }
        Impuesto MiImpuesto { get; set; }

        //contructor
        public Producto()
        {
            MiUnidadMedida = new UnidadMedida();
            MiCategoria = new ProductoCategoria();
            MiImpuesto = new Impuesto();
        }

        //funciones y métodos 
        public bool Agregar()
        {
            bool R = false;

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
        public bool ColsultarPorCodigoDeBarras()
        {
            bool R = false;

            return R;
        }
        public bool ConsultarPorID()
        {
            bool R = false;

            return R;
        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();


            return R;
        }
    }
}
