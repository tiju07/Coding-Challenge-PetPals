using Microsoft.Data.SqlClient;
using PetPals.exception;
using PetPals.util;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace PetPals.entity
{
    public abstract class Donation
    {
        private string donorName = null!;
        private PetShelter donatedTo;
        public string DonorName { get => donorName; set { donorName = value; } }
        public PetShelter DonatedTo { get => donatedTo; set { donatedTo = value; } }
        public Donation(string donorName, PetShelter donatedTo) 
        {
            DonorName = donorName;
            DonatedTo = donatedTo;
        }

        public abstract bool RecordDonation();

        public static int AddDonation(string donorName, decimal donationAmount, int shelterID)
        {
            SqlConnection conn = null!;
            SqlCommand cmd;
            try
            {
                conn = DBConn.GetConnection();
                conn.Open();
                var donationItem = DBNull.Value;
                string q = $"INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationDate, ShelterID) VALUES (\'{donorName}\', 'Cash', {donationAmount}, \'{DateTime.Now}\', {shelterID})";
                Console.WriteLine(q);
                cmd = new SqlCommand(q, conn);
                int dr = cmd.ExecuteNonQuery();
                if (dr > 0) { Console.WriteLine("Successfully added donation to database."); return 1; }
                else {Console.WriteLine("Could not add donation details to the database."); return 0;}
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return 0; }
            finally
            {
                conn.Close();
            }
        }
    }
}
