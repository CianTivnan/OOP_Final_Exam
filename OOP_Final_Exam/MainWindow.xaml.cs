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
*/
namespace OOP_Final_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Account> Accounts = new List<Account>();
        public List<Account> DisplayedAccounts = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();

            LoadAccounts();

            DisplayAccounts();
        }

        public void LoadAccounts()
        {
            CurrentAccount ca1 = new CurrentAccount("John", "Smith", 12000, DateTime.Now);
            Accounts.Add(ca1);
            SavingsAccount sa1 = new SavingsAccount("John", "Smith", 12000, DateTime.Now);
            Accounts.Add(sa1);

            DisplayedAccounts.Add(ca1);
            DisplayedAccounts.Add(sa1);
        }

        public void DisplayAccounts()
        {
            lbx_Accounts.ItemsSource = DisplayedAccounts;
        }
    }
}
