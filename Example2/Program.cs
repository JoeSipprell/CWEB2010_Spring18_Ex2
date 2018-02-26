using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            readInAccounts();




        }//End of main method

        public static void readInAccounts()
        {
            //DECLARATIONS
            List<Account> accounts = new List<Account>();
            Checking checkAccount;
            Savings savingsAccount;
            CD cdAccount;
            const char DELIMITER = ',';
            string[] arrayOfValues;
            const string FILEPATH = @"C:\Users\fulchr\Box Sync\CWEB2010\Spring 2018\acct_ex.csv";
            Random randAcctNum = new Random();


            try
            {
                FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);

                while (!read.EndOfStream)
                {
                    arrayOfValues = read.ReadLine().Split(DELIMITER);  //Splitting the information at delimiter of ','
                    switch (arrayOfValues[3])
                    {
                        case "Checking":
                            checkAccount = new Checking(randAcctNum.Next(100, 999), arrayOfValues[0], arrayOfValues[1], Convert.ToDouble(arrayOfValues[2]), arrayOfValues[3]);
                            Console.WriteLine(checkAccount);
                            accounts.Add(checkAccount);

                            break;
                        case "Saving":
                            savingsAccount = new Savings(randAcctNum.Next(100, 999), arrayOfValues[0], arrayOfValues[1], Convert.ToDouble(arrayOfValues[2]), arrayOfValues[3]);
                            Console.WriteLine(savingsAccount);
                            accounts.Add(savingsAccount);
                            break;
                        case "CD":
                            cdAccount = new CD(randAcctNum.Next(100, 999), arrayOfValues[0], arrayOfValues[1], Convert.ToDouble(arrayOfValues[2]), arrayOfValues[3]);
                            Console.WriteLine(cdAccount);
                            accounts.Add(cdAccount);
                            break;
                        default:
                            Console.WriteLine("An account does not have a type");
                            break;
                    }

                }
                read.Close();
                file.Close();

            }catch(Exception i)
            {
                Console.WriteLine(i.Message);
            }

            //Calling this method
            getHighAccounts(accounts);

        }

        public static void getHighAccounts(List<Account> accounts)
        {

            var highAccounts =  //Query name
                from acct in accounts //Data set
                where acct.acctBalance > 8000.0  //formatted query
                orderby acct.lname
                select new { acct.acctBalance, acct.fname, acct.lname }; //outputing selected properties

            Console.WriteLine("Outputing accounts that are above $8,000");
            foreach(var acct in highAccounts)
            {
                Console.WriteLine($"First Name: {acct.fname}  Last Name: {acct.lname}  Account Balance: {acct.acctBalance} ");
            }






        }
    }

    abstract class Account
    {
        public int acctNum { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public double acctBalance { get; set; }
        public DateTime dateCreated { get; set; }
        public string accountType { get; set; }

        public Account()
        {

        }
        public Account(int acctNum, string fname, string lname, double acctBalance, string acctType)
        {
            this.acctNum = acctNum;
            this.fname = fname;
            this.lname = lname;
            this.acctBalance = acctBalance;
            dateCreated = DateTime.Now;
            accountType = acctType;

        }



    }//End of Account Class

    class BalanceBelowZero : Exception
    {
        private static string outputMessage = "Found Account below zero.";

        public BalanceBelowZero() : base(outputMessage)
        {

        }
    }
}
