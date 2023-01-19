using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CKK.DB.Interfaces
{
    internal interface IGenericRepository<T>
    {

        T GetbyId(int id);
        List<T> GetAll();
        int Add(int id);
        int Update(int id);
        int Delete(int id);
    }
}
