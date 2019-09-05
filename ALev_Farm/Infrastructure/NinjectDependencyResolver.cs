using DAL;
using DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ALev_Farm.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            IFarmContext farmContext = new FarmContext();
            kernel.Bind<IFarmRepository>().To<FarmRepository>().WithConstructorArgument("context", farmContext);
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("context", farmContext);
            kernel.Bind<IFarmContext>().To<FarmContext>();
        }
    }
}