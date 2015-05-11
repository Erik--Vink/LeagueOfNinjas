using LeagueOfNinjas.Model.Utillity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.DataAccess
{
    public class DataServiceLocator
    {
        private static DataServiceLocator _dataServiceLocator;
        private readonly StandardKernel _kernel;
        private DataAccessProvider _dataAccessProvider;

        private DataServiceLocator()
        {
            _kernel = new StandardKernel(new Bindings());
        }

        public static DataServiceLocator Instance
        {
            get { return _dataServiceLocator ?? (_dataServiceLocator = new DataServiceLocator()); }
        }

        public DataAccessProvider DataAccessProvider
        {
            get { return _dataAccessProvider ?? (_dataAccessProvider = _kernel.Get<DataAccessProvider>()); }
        }

    }
}
