using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
namespace Business
{
    public class BusinessService
    {

        public static List<Departement> GetDepartements 
        {
            get {
                DataTable dataTable = DataHelper.GetDepartements();
                List<Departement> departments = new List<Departement>();
                foreach (DataRow row in dataTable.Rows)
                {
                    departments.Add(new Departement
                    {
                        ID = Convert.ToInt32(row["Dnum"]),
                        Name = Convert.ToString(row["Dname"]),
                        ManagerSSN = Convert.ToInt32(row["MGRSSN"]),
                        Employees = DataHelper.GetDepartementEmployees(Convert.ToInt32(row["Dnum"]))
                    });
                }

                return departments;
            }
            

        }
        public 

    }
}
