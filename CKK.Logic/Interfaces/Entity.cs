using System;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        public string Name { get; set; }

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id
        {
            get
            {
                return Id;
            }
            set
            {
                if(value < 0)
                {
                    throw new InvalidIdException(value);
                }
            }
        }
    }
}
