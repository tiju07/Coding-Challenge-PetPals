using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class PetShelter
    {
        public List<Pet> pets;
        public string shelterName;
        public string ShelterName { get => shelterName; set { shelterName = value; } }
        public PetShelter(string shelterName)
        {
            pets = new List<Pet>();
            ShelterName = shelterName;
        }
        public bool AddPet(Pet pet)
        {
            if (pet != null)
            {
                pets.Add(pet);
                return true;
            }
            return false;
        }

        public bool RemovePet(Pet pet) {  return pets.Remove(pet); }
        public void ListAvailablePets()
        {
            foreach (Pet pet in pets)
            {
                Console.WriteLine(pet.ToString());
            }
        }

    }
}
