using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CokeVendingMachine.Models
{
    public class DrinkRepository
    {
        public static List<Drink> _drinks;

        static DrinkRepository()
        {
            _drinks = new List<Drink>()
            {
                new Drink{ Id = 1, Name="Moloko Plus", Price=2.15M, Quantity=9},
                new Drink{ Id = 2, Name="Victory Gin", Price=1.25M, Quantity=5},
                new Drink{ Id = 3, Name="Vesper", Price=1.00M, Quantity=7},
                new Drink{ Id = 4, Name="Duff Beer", Price=3.35M, Quantity=3},
                new Drink{ Id = 5, Name="Screaming Viking", Price=0.95M, Quantity=6},
                new Drink{ Id = 6, Name="Blue Milk", Price=3.15M, Quantity=3},
                new Drink{ Id = 7, Name="Butter Beer", Price=2.85M, Quantity=4},
                new Drink{ Id = 8, Name="Ent-draught", Price=2.00M, Quantity=0},
                new Drink{ Id = 9, Name="Nuka-Cola", Price=3.45M, Quantity=4},
            };
        }

        public static List<Drink> GetAll()
        {
            return _drinks;
        }

        public static bool RequestPurchase(decimal amount,int itemNumber)
        {
            if ((_drinks.FirstOrDefault(d => d.Id == itemNumber).Price <= amount))
                return true;
            else
                return false;
        }

        public static Change MakePurchase(decimal amount, int itemNumber)
        {
            _drinks.FirstOrDefault(d => d.Id == itemNumber).Quantity = _drinks.FirstOrDefault(d => d.Id == itemNumber).Quantity - 1;
            return Change.MakeChange(amount, _drinks.FirstOrDefault(d => d.Id == itemNumber).Price);
        }
    }
}