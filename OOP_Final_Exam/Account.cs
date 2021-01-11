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
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Balance { get; set; }

        public DateTime InterestDate { get; set; }

        //constructors
        public Account() { }

        public Account(string a, string b, double c, DateTime d) 
        {
            FirstName = a;
            LastName = b;
            Balance = c;
            InterestDate = d;
        }

        //abstract method
        public abstract double CalculateInterest();
    }
}
