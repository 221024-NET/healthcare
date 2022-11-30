using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    public interface IEmployeeRepository
    {
        public Employee CreateNewEmployee(Employee employee, string conn);
        public Employee GetEmployeeByID(int id, string conn);
        public Employee LogInEmployee(Employee employee, string conn);


    }
}
