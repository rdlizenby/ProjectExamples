using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CokeVendingMachine.Models
{
    public class Change
    {
        public int quarters { get; set; }
        public int dimes { get; set; }
        public int nickels { get; set; }
        public int pennies { get; set; }

        public static Change MakeChange(decimal amount, decimal price)
        {
            Change change = new Change();
            decimal remaining = amount - price;
            decimal result = remaining / 0.25m;
            change.quarters = Convert.ToInt32(Math.Floor(result));
            result = (remaining - change.quarters * 0.25m) / 0.1m;
            change.dimes = Convert.ToInt32(Math.Floor(result));
            result = (remaining - change.dimes * 0.10m - change.quarters*0.25m) / 0.05m;
            change.nickels = Convert.ToInt32(Math.Floor(result));
            change.pennies = Convert.ToInt32(remaining - change.dimes * 0.10m - change.quarters * 0.25m - change.nickels * 0.05m);

            return change;
        }
    }
}