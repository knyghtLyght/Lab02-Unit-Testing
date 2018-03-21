using System;

namespace Lab02
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool stay = true; //Loop flag
            decimal balance = 0m; //Starting balance
            string[] history = new string[0]; //Will hold history of transactions
            while (stay == true) //Loop to provide branching options
            {
                //Intro
                Console.WriteLine("Welcome to your account ATM");
                Console.WriteLine("Would you like to:\na) Check your balance\nb) Deposit funds\nc) Withdraw funds\nd) Exit");
                try
                {
                    string userActionChoice = Console.ReadLine(); //Determins path
                    //Exit condition
                    if (userActionChoice == "d")
                    {
                        stay = false;
                    }
                    //Handles the balance check path
                    if (userActionChoice == "a")
                    {
                        Console.WriteLine(BalanceCheck(balance));
                        Console.WriteLine(); //Used for formating in the console window
                        history = HistoryTracker(history, $"Balance Check. Balnce = {balance}");
                    }
                    //Handles the deposit path
                    if (userActionChoice == "b")
                    {
                        Console.WriteLine("How much would you like to Deposit?");
                        decimal valueAdd = Decimal.Parse(Console.ReadLine());
                        decimal newBalance = CashAdd(balance, valueAdd);
                        if (newBalance < 0)
                        {
                            Console.WriteLine("I'm sorry you must deposit a posetive number");
                            Console.WriteLine(); //Used for formating in the console window
                            history = HistoryTracker(history, "Deposit failed"); 
                        }
                        else
                        {
                            balance = newBalance;
                            Console.WriteLine($"Your balance is now ${balance}");
                            Console.WriteLine(); //Used for formating in the console window
                            history = HistoryTracker(history, $"Deposit successful. Balnce = {balance}");
                        }
                    }
                    //Handles the withdrawl path
                    if (userActionChoice == "c")
                    {
                        Console.WriteLine("How much would you like to Withdraw?");
                        decimal valueRemove = Decimal.Parse(Console.ReadLine());
                        decimal newBalance = CashRemove(balance, valueRemove);
                        if (newBalance < 0)
                        {
                            Console.WriteLine("I'm sorry you do not have enough funds to do that");
                            Console.WriteLine(); //Used for formating in the console window
                            history = HistoryTracker(history, "Withdraw failed");
                        }
                        else
                        {
                            balance = newBalance;
                            Console.WriteLine($"Your balance is now ${balance}");
                            Console.WriteLine(); //Used for formating in the console window
                            history = HistoryTracker(history, $"Wirhdraw successful. Balnce = {balance}");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("I'm sorry I don't know what you did.");
                    throw;
                }
            }
            //History posted to Console
            Console.WriteLine("Transaction History:");
            for (int i = 0; i < history.Length; i++)
            {
                Console.WriteLine(history[i]);
            }
            //Exit statment
            Console.WriteLine(); //Used for formating in the console 
            Console.WriteLine("Please remeber all funds will actualy be depoited to me and all withdrawls are imaginary. Thank you.");
            Console.ReadLine();
        }
        /// <summary>
        /// Intended to check the value of the bank account
        /// </summary>
        /// <param name="balance">The current amount of money held in the account</param>
        /// <returns>The existing balance</returns>
        public static string BalanceCheck(decimal balance)
        {
            string rBalance = "Your current balance is $" + balance;
            return rBalance;
        }
        /// <summary>
        /// Calculates the new balance amount when given a value to add.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="valueAdd"></param>
        /// <returns></returns>
        public static decimal CashAdd(decimal balance, decimal valueAdd)
        {
            decimal newBalance = balance + valueAdd;
            return newBalance;
        }
        /// <summary>
        /// Calculates the new balance when gicen a value to subtract
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="valueRemove"></param>
        /// <returns></returns>
        public static decimal CashRemove(decimal balance, decimal valueRemove)
        {
            decimal newBalance = balance - valueRemove;
            return newBalance;
        }
        /// <summary>
        /// Maintains and updates the history array. Since I don't know how lists work yet.
        /// </summary>
        /// <param name="history"></param>
        /// <param name="newEntry"></param>
        /// <returns></returns>
        public static string[] HistoryTracker(string[] history, string newEntry)
        {
            string[] newHistory = new string[history.Length + 1];
            for (int i = 0; i <= history.Length; i++)
            {
                if (i == history.Length)
                {
                    newHistory[i] = newEntry;
                }
                else
                {
                    newHistory[i] = history[i];
                }
            }
            return newHistory;
        }
    }
}
