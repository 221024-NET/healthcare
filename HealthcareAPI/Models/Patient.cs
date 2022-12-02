using System;
using System.Text;

namespace HealthcareAPI.Models
{
    public class Paitent
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Paitent() { }
        public Paitent(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public Paitent(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public Paitent(int id, string name, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}
