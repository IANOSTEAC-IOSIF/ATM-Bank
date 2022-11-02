namespace ATM_Bank
{
    public class PaybillsList
    {
        List<Paybills> paysList = new List<Paybills>();
        public void DefPaybillsList()
        {


            var payBill1 = new Paybills
            {
                PayBillsNo = 1,
                ProviderName = "Orange",
                DataSend = "08.12.2022",
                PayAmount = 130
            };
            paysList.Add(payBill1);

            var payBill2 = new Paybills
            {
                PayBillsNo = 2,
                ProviderName = "Enel",
                DataSend = "03.06.2022",
                PayAmount = 1300
            };
            paysList.Add(payBill2);


            var payBill3 = new Paybills
            {
                PayBillsNo = 3,
                ProviderName = "GazPetrom",
                DataSend = "03.04.2022",
                PayAmount = 1000
            };
            paysList.Add(payBill3);
        }

        public void DisplayBills()
        {
            foreach (var bill in paysList)
            {
                Console.WriteLine();
                Console.WriteLine("Bill number: " + bill.PayBillsNo);
                Console.WriteLine("Provider name: " + bill.ProviderName);
                Console.WriteLine("Pay amount " + bill.PayAmount);
                Console.WriteLine();
 
            }
        }
        public void PayAnBill(int billNo, int userAccount)
        {
            var account = new AccountList();
            account.AccountListCreate();
            int balance = account.accounts[userAccount].Amount;
            var transaction = new Transaction();
            billNo -= 1;
            if (paysList[billNo].PayAmount> balance)
            {
                Console.WriteLine("You don't have enough money to pay!");
            }
            else
            {
                transaction.AddTransaction("Pay an bill");
                var removePay = new Paybills
                {
                    PayBillsNo = billNo + 1,
                    ProviderName = paysList[billNo].ProviderName,
                    DataSend = paysList[billNo].DataSend,
                    PayAmount = paysList[billNo].PayAmount
                };
                balance -= paysList[billNo].PayAmount;
                paysList.Remove(removePay);
                account.accounts[userAccount].Amount = balance;
                Console.WriteLine("Your balance is: " + account.accounts[userAccount].Amount);
            }

        }
    }
}
