using Product.Models;

namespace Product.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new
            List<Pizza>()
        {
            new Pizza
            {
                Name = "Laptops",
                Image = "lappy.jpg",
                Price = 1025.1
            },
            new Pizza
            {
                Name = "Telivisions",
                Image = "tv.jpg",
                Price = 766.5
            },
            new Pizza
            {
                Name = "Watches",
                Image = "watches.jpg",
                Price = 199.5
            },
            new Pizza
            {
                Name = "Mobiles",
                Image = "mobile.jpg",
                Price = 999.45
            },
             new Pizza
            {
                Name = "Earpods",
                Image = "ep.jpg",
                Price = 295.1
            },
            new Pizza
            {
                Name = "Washing Machine",
                Image = "whm.jpg",
                Price = 652.5
            },
            new Pizza
            {
                Name = "Refrigirators",
                Image = "fdg.png",
                Price = 899.5
            },
            new Pizza
            {
                Name = "Sound Bars",
                Image = "sb.jpg",
                Price = 499.45
            }
        };
        public IEnumerable<Pizza> GetallPizzas() => _pizzas;
        public IEnumerable<Pizza> GetPopularPizzas(int count = 8) => _pizzas.OrderBy(p=> Guid.NewGuid())
            .Take(count);

        public IEnumerable<Pizza> SearchPizzas(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _pizzas
            : _pizzas.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        


        
    }
}
      

        



    

    


