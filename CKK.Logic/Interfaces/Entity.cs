using System;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        private int id;
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
                return id;
            }
            set
            {
                if(value < 0)
                {
                    throw new InvalidIdException(value);
                }
                id = value;
            }
        }
    }
}
