[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineShopburgertwohomeWebUi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineShopburgertwohomeWebUi.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineShopburgertwohomeWebUi.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Moq;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using OneshopburgertwohomeDomain.Abstract;
    using OneshopburgertwohomeDomain.Concrete;
    using OneshopburgertwohomeDomain.Entities;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //Mock<IProductRepository> Mocks  = new Mock<IProductRepository>();
            //Mocks.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product{Libelle = "burger au bacon", Prix = 23},
            //    new Product{Libelle = "Fish burger", Prix = 20},
            //    new Product{Libelle = "burger vegan", Prix = 15},
            //    new Product{Libelle = "veggie", Prix = 22},
            //    new Product{Libelle = "Cheese burger", Prix = 21}
            //});
            //kernel.Bind<IProductRepository>().ToConstant(Mocks.Object);
        }
    }
}