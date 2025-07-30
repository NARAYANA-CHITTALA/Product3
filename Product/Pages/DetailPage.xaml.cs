#if IOS
using UIKit;
#endif
using CommunityToolkit.Maui.Core;

namespace Product.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;
	public DetailPage(DetailsViewModel detailsViewModel)
	{
		_detailsViewModel = detailsViewModel;
		InitializeComponent();
		BindingContext = _detailsViewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
		var Bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;

		Bottombox.Margin = new Thickness(-1, 0, -1, (Bottom + 1) * -1);
#endif
    }

    async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
        {
            StatusBarColor = Colors.DarkGoldenrod,
            StatusBarStyle = StatusBarStyle.LightContent
        });
    }

   
}