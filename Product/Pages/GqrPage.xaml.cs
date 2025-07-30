namespace Product.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Product.Pages.CheckoutPage());
    }
}