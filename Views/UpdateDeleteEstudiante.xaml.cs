using System.Net;
using vguachaminS7.Models;

namespace vguachaminS7.Views;

public partial class UpdateDeleteEstudiante : ContentPage
{
	public UpdateDeleteEstudiante(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;

            string url = "https://solinteg360.com/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            client.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }


    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;


            string url = "https://solinteg360.com/moviles/post.php?codigo=" + codigo;
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            client.UploadValues(url, "DELETE", parametros);
            Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}