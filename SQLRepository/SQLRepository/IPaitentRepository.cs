using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    internal interface IPaitentRepository
    {
        public Paitent CreateNewPaitent(Paitent paitent, string conn);
        public Paitent GetPaitentByID(int id, string conn);
        public IEnumerable<Paitent> GetAllPaitents(string conn);
        public Paitent LogInPaitent(Paitent patient, string conn);
    }
}
