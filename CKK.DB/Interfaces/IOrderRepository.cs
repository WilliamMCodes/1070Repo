using System;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetOrderByCustomerId(int id);
    }
}
