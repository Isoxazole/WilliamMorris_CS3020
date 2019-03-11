using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class NonElectronic : VendingMachineOption
    {
        public bool ChokingHazard { get; private set; }
        public int AgeRequirement { get; private set; }

        public NonElectronic(string name, float price, int quantity, int ageRequirement, bool chokingHazard) : base(name, price, quantity)
        {
            ChokingHazard = chokingHazard;
            AgeRequirement = ageRequirement;
        }

    }
}
