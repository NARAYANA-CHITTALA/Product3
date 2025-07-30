namespace Product.Pages;
using Product.Pages;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel _cartViewModel;
    public CartPage(CartViewModel cartViewModel)
	{
		_cartViewModel = cartViewModel;
		InitializeComponent();
		BindingContext = _cartViewModel;
	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AllPizzasPage));

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OrderDetails());
    }

    private void MenuFlyoutItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {

    }
}