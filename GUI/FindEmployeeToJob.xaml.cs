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
using BL;
using Dal;

namespace GUI
{
    /// <summary>
    /// Interaction logic for FindEmployeeToJob.xaml
    /// </summary>
    public partial class FindEmployeeToJob : Window
    {
        
        EmployManegerBL bl = new EmployManegerBL();
        public FindEmployeeToJob()
        {
            InitializeComponent();
            AllEmployeeComboBox.ItemsSource = bl.GetAllNameEmployee();
            
        }


        private void SelectInterviews(object sender, SelectionChangedEventArgs e)
        {
            var u = bl.GetAllInterview().Join(bl.GetAllEmeploees1(),
               interview => interview.Id_Intervoewer,
               interviewer => interviewer.IdEmeployee,
               (interview, interviewer) =>
               new {
                   interview.id_interviewee,
                   interview.IntervewNum,
                   interview.interviewFORrole,
                   interview.Date_intervew,
                   interviewer.FirstName,
                   interviewer.PhoneNumber
               }).ToList().OrderBy(a => a.Date_intervew).GroupBy(a => a.id_interviewee).ToDictionary(a => a.Key);

            ComboBox comboBox = sender as ComboBox;
            
           var idintervuewee = bl.GetAllCandidates().Where(a => a.firstName == comboBox.SelectedItem).Select(a=> a.Id).ToList();
            try
            {
                DataGridInterview.ItemsSource = u[idintervuewee[0]].ToList();

            }
            catch
            {
                MessageBox.Show("ישנה שגיאה");
            }



        }
    }
}
