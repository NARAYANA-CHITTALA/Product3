namespace Product.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

  

    private async void submit_Clicked(object sender, EventArgs e)
    {
        string username, password;

        username = ((Entry)this.FindByName("UsernameEntry")).Text;

        password = ((Entry)this.FindByName("PasswordEntry")).Text;
        if (username == "Team" && password == "1210")
        {
            await Navigation.PushAsync(new OrderDetails());
        }
        else
        {
             await DisplayAlert("Error", "Invalid Username or Password", "ok");
        }

    }
}
