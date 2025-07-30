using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.ViewModels
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartviewModel;
        public DetailsViewModel(CartViewModel cartViewModel) 
        {
            _cartviewModel = cartViewModel;
            _cartviewModel.CartCleared += OnCartCleared;
            _cartviewModel.CartItemRemoved += OnCartItemRemoved;
            _cartviewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void _cartviewModel_CartCleared(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCartCleared(object? sender, EventArgs e) => Pizza.CartQuantity = 0;
        private void OnCartItemRemoved(object? sender, Pizza p) => OnCartItemChanged(p, 0);
        private void OnCartItemUpdated(object? _, Pizza p) => OnCartItemChanged(p, p.CartQuantity);
        private void OnCartItemChanged(Pizza p, int quantity)
        {
            if(p.Name == Pizza.Name)
            {
                Pizza.CartQuantity = p.CartQuantity;
            }
        }
        
        [ObservableProperty]
        private Pizza _pizza;
        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
            _cartviewModel.UpdateCartItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                Pizza.CartQuantity--;
                _cartviewModel.UpdateCartItemCommand.Execute(Pizza);
            }
        }
        [RelayCommand]
        private async Task ViewCart()
        {
            if(Pizza.CartQuantity >0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Please select the quantity using the plus (+)button", ToastDuration.Short)
                    .Show();


            }
        }
        [RelayCommand]
        private async Task BuyNow()
        {
            if(Pizza.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
            }
            else
            {
                 await Toast.Make("Please select the quantity using the plus (+)button", ToastDuration.Short)
                    .Show();
            }
        }
        public void Dispose()
        {
            _cartviewModel.CartCleared -= OnCartCleared;
            _cartviewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartviewModel.CartItemUpdated -= OnCartItemUpdated;

        }
    }
}
