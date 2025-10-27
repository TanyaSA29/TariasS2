namespace TariasS2.Views;

public partial class vRegistro : ContentPage
{
    public vRegistro()
    {
        InitializeComponent();
    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        string usuarioRegistro = txtUsuarioRegistro.Text;
        string passwordRegistro = txtContrasenaRegistro.Text;

        if (string.IsNullOrEmpty(usuarioRegistro) || string.IsNullOrEmpty(passwordRegistro))
        {
            await DisplayAlert("Error", "Debe ingresar usuario y contraseña.", "Aceptar");
            return;
        }

        var userList = vLogin.users.ToList();
        var passList = vLogin.passwords.ToList();

        userList.Add(usuarioRegistro);
        passList.Add(passwordRegistro);

        vLogin.users = userList.ToArray();
        vLogin.passwords = passList.ToArray();

        await DisplayAlert("Registro Exitoso", $"Usuario {usuarioRegistro} registrado correctamente.", "Aceptar");

        await Navigation.PushAsync(new vLogin(usuarioRegistro, passwordRegistro));
    }
}