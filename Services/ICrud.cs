using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPWeb.Services
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T newT);
        T Update(T updatedT);
        T Delete(int id);
    }
}