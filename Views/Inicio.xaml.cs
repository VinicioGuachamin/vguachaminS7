using Newtonsoft.Json;
using System.Collections.ObjectModel;
using vguachaminS7.Models;

namespace vguachaminS7.Views;

public partial class Inicio : ContentPage
{
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estudiante;

    public Inicio()
    {
        InitializeComponent();
        Obtener();
    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync("https://solinteg360.com/moviles/post.php");
        List<Estudiante> mostrarEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estudiante = new ObservableCollection<Estudiante>(mostrarEstudiante);
        listaEstudiante.ItemsSource = estudiante;
    }

    private void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddEstudiante());

    }

    private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new UpdateDeleteEstudiante(objEstudiante));
    }
}