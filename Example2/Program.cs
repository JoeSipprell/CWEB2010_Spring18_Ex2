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
            Account anAccount;
            const char DELIMITER = ',';
            string[] arrayOfValues;
            const string FILEPATH = @"C:\Users\fulchr\Box Sync\Spring 2018\acct_ex.csv";
            Random randAcctNum = new Random();


            try
            {
                FileStream file = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);

                while (!read.EndOfStream)
                {
                    arrayOfValues = read.ReadLine().Split(DELIMITER);  //Splitting the information at delimiter of ','
                    anAccount = new Account(randAcctNum.Next(100, 999), arrayOfValues[0], arrayOfValues[1], Convert.ToDouble(arrayOfValues[2]));
                    Console.WriteLine(anAccount);
                    accounts.Add(anAccount);
                }
                read.Close();
                file.Close();

            }catch(Exception i)
            {
                Console.WriteLine(i.Message);
            }




        }
    }

    class Account
    {
        public int acctNum { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public double acctBalance { get; set; }
        public DateTime dateCreated { get; set; }

        public Account()
        {

        }
        public Account(int acctNum, string fname, string lname, double acctBalance)
        {
            this.acctNum = acctNum;
            this.fname = fname;
            this.lname = lname;
            this.acctBalance = acctBalance;
        }

        public override string ToString()
        {
            return String.Format($"Account Number: {acctNum} \nFirst Name: {fname} \nLast Name: {lname} \nAccount Balance: {acctBalance} \nDate Account Created: {dateCreated} \n\n");
        }
    }
}
