using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Client firstClient = new Client("John", "Snow", 123569);
            Account firstClientAccount = new Account(firstClient, AccountType.Gold);

            Console.WriteLine(firstClient.FirstName);
            Console.WriteLine(firstClient.LastName);
            Console.WriteLine(firstClient.CreditCard);

            firstClientAccount.Put(10000);

            Console.WriteLine(firstClientAccount.Sum);
            Console.WriteLine(firstClientAccount.BonusPoints);
        }
    }
}
