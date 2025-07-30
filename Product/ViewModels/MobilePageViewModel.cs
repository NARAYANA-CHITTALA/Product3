using Product.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.ViewModels
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial  class MobilePageViewModel : ObservableObject
    {
        private readonly MobileService _mobileService;
        public MobilePageViewModel(MobileService mobileService)
        {
            _mobileService = mobileService;
            Mobile = new(_mobileService.GetallMobiles());
        }
        public ObservableCollection<Pizza> Mobile{ get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchMobile(string searchTerm)
        {
            Mobile.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var mobile in _mobileService.SearchMobile(searchTerm))
            {
                Mobile.Add(mobile);

            }
            Searching = false;

        }
        [RelayCommand]
        private async Task GoToDetailsPage(Pizza mobile)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Pizza)] = mobile


            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }

    }
}
