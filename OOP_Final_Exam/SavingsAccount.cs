using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_Exam
{
    class SavingsAccount : Account
    {
        //properties
        public double InterestRate { get; set; }

        //constructors
        public SavingsAccount(string a, string b, double c, DateTime d) : base(a, b, c, d)
        {
            InterestRate = .06;
        }




        public override double CalculateInterest()
        {
            if(InterestDate.Year == DateTime.Today.Year)
            {
                return 0;
            }

            double interest = Balance * InterestRate;

            InterestDate = DateTime.Now;
            return interest;
        }
    }
}
