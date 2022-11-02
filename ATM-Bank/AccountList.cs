namespace ATM_Bank
{
    public class AccountList
    {
        public List<Account> accounts { get; set; } = new List<Account>();
        public void AccountListCreate()
        {
            

            Account acount1 = new Account
            {
                FirstName = "Iosif",
                LastName = "Iarco",
                CardNumber = "12345678",
                Amount = 4000,
                Pin = 1234

            };
            accounts.Add(acount1);

            var acount2 = new Account
            {
                FirstName = "Renata",
                LastName = "Dolbe",
                CardNumber = "87654321",
                Amount = 3000,
                Pin = 4321

            };
            accounts.Add(acount2);
        }
        
        public int AcountListCreate(string cardNumReq)
        {
            return Answer(cardNumReq, accounts);
        }
        public void WithDraw(int amount,int userAccount)
        {
            var transaction = new Transaction();
            transaction.AddTransaction("Numeral withdraw.");
            if (amount > accounts[userAccount].Amount)
            {
                Console.WriteLine("Your amount is grather than your balance!");
            }
            else
            {
                accounts[userAccount].Amount -= amount;
                
                Console.WriteLine("Your balance is " + accounts[userAccount].Amount);
                
            }
        }
        static int Answer(string cardNumReq, List<Account> accounts )
        {
            var userNumber = -1;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].CardNumber.Contains(cardNumReq))
                {
                   // userNumber = i;
                    Console.WriteLine("Hello " + accounts[i].FirstName);
                    Console.WriteLine("Please enter pin!");

                    for (int j = 3; j > 0; j--)
                    {
                        Console.WriteLine("Warrning! You can enter your pin " + j + " times before blocking account");
                        Console.Write("Enter your pin: ");
                        var pinReq = Convert.ToInt32(Console.ReadLine());
                        if (accounts[i].Pin == pinReq)
                        {
                            Console.WriteLine("Excelent your pin is Valid!");
                            userNumber = i;
                            return userNumber;
                        }
                        else if (j == 1)
                        {
                            Console.WriteLine("Your account was block");
                            return userNumber;
                        }

                    }

                }else if(i == accounts.Count - 1)
                {
                    Console.WriteLine("Your account does not exist");
                }

            }
            return userNumber;
        }
    }
}
