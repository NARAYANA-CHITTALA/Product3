using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.ViewModels
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial class CategoryPageViewModel : ObservableObject
    {
        public CategoryPageViewModel()
        {
        }
        [ObservableProperty]
        private Pizza _pizza;
    }
}
