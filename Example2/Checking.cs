﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Checking : Account
    {
        private const double INTEREST_RATE = 3.50;  //hold off implement later
        private const double OPENING_FUNDS = 300.00;

        public Checking(int acctNum, string fname, string lname, double acctBalance, string acctType) : base(acctNum, fname, lname, acctBalance, acctType)
        {
            this.acctNum = acctNum;
            this.fname = fname;
            this.lname = lname;
            this.acctBalance = acctBalance;
            addOpeningFunds();
            accountType = acctType;

        }

        void addOpeningFunds()
        {
            acctBalance += OPENING_FUNDS;
        }
        public override void Deposit(double depo)
        {
            acctBalance += depo;
        }
        public override void WithDraw(double withdraw)
        {
            acctBalance -= withdraw;
        }
        public override double Balance()
        {
            return acctBalance;
        }
        public override string ToString()
        {
            return String.Format($"Type of Account: {accountType}\nAccount Number: {acctNum} \nFirst Name: {fname} \nLast Name: {lname} \nAccount Balance: {acctBalance} \n\n");
        }
    }
}
