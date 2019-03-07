using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProblems
{
    public class PhoneBookEntry
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get { return FirstName + " " + LastName; } }

        public string Address { get { return Street + " " + City + ", " + State + " " + ZipCode.ToString(); } }

        public PhoneBookEntry(string firstName, string lastName, string street = "", string city = "", string state = "", string zipCode = "", string phoneNumber = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = (state.ToUpper()).Substring(0, 2);
            ZipCode = zipCode;

            /// Strip phone number of extraneous characters
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!(char.IsDigit(phoneNumber[i])))
                {
                    phoneNumber = phoneNumber.Remove(i, 1);
                    i--;
                }
            }

            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nAddress: " + Address + "\nPhone Number: " + PhoneNumber + "\n";
        }
    }
}
