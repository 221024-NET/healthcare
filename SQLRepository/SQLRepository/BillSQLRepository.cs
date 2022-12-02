using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataObjects;

namespace SQLRepository
{
    public class BillSQLRepository : IBillRepository
    {
        string? connectionString;
        public BillSQLRepository() { }

        public BillSQLRepository(string conn)
        {
            this.connectionString = conn;
        }

        //-------------------------------------Claims Table---------------------------\\
        /* NOTE: Claim is already a class file from System.Security.Claims
         *    Bill is the placeholder Object for the Claims Table
         */

        /// <summary>
        ///     Adds a new Claim (Bill) to the Claims table
        /// </summary>
        /// <param name="bill">
        ///     The Bill Object to be added to the Claims Table
        /// </param>
        /// <param name="conn">
        ///     Database Connection string
        /// </param>
        /// <returns>
        ///     The Bill Object added to the database
        /// </returns>
        public Bill CreateNewBill(Bill bill, string conn)
        {

           
        }

        /// <summary>
        /// Returns a List of all bills for a specific paitent
        /// </summary>
        /// <param name="paitent">
        ///     The Patient seeking the list of bills
        /// </param>
        /// <param name="conn">
        ///     Database Connection string
        /// </param>
        /// <returns></returns>
        public IEnumerable<Bill> GetBillsByPaitent(Paitent paitent, string conn)
        {

        }

        /// <summary>
        /// Returns a List of all bills in the claims table
        /// with pending status
        /// </summary>
        /// <param name="conn">
        ///     Database Connection string
        /// </param>
        /// <returns></returns>
        public IEnumerable<Bill> GetAllPendingBills(string conn)
        {

        }

        /// <summary>
        ///     Updates a bill with a pending status to a new status
        /// </summary>
        /// <param name="bill">
        ///     The bill object being updated
        /// </param>
        /// <param name="newStatus">
        ///     The new status 
        /// </param>
        /// <param name="conn">
        ///     Database Connection string
        /// </param>
        /// <returns></returns>
        public bool UpdateBillStatus(Bill bill, string newStatus, string conn)
        {

        }
    }
}
