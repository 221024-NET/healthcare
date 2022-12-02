using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataObjects
{
    public class Employee
    {
   
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Employee() { }

        public Employee(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public Employee(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password=password;
        }
        public Employee(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}