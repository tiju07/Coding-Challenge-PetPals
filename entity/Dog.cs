using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class Dog : Pet
    {
        private string dogBreed = null!;

        public string DogBreed { get => dogBreed; set { dogBreed = value; } }
        public Dog(string name, int age, string breed, string dogBreed) : base(name, age, breed)
        {
            DogBreed = dogBreed;
        }
    }
}
