namespace TariasS2.Views;

public partial class vLogin : ContentPage
{
    public static string[] users = { "Carlos", "Ana", "Jose" };
    public static string[] passwords = { "carlos123", "ana123", "jose123" };

    public vLogin()
    {
        InitializeComponent();
    }

    public vLogin(string usuarioresgistro, string passwordregistro)
    {
        InitializeComponent();
        // Agregar usuario recién registrado
        if (!string.IsNullOrEmpty(usuarioresgistro) && !string.IsNullOrEmpty(passwordregistro))
        {
            var userList = users.ToList();
            var passList = passwords.ToList();

            userList.Add(usuarioresgistro);
            passList.Add(passwordregistro);

            users = userList.ToArray();
            passwords = passList.ToArray();
        }
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        string usuarioIngreso = txtUsuario.Text;
        string passwordIngreso = txtContrasena.Text;

        // Validar campos vacíos
        if (string.IsNullOrEmpty(usuarioIngreso) || string.IsNullOrEmpty(passwordIngreso))
        {
            await DisplayAlert("Error", "Debe ingresar usuario y contraseña.", "Aceptar");
            return;
        }

        bool accesoConcedido = false;

        for (int i = 0; i < users.Length; i++)
        {
            if (usuarioIngreso == users[i] && passwordIngreso == passwords[i])
            {
                accesoConcedido = true;
                break;
            }
        }

        if (accesoConcedido)
        {
            await DisplayAlert("Bienvenido", $"¡Hola {usuarioIngreso}!", "Aceptar");
            await Navigation.PushAsync(new vCalificaciones());
        }
        else
        {
            await DisplayAlert("Error de autenticación", "Usuario o contraseña incorrectos.", "Aceptar");
        }
    }

    private void btnRegistrarse_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vRegistro());
    }
}