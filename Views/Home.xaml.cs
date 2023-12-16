using Microsoft.Maui.Controls.PlatformConfiguration;


namespace ProyectoMovilP2.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        BindingContext = new Models.HomeM();


    }




    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProductPage));


    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Product)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(ProductPage)}?{nameof(ProductPage.ItemId)}={note.Filename}");

            // Unselect the UI
            //notesCollection.SelectedItem = null;
        }
    }

    private async void Product_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Product selectedProduct)
        {
            await Shell.Current.GoToAsync($"{nameof(ProductPage)}?{nameof(ProductPage.ItemId)}={selectedProduct.Filename}");
        }
    }
}


