using System;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
