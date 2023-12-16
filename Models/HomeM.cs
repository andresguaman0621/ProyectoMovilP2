using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilP2.Models
{
    class HomeM
    {

        public ObservableCollection<Product> Products { get; set; }

        public HomeM()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Nombre = "Hamburguesa",
                    Descripcion = "Pan, lechuga, tomate, cebolla, queso carne, salsa",
                    Precio = 5.99f,
                    Imagen = "foto_ham.png"
                },
                new Product
                {
                    Nombre = "Pollo frito",
                    Descripcion = "Tres piezas de pollo frito con salsa especial",
                    Precio = 8.49f,
                    Imagen = "prod_pollo.jpg"
                },
                new Product
                {
                    Nombre = "Papas fritas",
                    Descripcion = "Porción de papas fritas mediana",
                    Precio = 3.99f,
                    Imagen = "foto_papas_dos.png"
                },
                new Product
                {
                    Nombre = "Pizza mediana",
                    Descripcion = "Pizza mediana con pepperoni y jamón",
                    Precio = 10.99f,
                    Imagen = "foto_pizza.png"
                },
                new Product
                {
                    Nombre = "Hot dog",
                    Descripcion = "Pan de hot dog con salchicha y salsas",
                    Precio = 4.75f,
                    Imagen = "foto_hotdog.png"
                }
            };
        }
    }
}
