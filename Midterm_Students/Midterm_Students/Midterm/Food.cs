using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Food : Consumable
    {
        public float Consistency { get; private set; }
        public int ScovilleScale { get; private set; }

        public Food(string name, float price, int quantity, int calorieCount, float consistency, int scovilleScale, bool isVegetarian) : base(name, price, quantity, calorieCount, isVegetarian)
        {
            Consistency = consistency;
            ScovilleScale = scovilleScale;

        }
    }
}
