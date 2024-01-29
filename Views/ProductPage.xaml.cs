//using static Android.Content.ClipData;

using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Newtonsoft.Json;
using ProyectoMovilP2.Data;
using ProyectoMovilP2.Models;
using System.Text;
namespace ProyectoMovilP2.Views;


public partial class ProductPage : ContentPage

{
    int cont = 1;
    public ProductPage(Product selectedProduct)
    {
        InitializeComponent();
        BindingContext = selectedProduct;
    }

    

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
                //guardar en base de datos
                using (var db = new OrdersDbContext())
                {
                    db.Orders.Add(order);
                    await db.SaveChangesAsync();
                }

                bool guardarTxt = await DisplayAlert("Éxito", "Orden exitosa. ¿Desea guardar una copia en un archivo .txt?", "Sí", "No");


                if (guardarTxt)
                {
                    string orderDetails = $"Fecha de Pedido: {DateTime.Now}\n"; // Agregar la fecha y hora de pedido
                    orderDetails += $"Producto: {product.Nombre}\nDescripción: {product.Descripcion}\nPrecio: {product.Precio:C}\n";
                    orderDetails += $"Indicaciones Especiales: {TextEditor.Text}\n";
                    orderDetails += $"Papas Extra: {product.ExtraPapas}\nGaseosa: {product.ConGaseosa}\nSalsas Extra: {product.ExtraSalsas}\n";

                    //declarar ruta del archivo
                    string downloadsFolderPath = "/storage/emulated/0/Download";
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileName = $"Orden_{timestamp}.txt";

                    string filePath = Path.Combine(downloadsFolderPath, fileName);

                    //guardar archivo .txt
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        await writer.WriteAsync(orderDetails);
                    }

                    await DisplayAlert("Éxito", "Orden guardada en su carpeta 'Download'", "Aceptar");

                    TextEditor.Text = string.Empty; 

                    // Establecer los valores de los checkboxes en falso
                    ExtraPapasCheckBox.IsChecked = false; 
                    ConGaseosaCheckBox.IsChecked = false; 
                    ExtraSalsasCheckBox.IsChecked = false;
                }

                await Shell.Current.GoToAsync("..");
            }

            //error de actualizar base de datos
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine(ex.InnerException?.Message);
            }

            //errores extra
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al guardar la orden: {ex.Message}", "Aceptar");
            }

            cont++;
        }
    }

    private async void BtnApi(object sender, EventArgs e)
    {

        try
        {
            string busqueda = null;
            if (BindingContext is Product product)
            {

                switch (product.Nombre)
                {
                    case "Hamburguesa Vegana Zen de Campo":
                        busqueda = "hamburger";
                        break;
                    case "Crocante Pollo Dorado Especiado":
                        busqueda = "chicken";
                        break;
                    case "Ninja Crujiente de Papas Doradas":
                        busqueda = "potato";
                        break;
                    case "Festín Italiano de Pizza Mediana":
                        busqueda = "pizza";
                        break;
                    case "Ninja Súper Grilled Hot-Dog":
                        busqueda = "hotdog";
                        break;
                    default:
                        await Application.Current.MainPage.DisplayAlert("Error", "Nombre de producto incorrecto", "Aceptar");
                        break;
                }
            }
            string apiKey = "76b440c795f4c1fdcd013260d9f7e5e9";
            string appId = "318c8b53";




            string apiUrl = $"https://api.edamam.com/api/food-database/v2/parser?app_id={appId}&app_key={apiKey}&ingr={busqueda}";

            using (HttpClient client = new HttpClient())
            {

                //client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    var apiData = JsonConvert.DeserializeObject<ModelApi.Rootobject>(jsonResponse);


                    StringBuilder nutrientInfo = new StringBuilder();

                    foreach (var parsed in apiData.parsed)
                    {
                        nutrientInfo.AppendLine(parsed.food.label);
                        nutrientInfo.AppendLine($"Calories: {parsed.food.nutrients.ENERC_KCAL}");
                        nutrientInfo.AppendLine($"Protein: {parsed.food.nutrients.PROCNT}");
                        nutrientInfo.AppendLine($"Fat: {parsed.food.nutrients.FAT}");
                        nutrientInfo.AppendLine($"Carbs: {parsed.food.nutrients.CHOCDF}");
                        nutrientInfo.AppendLine($"Fiber: {parsed.food.nutrients.FIBTG}");
                        nutrientInfo.AppendLine();
                    }

                    datos.Text = nutrientInfo.ToString();



                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}