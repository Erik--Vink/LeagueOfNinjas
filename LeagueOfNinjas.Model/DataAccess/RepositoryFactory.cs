using LeagueOfNinjas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.DataAccess
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, Type> _repositoryTypes;

        public RepositoryFactory()
        {
            _repositoryTypes = new Dictionary<Type, Type>();

            var entityTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where t.IsClass && t.Namespace == "LeagueOfNinjas.Model.Models" && !t.IsDefined(typeof(CompilerGeneratedAttribute), false)
                              select t;
            var repositoryTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where t.IsClass && t.Namespace == "LeagueOfNinjas.Model.Repositories" && !t.IsDefined(typeof(CompilerGeneratedAttribute), false)
                                  select t;

            var entityTypesList = entityTypes as IList<Type> ?? entityTypes.ToList();
            foreach (var rt in repositoryTypes)
            {
                var rt1 = rt;
                foreach (var et in entityTypesList.Where(et => rt1.Name.Replace("Repository", "") == et.Name))
                {
                    _repositoryTypes.Add(et, rt);
                }
            }
        }

        public IGenericRepository<T> CreateRepository<T>() where T : class
        {
            var requestedEntityType = typeof(T);
            Type requestedRepositoryType;

            _repositoryTypes.TryGetValue(requestedEntityType, out requestedRepositoryType);

            dynamic repository = null;
            if (requestedRepositoryType != null)
                repository = Activator.CreateInstance(requestedRepositoryType);

            return repository;
        }
    }
}
