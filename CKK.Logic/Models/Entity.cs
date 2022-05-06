using System;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
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
