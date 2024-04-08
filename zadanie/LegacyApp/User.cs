using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; set; }

        public bool CreditLimitChanges()
        {
            Console.WriteLine(Client.GetType().Name);
            Console.WriteLine(Client.GetType());
            if (Client.GetType().Name == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (Client.GetType().Name == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    creditLimit = creditLimit * 2;
                    CreditLimit = creditLimit;
                }
            }
            else
            {
                HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    CreditLimit = creditLimit;
                }
            }

            if (HasCreditLimit && CreditLimit < 500)
            {
                return false;
            }

            return true;
        }
    }
}
