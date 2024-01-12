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
                    Nombre = "Hamburguesa Vegana Zen de Campo",
                    Descripcion = "Una opción reconfortante con aguacate cremoso, vegetales frescos y una suave salsa de cilantro.",
                    Precio = 5.99f,
                    Imagen = "foto_ham.png"
                },
                new Product
                {
                    Nombre = "Crocante Pollo Dorado Especiado",
                    Descripcion = "Trozos de pollo sazonados y empanizados, fritos con textura crujiente por fuera y suave por dentro.",
                    Precio = 8.49f,
                    Imagen = "prod_pollo.jpg",

                },
                new Product
                {
                    Nombre = "Ninja Crujiente de Papas Doradas",
                    Descripcion = "Rodajas de papas finamente cortadas y fritas con una textura dorada y crujiente por fuera.",
                    Precio = 3.99f,
                    Imagen = "foto_papas_dos.png"
                },
                new Product
                {
                    Nombre = "Festín Italiano de Pizza Mediana",
                    Descripcion = "Masa suave cubierta con salsa de tomate, queso mozzarella y una selección de tus ingredientes.",
                    Precio = 10.99f,
                    Imagen = "foto_pizza.png"
                },
                new Product
                {
                    Nombre = "Ninja Súper Grilled Hot-Dog",
                    Descripcion = "Salchicha a la parrilla en pan suave y ligeramente tostado, incluye mostaza, kétchup y cebolla.",
                    Precio = 4.75f,
                    Imagen = "foto_hotdog.png"
                }

            };
        }
    }
}
