using Ninject.Modules;
using SaveTimeCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Modules
{
    public class RepositoryModule: NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}