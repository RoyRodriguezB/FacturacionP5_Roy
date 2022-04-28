using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    class FacturaDetalle
    {
        public string DescripcionItem { get; set; }
        public decimal CantidadFactura { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal SubTotalLinea { get; set; }
        public decimal ImpuestosLinea { get; set; }
        public decimal TotalLinea { get; set; }

        //atrib compuesto
        Producto MiProducto { get; set; }

        public FacturaDetalle()
        {
            MiProducto = new Producto();
        }
    }
}
