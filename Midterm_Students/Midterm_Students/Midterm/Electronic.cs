using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public enum Genre { Action, Shooter, Puzzle, Story }

    class Electronic : VendingMachineOption
    {
        public bool BatteriesIncluded { get; private set; }
        public Genre Genre { get; private set; }
        public int AgeRequirement { get; private set; }

        public Electronic(string name, float price, int quantity, int ageRequirement, bool batteriesIncluded, Genre genre) : base(name, price, quantity)
        {
            BatteriesIncluded = batteriesIncluded;
            Genre = genre;
            AgeRequirement = ageRequirement;
        }

    }
}
