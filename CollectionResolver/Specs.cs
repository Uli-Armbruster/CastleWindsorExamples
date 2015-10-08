using System.Linq;

using Castle.Windsor;

using CollectionResolver.Sample1;

using FluentAssertions;

using Machine.Specifications;


namespace CollectionResolver
{
    internal class Specs
    {
        [Subject("Container Registrations")]
        private class When_all_IFoo_implementations_are_resolved
        {
            private static IWindsorContainer _container;

            private static IFoo[] _registrations;

            private Establish context = () =>
                                        {
                                            _container = new WindsorContainer();
                                            _container.Install(new Installer());
                                        };

            private Because of = () => { _registrations = _container.ResolveAll<IFoo>(); };

            private It should_find_3_implementations = () => { _registrations.Length.Should().Be(3); };
        }
    }
}