namespace ATM_Bank
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Wellcome to DogeBank! ");
            oneMoretime:
                Console.Write("Please Enter Card Number: ");
                var cardNumReq = Console.ReadLine();
                
            var accountCheck = new AccountList();
            accountCheck.AccountListCreate();
            var userAccount = accountCheck.AcountListCreate(cardNumReq);
            var tranzactionHristory = new Transaction();
            var bills = new PaybillsList();
            bills.DefPaybillsList();


            if (userAccount != -1)
            {
                Console.WriteLine("Hello "+ accountCheck.accounts[userAccount].FirstName + "!\n");
                var repeatProcess = "";
                do
                {
                    Console.WriteLine(" Options:\n 1.See balance \n 2.Withdraw\n 3.PayBills\n 4.Transaction Hristory\n 5.EjectCard\n\n");
                    Console.Write("Enter a number of the options: ");
                    var optionChosen = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                
                    switch (optionChosen)
                    {
                        case 1:
                            Console.WriteLine("Your balance is: " + accountCheck.accounts[userAccount].Amount);
                            break;
                        case 2:
                            Console.Write("Enter the value you wont to withdraw: ");
                            var withDrawAmount = Convert.ToInt32(Console.ReadLine());
                            accountCheck.WithDraw(withDrawAmount, userAccount);
                            break;
                        //complet the case 3
                        case 3:
                            bills.DisplayBills();
                            Console.Write("\nChose an number: ");
                            var ans = Convert.ToInt32(Console.ReadLine());
                            bills.PayAnBill(ans, userAccount);
                            break;

                        case 4:
                            tranzactionHristory.ShowTransaction();
                            break;
                        case 5:
                            Console.WriteLine("The card will be ejected if you confirm that you do not wont another tranzaction!");
                            break;
                    }
                    Console.Write("\nDo you wont to make an other transaction? ");
                    repeatProcess = Console.ReadLine();
                } while (repeatProcess == "yes");

            }
            else
            {
                Console.WriteLine("Your data are invalid!");
                
                Console.Write("Do you wish to try again?\n Please enter your answer: ");
                var answer = Console.ReadLine(); 
                if(answer == "yes")
                    goto oneMoretime;
                else
                {
                    Console.WriteLine("Thank you for visit DogeBank Account!\n Have a nice day!");
                }
            }
            


        }
    }
}