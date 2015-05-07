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
    public class CategoryRepository : IGenericRepository<Category>
    {
        public AppContext Context { get; set; }

        public IEnumerable<Category> GetAll()
        {
            return Context.Category.AsEnumerable();
        }

        public Category GetOne(string[] keys)
        {
            if (keys.Count() != 1) throw new ArgumentOutOfRangeException("keys", "Method only takes an array with 1 element as correct parameter.");
            return Context.Category.Find(keys[0]);
        }

        public void Delete(Category entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(Category entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Category originalEntity, Category updatedEntity)
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
