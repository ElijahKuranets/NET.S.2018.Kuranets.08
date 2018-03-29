using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public enum AccountType
    {
        Base = 1, Silver, Gold, Platinum
    }
    public sealed class Account
    {
        private int sum;
        private int bonusPoints;


        public Account(Client client, AccountType accountType = AccountType.Gold)
        {
            AccountClient = client ?? throw new ArgumentNullException(nameof(client)); 
            AccountNumber = client.CreditCard;
            Type = accountType;
        }

        public Client AccountClient { get; }

        public int AccountNumber { get; }

        public AccountType Type { get; private set; }

        public bool Activity { get; private set; } = true;

        public int Sum
        {
            get { return sum; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException($"{nameof(sum)} < 0");
                }
                else { sum = value; }
            }
        }

        public int BonusPoints
        {
            get { return bonusPoints; }
            private set
            {
                if (value < 0)
                {
                    bonusPoints = 0;
                }
                else
                {
                    bonusPoints = value;
                }
            }
        }

        public void Put(int amount)
        {
            if (!Activity)
            {
                throw new InvalidOperationException($"{AccountNumber} is closed!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} < 0");
            }
            else
            {
                BonusPointsUp(amount);
                Sum += amount;
            }
        }

        public void Withdraw(int amount)
        {
            if (!Activity)
            {
                throw new InvalidOperationException($"{AccountNumber} is closed!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} < 0");
            }
            else
            {
                BonusPointsDown(amount);
                Sum -= amount;
            }
        }

        public void CloseAccount()
        {
            if (Sum !=0)
            {
                throw new InvalidOperationException($"{ AccountNumber} can't be closed!");
            }
            else
            {
                Activity = !Activity;
            }
        }

        private void BonusPointsUp(int amount)
        {
            BonusPoints = BonusPoints + (int)(((sum * (int)Type) + (amount * (int)Type)) * 0.05);
        }

        private void BonusPointsDown(int amount)
        {
            BonusPoints = BonusPoints - (int)(((sum * (int)Type) + (amount * (int)Type)) * 0.05);
        }

       
    }
}
