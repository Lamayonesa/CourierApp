namespace MiAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Login(object sender, EventArgs e)
    {
        string usuario = UsuarioEntry.Text?.Trim() ?? "";
        string contraseña = PasswordEntry.Text ?? "";

        if (usuario == "admin" && contraseña == "1234")
        {
            MensajeLabel.Text = "";

            await DisplayAlertAsync(
                "Éxito",
                "Has iniciado sesion correctamente.",
                "OK");

            await Navigation.PushAsync(new DashboardUser());
        }
        else
        {
            MensajeLabel.Text = "Usuario o contraseña incorrectos.";
        }
    }
}
