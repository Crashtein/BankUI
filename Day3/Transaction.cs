using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Transaction
    {
        private double Amount;
        private DateTime Date;
        private string Notes;

        public Transaction(double a,DateTime d, string n)
        {
            Amount = a;
            Date = d;
            Notes = n;
        }
        public double amount()
        {
            return Amount;
        }
        public DateTime date()
        {
            return Date;
        }
        public string notes()
        {
            return Notes;
        }
    }
}
