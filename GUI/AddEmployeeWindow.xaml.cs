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
using System.Windows.Shapes;
using System.Collections.Generic;
using BL;
using Dal;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;
using System.Net.Mail;

namespace GUI
{
    public partial class AddEmployeeWindow : Window
    {
        public event isSecsedAdd AddEmployeeEvent ;
        
        DateTime year = DateTime.Now;
        EmployManegerBL bl = new EmployManegerBL();
        Regex regex;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            SELECTJobTitle.ItemsSource = bl.GetAllJobTitle();
        }

        public void AddAndRefresh(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(Id.Text, out id);
            int AgeE;
            int.TryParse(age.Text, out AgeE);
            var Year = year.Year.ToString();
            int YearStart;
            int.TryParse(Year, out YearStart);
            Emeployees employee = new Emeployees()
            {
                FirstName = firstNmae.Text,
                IdEmeployee = id,
                LastName = lastName.Text,
                Age = AgeE,
                StartOfWorkingYear = YearStart,
                CityAddress = city.Text,
                StreetAddress = street.Text,
                JobTitle = SELECTJobTitle.Text,
                PhoneNumber = pon.Text,
                GmailAddress = email.Text
            };
            RefreshAddWindows();

            if (AddEmployeeEvent(employee))
            {
                
               MessageBox.Show("The employe has been add succesfully");
            }

            
        }

        public void RefreshAddWindows()
        {
            foreach (Control textBox in StackPanelAdds.Children)
            {
                if (textBox.GetType() == typeof(TextBox))
                 (textBox as TextBox).Text = string.Empty;
            }
        }
        //check legal
        private void IsLetter(object sender, RoutedEventArgs e)
        {            //למורה הבדיקה לא עבדה לי אין לי מושג למה 

            var tBox = sender as TextBox;
             regex = new Regex("^[a-zA-Zא-ת]+$");
            

            if (!regex.IsMatch(tBox.Text) && tBox.Text!="")
            {
                
                MessageBox.Show("The " + tBox.Name + " Illegal");
              
            }
            
        }

        private void isNumber(object sender, RoutedEventArgs e)
        {
           var tBox =  sender as TextBox;
            regex = new Regex(@"^\d{0,9}$");
            var t = regex.IsMatch(tBox.Text);
            if (regex.IsMatch(tBox.Text) )
            {
                if (tBox.Name == "Id" && tBox.Text.Length > 9)
                    {

                    }
                if (tBox.Name == "age" && tBox.Text.Length > 3)
                    {

                    }
            }
            else if(tBox.Text!= "")
                MessageBox.Show("The " + tBox.Name + " Illegal");




        }

        private void isEmail(object sender, RoutedEventArgs e)
        {
            if (email.Text != "")
            {
                try
                {
                    MailAddress m = new MailAddress(email.Text);

                }
                catch (FormatException)
                {
                    MessageBox.Show("The Email Illegal");
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
