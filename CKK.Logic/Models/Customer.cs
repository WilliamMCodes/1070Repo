using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        public string Address { get; set; }

        public Customer(int id = 00000001, string name = "New Customer", string address = "888 Some Rd This Town, This State 00000") : base(id, name)
        {
            Address = address;
        }
    }
}
