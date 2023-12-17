//using Microsoft.Maui.Controls.PlatformConfiguration;


using ProyectoMovilP2.Models;

namespace ProyectoMovilP2.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        BindingContext = new HomeM();


    }

    private async void Product_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Product selectedProduct)
        {

            await Shell.Current.Navigation.PushAsync(new ProductPage(selectedProduct));
        }
    }
}


