


using Product.Services;
using System.Reflection.Metadata;

namespace Product.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
        [RelayCommand]
        private async Task GoToAllPizzasPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllPizzaViewModel.FromSearch)] = fromSearch


            };
            await Shell.Current.GoToAsync(nameof(AllPizzasPage), animate : true,parameters);
        }
        //[RelayCommand]
        //private async Task GoToDetailsPage(Pizza pizza)
        //{
        //    var parameters = new Dictionary<string, object>
        //    {
        //        [nameof(DetailsViewModel.Pizza)] = pizza


        //    };
        //    await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        //}
        //[RelayCommand]
        //private async Task GoToMobilePage(Pizza mobile)
        //{
        //    await Shell.Current.GoToAsync(nameof(MobilePage), animate: true);

        //}
        [RelayCommand]
        private async Task GoToCategoryPage(Pizza pizza)
        {
          

            await Shell.Current.GoToAsync(nameof(MobilePage), animate: true );
        }
    }
}
