using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Departement Departement { get; set; }

    }
}
