using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PetPals.entity;

namespace PetPals.dao
{
    public interface IAdoptable
    {
        public void Adopt(Pet pet, Participant participant);
    }
}
