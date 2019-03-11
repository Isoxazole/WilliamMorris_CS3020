using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    abstract class VendingMachineOption
    {
        public string Name { get; private set; }
        public float Price { get; private set; }
        public int Quantity { get; private set; }

        public VendingMachineOption(string name, float price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
