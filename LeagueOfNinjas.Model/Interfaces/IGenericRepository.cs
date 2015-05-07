using LeagueOfNinjas.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        AppContext Context { get; set; }
        IEnumerable<T> GetAll();
        T GetOne(string[] keys);
        void Delete(T entity);
        void Create(T entity);
        void Update(T originalEntity, T updatedEntity);
        void Save();
    }
}
