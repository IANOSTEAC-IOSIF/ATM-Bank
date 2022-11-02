using System.Transactions;

namespace ATM_Bank
{
    public class Transaction
    {
        public List<TransactionDefine> Transactions { get; set; } 

        public void AddTransaction(string data)
        {
            Transactions = new List<TransactionDefine>();
            var transactionToAdd = new TransactionDefine
            {
                TransactionMemory = data
            };
            Transactions.Add(transactionToAdd);
        }
        
        public void ShowTransaction()
        {
            Console.WriteLine(" Transaction hristory: ");
            if (Transactions != null)
            {
                foreach (var transaction in Transactions)
                {
                    Console.WriteLine(transaction);

                }
            }
            else {
                Console.Write("You have no transactions ");            
            }
        }
    }
}
