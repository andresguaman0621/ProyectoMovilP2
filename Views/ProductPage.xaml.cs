//using static Android.Content.ClipData;

using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls.PlatformConfiguration;
using ProyectoMovilP2.Data;
using ProyectoMovilP2.Models;
namespace ProyectoMovilP2.Views;


public partial class ProductPage : ContentPage

{
    int cont = 1;
    public ProductPage(Product selectedProduct)
    {
        InitializeComponent();
        BindingContext = selectedProduct;
    }

    //private async void PedirButton_Clicked(object sender, EventArgs e)
    //{
    //    if (BindingContext is Product product)
    //    {
    //        string orderDetails = $"Fecha de Pedido: {DateTime.Now}\n"; // Agregar la fecha y hora de pedido
    //        orderDetails += $"Producto: {product.Nombre}\nDescripción: {product.Descripcion}\nPrecio: {product.Precio:C}\n";
    //        orderDetails += $"Indicaciones Especiales: {TextEditor.Text}\n";
    //        orderDetails += $"Papas Extra: {product.ExtraPapas}\nGaseosa: {product.ConGaseosa}\nSalsas Extra: {product.ExtraSalsas}\n";

    //        try
    //        {

    //            string downloadsFolderPath="/storage/emulated/0/Download";

    //            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
    //            string fileName = $"Orden_{timestamp}.txt";

    //            // Ruta completa del archivo en la carpeta de descargas
    //            string filePath = Path.Combine(downloadsFolderPath, fileName);

    //            // Escritura de los datos en el archivo
    //            using (StreamWriter writer = File.CreateText(filePath))
    //            {
    //                await writer.WriteAsync(orderDetails);
    //            }

    //            // Muestra el DisplayAlert si se ha guardado correctamente
    //            await DisplayAlert("Éxito", "Orden exitosa", "Aceptar");
    //        }
    //        catch (Exception ex)
    //        {
    //            // Manejo de errores en caso de fallo al guardar el archivo
    //            await DisplayAlert("Error", $"Ocurrió un error al guardar la orden: {ex.Message}", "Aceptar");
    //        }
    //    }
    //}

    private async void PedirButton_Clicked(object sender, EventArgs e)
    {

        if (BindingContext is Product product)
        {
            var order = new Order
            {
                Id = cont,
                FechaPedido = DateTime.Now,
                Producto = product.Nombre,
                Descripcion = product.Descripcion,
                Precio = product.Precio,
                IndicacionesEspeciales = TextEditor.Text,
                ExtraPapas = product.ExtraPapas,
                ConGaseosa = product.ConGaseosa,
                ExtraSalsas = product.ExtraSalsas
            };

            try
            {
                using (var db = new OrdersDbContext())
                {
                    db.Orders.Add(order);
                    await db.SaveChangesAsync();
                }
                
                await DisplayAlert("Éxito", "Orden exitosa", "Aceptar");
                await Shell.Current.GoToAsync("..");
            }

            catch (DbUpdateException ex)
            {
                // Manejo de excepciones aquí
                Console.WriteLine(ex.InnerException?.Message);
            }

            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al guardar la orden: {ex.Message}", "Aceptar");
            }
            cont++;
        }

    }
}