using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/*
    Author : Cian Tivnan S00198481
    Github Repository Link : https://github.com/CianTivnan/OOP_Final_Exam
    Date : 11/01/2021
    Desc : WPF Bank Account Program, Exam

    KNOWN ERRORS : Both unchecked boxes will not clear list, Program crashes when filtering while an account is selected
                   Did not have time to fix errors.
*/
namespace OOP_Final_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //we declare our lists for accounts and displayed accounts
        public List<Account> Accounts = new List<Account>();
        public List<Account> DisplayedAccounts = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();

            //call method to create accounts
            LoadAccounts();

            DisplayAccounts();
        }

        public void LoadAccounts()
        {
            //here we create our accounts and add them to our lists
            CurrentAccount ca1 = new CurrentAccount("John", "Smith", 12000, DateTime.Today.AddYears(-1));
            Accounts.Add(ca1);
            SavingsAccount sa1 = new SavingsAccount("Jane", "Doe", 74000, DateTime.Today.AddYears(-3));
            Accounts.Add(sa1);

            DisplayedAccounts.Add(ca1);
            DisplayedAccounts.Add(sa1);
        }

        public void DisplayAccounts()
        {
            //we set ItemsSource to null and then back to our list to refresh the box
            lbx_Accounts.ItemsSource = null;
            lbx_Accounts.ItemsSource = DisplayedAccounts;
        }

        private void lbx_Accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //we get the selected account
            Account SelectedAccount = lbx_Accounts.SelectedItem as Account;

            tblk_FName.Text = SelectedAccount.FirstName;
            tblk_LName.Text = SelectedAccount.LastName;

            //here we use an if statement to check what type of account it is
            if (SelectedAccount is SavingsAccount)
            {
                tblk_AccountType.Text = "Savings Account";
            }
            else
            {
                tblk_AccountType.Text = "Current Account";
            }

            tblk_Balance.Text = SelectedAccount.Balance.ToString();
            tblk_InterestDate.Text = SelectedAccount.InterestDate.Date.ToShortDateString();
        }

        private void cbx_CurrentAc_Checked(object sender, RoutedEventArgs e)
        {
            //we clear out the display list
            DisplayedAccounts.Clear();

            //we look for current accounts and add them to the display list
            foreach (Account account in Accounts)
            {
                if (account is CurrentAccount)
                {
                    DisplayedAccounts.Add(account);
                }
            }

            //if both are checked we will display both
            if(cbx_SavingsAc.IsChecked == true)
            {
                foreach (Account account in Accounts)
                {
                    if (account is SavingsAccount)
                    {
                        DisplayedAccounts.Add(account);
                    }
                }
            }

            //we display the changes
            DisplayAccounts();
        }

        private void cbx_SavingsAc_Checked(object sender, RoutedEventArgs e)
        {
            //we clear out the display list
            DisplayedAccounts.Clear();

            //we look for savings accounts and add them to the display list
            foreach (Account account in Accounts)
            {
                if (account is SavingsAccount)
                {
                    DisplayedAccounts.Add(account);
                }
            }

            //if both are checked we will display both
            if (cbx_CurrentAc.IsChecked == true)
            {
                foreach (Account account in Accounts)
                {
                    if (account is CurrentAccount)
                    {
                        DisplayedAccounts.Add(account);
                    }
                }
            }

            //we display the changes
            DisplayAccounts();
        }

        private void btn_Deposit_Click(object sender, RoutedEventArgs e)
        {
            //we get our amount to deposit
            double amount = double.Parse(tbx_Transaction.Text);

            //we get the chosen account
            Account SelectedAccount = lbx_Accounts.SelectedItem as Account;

            //we add the amount to the balance
            SelectedAccount.Balance += amount;

            //we update balance
            tblk_Balance.Text = SelectedAccount.Balance.ToString();
        }

        private void btn_Withdraw_Click(object sender, RoutedEventArgs e)
        {
            //we get our amount to withdraw
            double amount = double.Parse(tbx_Transaction.Text);

            //we get the chosen account
            Account SelectedAccount = lbx_Accounts.SelectedItem as Account;

            //we subtract the amount to the balance
            SelectedAccount.Balance -= amount;

            //we update balance
            tblk_Balance.Text = SelectedAccount.Balance.ToString();
        }

        private void btn_Interest_Click(object sender, RoutedEventArgs e)
        {
            //we get the chosen account
            Account SelectedAccount = lbx_Accounts.SelectedItem as Account;

            //we get the amount of interest due
            double interest = SelectedAccount.CalculateInterest();

            //we check if it is zero, this would mean they are not due interest
            if (interest == 0)
            {
                //we write not due in the box and add nothing
                tbx_Transaction.Text = "NOT DUE";
            }
            else
            {
                //we write amount
                tbx_Transaction.Text = interest.ToString();
                //we add the amount to the balance
                SelectedAccount.Balance += interest;
                //update interest date
                tblk_InterestDate.Text = SelectedAccount.InterestDate.ToShortDateString();
            }
        }
    }
}
