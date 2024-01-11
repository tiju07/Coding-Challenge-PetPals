using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    internal class Cat : Pet
    {
        private string catColor = null!;

        public string CatColor { get => catColor; set { catColor = value; } }

        public Cat(string name, int age, string breed, string catColor) : base(name, age, breed)
        {
            CatColor = catColor;
        }
    }
}
