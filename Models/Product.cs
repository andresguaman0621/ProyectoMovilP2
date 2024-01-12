using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilP2.Models
{
    public class Product
    {
        public string Text { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public bool ExtraPapas { get; set; } 
        public bool ConGaseosa { get; set; }
        public bool ExtraSalsas { get; set; } 
    }
}
