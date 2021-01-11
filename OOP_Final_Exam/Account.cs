using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_Exam
{
    public abstract class Account
    {
        //properties
        public int AccountNo { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Balance { get; set; }

        public DateTime InterestDate { get; set; }

        private static int counter;
        //constructors
        public Account(string a, string b, double c, DateTime d) 
        {
            FirstName = a;
            LastName = b;
            Balance = c;
            InterestDate = d;
            counter++;
            AccountNo = counter;
        }

        //abstract method
        public abstract double CalculateInterest();

        public override string ToString()
        {
            return (AccountNo.ToString() + " - " + LastName + ", " + FirstName);
        }
    }
}
