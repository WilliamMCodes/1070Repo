using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CKK.DB.Interfaces
{
    internal interface IConnectionFactory 
    {
        IDbConnection GetConnection { get; }
    }
}
