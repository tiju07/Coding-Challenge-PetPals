using Microsoft.Data.SqlClient;
using PetPals.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class AdoptionEvent : IAdoptable
    {
        public List<Participant> participants;
        private string eventName = null!;

        public string EventName { get => eventName; set { eventName = value; } }
        public AdoptionEvent(string eventName)
        {
            participants = new List<Participant>();
            EventName = eventName;
            Console.WriteLine($"The adoption event {EventName} has been registered.");
        }
        public void Adopt(Pet pet, Participant participant)
        {
            participant.AdoptPet(pet);
        }

        public void HostEvent()
        {
            Console.WriteLine($"Hosting the adoption event {EventName}!");
        }
        public bool RegisterParticipant(Participant participant)
        {
            if(participant != null)
            {
                participants.Add(participant);
                return true;
            }
            return false;
        }
    
        public static void GetAllAdoptionEventDetails()
        {
            SqlConnection conn = null!;
            SqlCommand cmd;
            SqlDataReader dr = null!;
            try
            {
                conn = DBConn.GetConnection();
                conn.Open();
                string q = "SELECT * FROM AdoptionEvents";
                cmd = new SqlCommand(q, conn);
                dr = cmd.ExecuteReader();
                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                while (dr.Read())
                {
                    var data = Enumerable.Range(0, dr.FieldCount).Select(dr.GetValue).ToList();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        Console.WriteLine(columns[i] + ": " + data[i]);
                    }
                    Console.WriteLine(new String('-', 50));
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                conn.Close();
            }
        }
    
        public static void RegisterForAnEvent(string participantName, string participantType, int eventID)
        {
            SqlConnection conn = null!;
            SqlCommand cmd;
            try
            {
                conn = DBConn.GetConnection();
                conn.Open();
                var donationItem = DBNull.Value;
                string q = $"INSERT INTO Participants (ParticipantName, ParticipantType, EventID) VALUES (\'{participantName}\', \'{participantType}\', {eventID})";
                Console.WriteLine(q);
                cmd = new SqlCommand(q, conn);
                int dr = cmd.ExecuteNonQuery();
                if (dr > 0) Console.WriteLine($"Successfully registered participant {participantName} for the event with ID:{eventID}.");
                else Console.WriteLine("Could not register the participant!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint") ? "Invalid Event ID!" : ex.Message); }
            finally
            {
                conn.Close();
            }
        }
    }
}
