using LeagueOfNinjas.Model.Context;
using LeagueOfNinjas.Model.Interfaces;
using LeagueOfNinjas.Model.Utillity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly RepositoryFactory _repositoryFactory;

        public DataAccessProvider(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IList<T> GetAll<T>() where T : class
        {
            using (var context = new AppContext())
            {
                var repository = _repositoryFactory.CreateRepository<T>();
                repository.Context = context;
                return repository.GetAll().ToList();
            }
        }

        public string Delete<T>(string[] keys) where T : class
        {
            using (var context = new AppContext())
            {
                var repository = _repositoryFactory.CreateRepository<T>();
                repository.Context = context;

                try
                {
                    var entityToDelete = repository.GetOne(keys);
                    repository.Delete(entityToDelete);
                    repository.Save();
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException) return DomainConstants.DbErrorFkConstraint;
                    if (ex is ArgumentOutOfRangeException) return DomainConstants.DbErrorPkInvalid;

                    return DomainConstants.DbErrorStandard;
                }
            }
            return null;
        }

        public string Create<T>(T entity) where T : class
        {
            using (var context = new AppContext())
            {
                var repository = _repositoryFactory.CreateRepository<T>();
                repository.Context = context;
                try
                {
                    repository.Create(entity);
                    repository.Save();
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException) return DomainConstants.DbErrorPkDuplicate;
                    if (ex is DbEntityValidationException) return DomainConstants.DbErrorNoSelection;

                    return DomainConstants.DbErrorStandard;
                }
            }
            return null;
        }

        public string Update<T>(string[] keys, T updatedEntity) where T : class
        {
            using (var context = new AppContext())
            {
                var repository = _repositoryFactory.CreateRepository<T>();
                repository.Context = context;

                try
                {
                    var entityToUpdate = repository.GetOne(keys);
                    repository.Update(entityToUpdate, updatedEntity);
                    repository.Save();
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException) return DomainConstants.DbErrorFkConstraint;
                    if (ex is InvalidOperationException) return DomainConstants.DbErrorPkChanged;
                    if (ex is ArgumentOutOfRangeException) return DomainConstants.DbErrorPkInvalid;

                    return DomainConstants.DbErrorStandard;
                }
            }
            return null;
        }
    }
}
