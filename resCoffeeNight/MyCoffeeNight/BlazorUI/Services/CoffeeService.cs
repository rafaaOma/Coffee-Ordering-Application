using BlazorUI.Models;
using System.Linq;
namespace BlazorUI.Services
{
    public class CoffeeService
    {
        private List<Coffee> CoffeeList = new()
        {
            new Coffee {
                    Id = 1,
                    Name = "Espresso",
                    Image = "/Espressoimage.jpg",
                    Icon = "/Espressoicon.png",
                    SmallPrice = 10,
                    MediumPrice = 12,
                    LargePrice = 14
                },
            new Coffee {
                    Id = 2,
                    Name = "Cappuccino",
                    Image = "/Cappuccinoimage.jpg",
                    Icon = "/Cappuccinoicon.png",
                    SmallPrice = 14,
                    MediumPrice = 16,
                    LargePrice = 18
                },
            new Coffee {
                    Id = 3,
                    Name = "V60",
                    Image = "/V60image.jpg",
                    Icon = "/V60icon.png",
                    SmallPrice = 18,
                    MediumPrice = 20,
                    LargePrice = 22
                },
            new Coffee {
                    Id = 4,
                    Name = "Mocha",
                    Image = "/Mochaimage.jpg",
                    Icon = "/Mochaicon.png",
                    SmallPrice = 18,
                    MediumPrice = 20,
                    LargePrice = 22
                }
            };
        public List<Coffee> GetAllCoffee()
        {
            return CoffeeList;
        }

        public Coffee? GetCoffeeById(int id)
        {
            return CoffeeList.FirstOrDefault(c => c.Id == id);
        }
    }
}