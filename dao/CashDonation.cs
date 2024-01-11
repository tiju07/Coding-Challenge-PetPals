using PetPals.exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao
{
    public class CashDonation : Donation
    {
        public static List<CashDonation> cashDonations = new List<CashDonation>();
        private DateTime donationDate;
        private double amount;

        public DateTime DonationDate { get => donationDate; set { donationDate = value; } }
        public double Amount
        {
            get => amount;
            set
            {
                if (value < 50) throw new InsufficientFundsException("Please donate a minimum of 50$.");
                else amount = value;
            }
        }
        public CashDonation(string donorName, PetShelter donatedTo, DateTime donationDate, double amount) : base(donorName, donatedTo)
        {
            Amount = amount;
            DonationDate = donationDate;
            RecordDonation();
        }

        public override bool RecordDonation()
        {
            if (this != null)
            {
                cashDonations.Add(this);
                return true;
            }
            return false;
        }

        public void ToString()
        {
            Console.WriteLine("Following are the cash donations made:");
            foreach (var c in cashDonations)
            {
                Console.WriteLine($"Name of Donor: {c.DonorName} \t Donation Amount: {c.Amount} \t Donated On: {c.DonationDate} \t Donated to: {DonatedTo.ShelterName}");
            }
        }
    }
}
