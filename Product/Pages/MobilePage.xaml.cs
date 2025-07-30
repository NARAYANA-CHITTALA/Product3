namespace Product.Pages;

public partial class MobilePage : ContentPage
{
	private readonly MobilePageViewModel _viewModel;

    public MobilePage()
    {
    }

    public MobilePage(MobilePageViewModel mobilePageViewModel)
	{
		InitializeComponent();
		_viewModel = mobilePageViewModel;
		BindingContext = _viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _viewModel.SearchMobileCommand.Execute(null);
        }



    }
}