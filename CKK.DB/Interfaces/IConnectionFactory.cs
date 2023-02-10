using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CKK.DB.Interfaces
{
    public interface IConnectionFactory 
    {
        IDbConnection GetConnection { get; }
    }
}
