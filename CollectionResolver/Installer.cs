using System.Collections.Generic;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using CollectionResolver.Sample1;


namespace CollectionResolver
{
    public class Installer : IWindsorInstaller
    {
        /// <summary>
        ///     Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new Castle.MicroKernel.Resolvers.SpecializedResolvers.CollectionResolver(container.Kernel));
            container.Register(Components().ToArray());
        }

        private static IEnumerable<IRegistration> Components()
        {
            //have a look at https://github.com/castleproject/Windsor/blob/master/docs/registering-components-by-conventions.md

            yield return Classes //non abstract classes; you could also use Types.* for more choices
                .FromThisAssembly() //should be clear
                .IncludeNonPublicTypes() //since my implementations are internal, only the interface is public
                .BasedOn<IFoo>() //every class that implements this interface
                .WithService.Base() //also possible: .WithServiceFromInterface()
                .LifestyleTransient();

            yield return Component
                .For<IBar>()
                .ImplementedBy<Bar>()
                .LifestyleTransient();
        }
    }
}