using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Models;

namespace Product.Services
{
    public class MobileService
    {
        private readonly static IEnumerable<Pizza> _mobile = new
            List<Pizza>()
        {
            new Pizza
            {
                Name = "Iphone 14",
                Image = "ph1.jpg",
                Price = 499.9

            },
            new Pizza
            {
                Name = "Iphone 14 Mini",
                Image = "ph10.png",
                Price = 399.9

            },
            new Pizza
            {
                Name = "Iphone 14 pro Max",
                Image = "ph2.jpg",
                Price = 999.9

            },
            new Pizza
            {
                Name = "Iphone 15",
                Image = "ph3.jpg",
                Price = 699.9

            },
            new Pizza
            {
                Name = "Iphone 15 Mini",
                Image = "ph4.jpg",
                Price = 599.9

            },
            new Pizza
            {
                Name = "Iphone 15 Pro Max",
                Image = "ph5.jpg",
                Price = 1599.9

            },
            new Pizza
            {
                Name = "S21 FE",
                Image = "ph6.png",
                Price = 549.9

            },
            new Pizza
            {
                Name = "S21 Ultra",
                Image = "ph7.jpg",
                Price = 959.9

            },
            new Pizza
            {
                Name = "S22 FE",
                Image = "ph8.png",
                Price = 749.9

            },
            new Pizza
            {
                Name = "S22 Ultra",
                Image = "ph9.jpg",
                Price = 1549.9

            },
            new Pizza
            {
                Name = "Pixel 8",
                Image = "ph11.jpg",
                Price = 2599.9

            }

        };
        public IEnumerable<Pizza> GetallMobiles() => _mobile;
        public IEnumerable<Pizza> GetPopularMobiles(int count = 8) => _mobile.OrderBy(p => Guid.NewGuid())
           .Take(count);

        public IEnumerable<Pizza> SearchMobile(string searchTerm) =>
          string.IsNullOrWhiteSpace(searchTerm)
          ? _mobile
          : _mobile.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));


    }
}
