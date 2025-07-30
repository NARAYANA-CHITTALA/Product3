using System.ComponentModel.DataAnnotations;
namespace Product.Pages;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MobilePage)}");
    }
}