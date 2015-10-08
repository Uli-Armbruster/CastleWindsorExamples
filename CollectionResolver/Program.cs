using System;
using System.Linq;

using Castle.Windsor;

using CollectionResolver.Sample1;


namespace CollectionResolver
{
    internal class Program
    {
        private static void Main()
        {
            var container = new WindsorContainer();
            container.Install(new Installer());

            var bar = container.Resolve<IBar>();
            bar.TellMeYourNames();


            Console.ReadLine();
        }
    }
}