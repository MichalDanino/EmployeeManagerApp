
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using Dal;

namespace GUI
{
   
    public delegate bool isSecsedAdd(Emeployees e);
    
    public partial class MainWindow : Window
    {
        static List<Emeployees> listEmployee = new List<Emeployees>();
        
       //static SpellingError spellingError;
        EmployManegerBL blem = new EmployManegerBL();
        AddEmployeeWindow AddEmployeeWindow;
        
        
        //  Emeployees d;
        public MainWindow()
        {

            listEmployee = blem.GetAllEmeploees1();

            InitializeComponent();
            ApplyEmeployeeGrid(listEmployee);
            AllComboBox();
        }
         public void ApplyEmeployeeGrid<T> ( T List)
        {
            EmployeeDataGrid.ItemsSource = (System.Collections.IEnumerable)List ; 
        }

        public void AddEmployee(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow = new AddEmployeeWindow();
            AddEmployeeWindow.AddEmployeeEvent += AddEmployeeEvent1;
            
            AddEmployeeWindow.ShowDialog();
            
            

        }

        private bool AddEmployeeEvent1(Emeployees emp)
        {
           blem.SaveEmployee(emp);
            return true;
           // ApplyEmeployeeGrid();
        }

        

        private void Find(object sender, RoutedEventArgs e)
        {
            FindEmployeeToJob find = new FindEmployeeToJob();
            find.ShowDialog();
        }
        public void AllComboBox()
        {
            var emploees = blem.GetAllEmeploees1();
            jobTitle.ItemsSource = emploees.Select(a => a.JobTitle).Distinct().ToList();
            age.ItemsSource = emploees.Select(a => a.Age- a.Age%10).OrderBy(a => a.Value).Distinct().ToList();
            city.ItemsSource = emploees.Select(a => a.CityAddress).ToList();
            YearStart.ItemsSource = emploees.Select(a => a.StartOfWorkingYear).ToList();
        }

        private void SelectItem1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var value = comboBox.SelectedItem.ToString();
            foreach (ComboBox comboBox1 in stackPanel.Children)
            {
                if (comboBox1.Name == comboBox.Name)
                    ApplyEmeployeeGrid(blem.SelectComboBox(comboBox1.Name, value));
                else
                {
                    if (comboBox1.Name == "YearStart")
                        comboBox1.ItemsSource = blem.SelectComboBox(comboBox.Name, value).Select(a => a.StartOfWorkingYear).ToList();
                    if (comboBox1.Name == "city")
                        comboBox1.ItemsSource = blem.SelectComboBox(comboBox.Name, value).Select(a => a.CityAddress).ToList();
                    if (comboBox1.Name == "jobTitle")
                        comboBox1.ItemsSource = blem.SelectComboBox(comboBox.Name, value).Select(a => a.JobTitle).ToList();
                    if (comboBox1.Name == "age")
                        comboBox1.ItemsSource = blem.SelectComboBox(comboBox.Name, value).Select(a => a.Age-a.Age%10).OrderBy(a => a.Value).Distinct().ToList();
                }
            }

        }

        private void AllComboBoxButton(object sender, RoutedEventArgs e)
        {
            AllComboBox();
            ApplyEmeployeeGrid(blem.GetAllEmeploees1());

        }
    }
}
