using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Interfaces
{
    public interface IDataAccessProvider
    {
        IList<T> GetAll<T>() where T : class;
        string Delete<T>(string[] keys) where T : class;
        string Create<T>(T entity) where T : class;
        string Update<T>(string[] keys, T updatedEntity) where T : class;
    }
}
