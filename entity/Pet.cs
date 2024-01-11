using Microsoft.Data.SqlClient;
using PetPals.exception;
using PetPals.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class Pet
    {
        private string name = null!;
        private int age;
        private string breed = null!;

        public string Name { get => name; set { name = value; } }
        public int Age 
        {
            get => age; 
            set {
                if (value < 1) throw new InvalidPetAgeException("Invalid pet age! Enter a positive integer.");
                else age = value; 
            } 
        }
        public string Breed { get => breed; set { breed = value; } }

        public Pet(string name, int age, string breed) 
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public override string ToString()
        {
            if (Name == null || Age == 0 || Breed == null) throw new NullReferenceException("Missing pet information! Please recheck your data."); 
            return $"Name of Pet: {Name} \t Age: {Age} \t Breed: {Breed}\n";
        }

        public static void GetAllPets()
        {
            SqlConnection conn = null!;
            SqlCommand cmd;
            SqlDataReader dr = null!;
            try
            {
                conn = DBConn.GetConnection();
                conn.Open();
                string q = "SELECT * FROM Pets";
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
            } catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                conn.Close();
            }
        }
    }
}
