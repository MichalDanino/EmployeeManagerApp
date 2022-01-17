using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace BL
{
   public class EmployManegerBL
    {
        EmployeeManagerDBEntities1 dbcon;
        public EmployManegerBL()
        {
            dbcon = new EmployeeManagerDBEntities1();
        }
        public List<Emeployees> GetAllEmeploees1()
        {
            return dbcon.GetAllEmeployees();
        }
        public List<Candidates> GetAllCandidates()
        {
            return dbcon.GetAllCandidates();

        }
        public List<interview> GetAllInterview()
        {
            return dbcon.GetAllInterview();
        }
        public List<string> GetAllJobTitle()
        {
            var e = dbcon.GetAllEmeployees();
            return e.Select(a => a.JobTitle).Distinct().ToList();
        }
        public List<string> GetAllNameEmployee()
        {
           ;
            return dbcon.GetAllCandidates().Select(a => a.firstName ).ToList();
        }

        public bool SaveEmployee(Emeployees employee)
        {

            return dbcon.SaveEmployee(employee);
        }

        public List<Emeployees> SelectComboBox(string s, string value)
        {
            
            if (s == "YearStart")
                return GetAllEmeploees1().Where(a => a.StartOfWorkingYear == Convert.ToInt32(value)).ToList();
            if (s == "city")
                return GetAllEmeploees1().Where(a => a.CityAddress == value).ToList();
            if (s == "jobTitle")
                return GetAllEmeploees1().Where(a => a.JobTitle == value).ToList();
            if (s == "age")
                return GetAllEmeploees1().Where(a => a.Age- a.Age%10 == Convert.ToInt32(value)).ToList();
            return GetAllEmeploees1();
        }

    }
}
