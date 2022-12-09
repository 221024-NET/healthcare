using HealthcareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SQLRepository
{
    public class PaitentSQLRepository : IPaitentRepository
    {

        string? connectionString { get; set; }
        public PaitentSQLRepository() { }

        public PaitentSQLRepository(string? connectionString)
        {
            this.connectionString = connectionString;
        }

        //--------------------------------Paitent Table------------------------------\\

        /// <summary>
        ///     Takes a new Paitent object and adds it to the database
        /// </summary>
        /// <param name="paitent">
        ///     The new Paitent object that needs to be addded.
        /// </param>
        /// <param name="conn">
        ///    Database Connection String
        /// </param>
        /// <returns>
        ///     A Patient object with the same field values as the new Paitent
        /// </returns>
        public Patient CreateNewPaitent(Patient paitent, string conn)
        {

        }

        /// <summary>
        ///     Returns a Patient object with fields that match
        ///         a specific Paitent ID in the database 
        /// </summary>
        /// <param name="id">
        ///  The int id of the patient currently in the database
        /// </param>
        /// <param name="conn">
        ///     Database Connection String
        /// </param>
        /// <returns>
        ///     The Patient oblect with the corrisponding ID
        /// </returns>
        public Patient GetPaitentByID(int id, string conn)
        {

        }

        /// <summary>
        ///    Returns a List container of all Paitents in the database. 
        /// </summary>
        /// <param name="conn">
        ///     Database Connection String
        /// </param>
        /// <returns>
        ///     A List of all Paitents
        /// </returns>
        public IEnumerable<Patient> GetAllPaitents(string conn)
        {

        }

        public Patient LogInPaitent (Patient patient, string conn)
        {

        }

        




    }
}