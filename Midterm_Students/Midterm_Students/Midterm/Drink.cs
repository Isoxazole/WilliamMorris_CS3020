using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Drink : Consumable
    {
        public int SizeInOunces { get; private set; }

        public Drink(string name, float price, int quantity, int calorieCount, int sizeInOunces, bool isVegetarian) : base(name, price, quantity, calorieCount, isVegetarian)
        {

            SizeInOunces = sizeInOunces;
        }

    }
}
