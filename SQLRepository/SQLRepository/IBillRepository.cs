using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    internal interface IBillRepository
    {
        public Bill CreateNewBill(Bill bill, string conn);
        public IEnumerable<Bill> GetBillsByPaitent(Paitent paitent, string conn);
        public IEnumerable<Bill> GetAllPendingBills(string conn);
        public bool UpdateBillStatus(Bill b, string newStatus, string conn);
    }
}
