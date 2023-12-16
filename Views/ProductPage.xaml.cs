//using static Android.Content.ClipData;
namespace ProyectoMovilP2.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ProductPage : ContentPage

{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public ProductPage()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void Button_Pedir(object sender, EventArgs e)
    {

        if (BindingContext is Models.Product note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");

    }

    private void LoadNote(string fileName)
    {
        Models.Product noteModel = new Models.Product();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
            noteModel.Filename = File.ReadAllText(fileName);
            noteModel.Nombre = File.ReadAllText(fileName);
            noteModel.Descripcion = File.ReadAllText(fileName);
            noteModel.Precio = float.TryParse(File.ReadAllText(fileName), out float precio) ? precio : 0.00f;
            noteModel.Imagen = File.ReadAllText(fileName);

        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }
}