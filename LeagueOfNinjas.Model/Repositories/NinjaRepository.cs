using LeagueOfNinjas.Model.Context;
using LeagueOfNinjas.Model.Interfaces;
using LeagueOfNinjas.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Repositories
{
    public class NinjaRepository : IGenericRepository<Ninja>
    {
        public AppContext Context { get; set; }

        public IEnumerable<Ninja> GetAll()
        {
            return Context.Ninja.AsEnumerable();
        }

        public Ninja GetOne(string[] keys)
        {
            if (keys.Count() != 1) throw new ArgumentOutOfRangeException("keys", "Method only takes an array with 1 element as correct parameter.");
            return Context.Ninja.Find(keys[0]);
        }

        public void Delete(Ninja entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(Ninja entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Ninja originalEntity, Ninja updatedEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(updatedEntity);
            Context.Entry(originalEntity).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
