using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.exception
{
    internal class InvalidPetAgeException : Exception
    {
        public InvalidPetAgeException(string message) : base(message) { }
    }
}
