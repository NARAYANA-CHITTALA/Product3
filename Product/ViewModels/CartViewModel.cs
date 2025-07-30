using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Pizza> CartItemRemoved;
        public event EventHandler<Pizza> CartItemUpdated;
        public event EventHandler CartCleared;

        public ObservableCollection<Pizza> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;
        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);
        [RelayCommand]
        private void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i => i.Name == pizza.Name);
            if (item is not null)
            {
                item.CartQuantity = pizza.CartQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            RecalculateTotalAmount();
        }
        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();
                CartItemRemoved?.Invoke(this, item);
                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}' removed from cart", () =>
                {

                    Items.Add(item);
                    RecalculateTotalAmount();
                    CartItemUpdated?.Invoke(this, item);
                }, "Undo", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }
        [RelayCommand]
        private async void ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you really want to clear the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);
                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();
            }
        }

    }
       





    
}

