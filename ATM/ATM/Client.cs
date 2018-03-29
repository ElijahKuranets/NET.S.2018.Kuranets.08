using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreditCard { get; set; }


        public Client(string firstName, string lastName, int creditCard)
        {
            FirstName = firstName;
            LastName = lastName;
            CreditCard = creditCard;
        }

    }
}
