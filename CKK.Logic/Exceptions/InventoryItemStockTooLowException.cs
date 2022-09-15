using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public override string Message { get; }
        public InventoryItemStockTooLowException(int quantity)
        {
            Message = $"{quantity} is not a valid amount for this action.";
        }
    }
}
