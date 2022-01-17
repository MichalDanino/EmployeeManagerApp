using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial class EmployeeManagerDBEntities1
    {
        public List<Emeployees> GetAllEmeployees()
        {
            return Emeployees.ToList();
        }
        public List<Candidates> GetAllCandidates()
        {
            return Candidates.ToList();
        }
        public List<interview> GetAllInterview()
        {
            return interview.ToList();

        }

        public bool SaveEmployee(Emeployees e)
        {
            var emp = Emeployees.ToList();
            if (emp.Any(a => e.IdEmeployee == a.IdEmeployee))
            {
                return false;
            }

            Emeployees.Add(e);
            SaveChanges();


            return true;
        }

      


        }
    }
