//using static Android.Content.ClipData;
using ProyectoMovilP2.Models;

namespace ProyectoMovilP2.Views;


public partial class ProductPage : ContentPage

{
    public ProductPage(Product selectedProduct)
    {
        InitializeComponent();
        BindingContext = selectedProduct;
    }

    private async void PedirButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            string orderDetails = $"Fecha de Pedido: {DateTime.Now}\n"; // Agregar la fecha y hora de pedido
            orderDetails += $"Producto: {product.Nombre}\nDescripción: {product.Descripcion}\nPrecio: {product.Precio:C}\n";
            orderDetails += $"Indicaciones Especiales: {TextEditor.Text}\n";
            orderDetails += $"Papas Extra: {product.ExtraPapas}\nGaseosa: {product.ConGaseosa}\nSalsas Extra: {product.ExtraSalsas}\n";


            try
            {
                //string downloadsFolderPath = Path.Combine(FileSystem.AppDataDirectory, "Download");
                string downloadsFolderPath = "/storage/emulated/0/Download";

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"Orden_{timestamp}.txt";

                // Ruta completa del archivo en la carpeta de descargas
                string filePath = Path.Combine(downloadsFolderPath, fileName);

                // Escritura de los datos en el archivo
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    await writer.WriteAsync(orderDetails);
                }

                // Muestra el DisplayAlert si se ha guardado correctamente
                await DisplayAlert("Éxito", "Orden exitosa", "Aceptar");
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de fallo al guardar el archivo
                await DisplayAlert("Error", $"Ocurrió un error al guardar la orden: {ex.Message}", "Aceptar");
            }
        }
    }
}