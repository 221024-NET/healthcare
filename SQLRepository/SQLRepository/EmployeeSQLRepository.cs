using HealthcareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLRepository
{
    public  class EmployeeSQLRepository : IEmployeeRepository
    {
        string? connectionString;
        public EmployeeSQLRepository()
        {}

        public EmployeeSQLRepository(string conn)
        {
            this.connectionString = conn;
        }

        //-----------------------------------Employee Table--------------------------\\


        /// <summary>
        ///     Adds an Employee Object to the database
        /// </summary>
        /// <param name="employee">
        ///     The Employee Object to be added to the database
        /// </param>
        /// <param name="conn">
        ///     Database connection string
        /// </param>
        /// <returns></returns>
        public Employee CreateNewEmployee(Employee employee, string conn)
        {

        }

        /// <summary>
        /// Returns an Employee Object that has a matching ID 
        /// in the Employee Table 
        /// </summary>
        /// <param name="id">
        ///  The employee ID number
        /// </param>
        /// <param name="conn">
        ///     Database Connection String
        /// </param>
        /// <returns>
        ///     An Employee Object with fields matching
        ///     table values
        /// </returns>
        public Employee GetEmployeeByID(int id, string conn)
        {

        }

        public Employee LogInEmployee(Employee employee, string conn)
        {

        }
    }
}
