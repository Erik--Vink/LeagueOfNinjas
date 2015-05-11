using LeagueOfNinjas.Model.DataAccess;
using LeagueOfNinjas.Model.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Utillity
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().To<RepositoryFactory>();
        }
    }
}
