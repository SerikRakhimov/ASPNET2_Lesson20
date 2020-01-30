using Microsoft.AspNetCore.Mvc;
using Ninject;
using SaveTimeCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTimeCore.Controllers
{
    public class BaseController:Controller
    {
        protected IKernel kernel;

        public BaseController()
        {
            kernel = new StandardKernel(new RepositoryModule());
        }
    }
}