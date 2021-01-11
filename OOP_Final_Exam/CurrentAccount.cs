using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_Exam
{
    class CurrentAccount : Account
    {
        //properties
        public double InterestRate { get; set; }

        //constructors
        public CurrentAccount() : base() { }

        public CurrentAccount(string a, string b, double c, DateTime d) :base()
        {
            InterestRate = .03;
        }




        public override double CalculateInterest()
        {
            if (InterestDate.Year == DateTime.Today.Year)
            {
                return 0;
            }

            double interest = Balance * InterestRate;

            InterestDate = DateTime.Now;
            return interest;
        }
    }
}
