using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Consumable :VendingMachineOption
    {
        public int CalorieCount { get; private set; }
        public bool IsVegetarian { get; private set; }


        public Consumable(string name, float price, int quantity, int calorieCount, bool isVegetarian) : base(name, price, quantity)
        {
            CalorieCount = calorieCount;
            IsVegetarian = isVegetarian;
        }

    }
}
