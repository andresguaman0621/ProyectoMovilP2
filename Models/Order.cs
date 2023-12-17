using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilP2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string IndicacionesEspeciales { get; set; }
        public bool ExtraPapas { get; set; }
        public bool ConGaseosa { get; set; }
        public bool ExtraSalsas { get; set; }
    }
}
