using System;


namespace CollectionResolver.Sample1
{
    internal abstract class FooBase : IFoo
    {
        protected abstract string Name { get; }

        public void SayMyName()
        {
            Console.WriteLine(Name);
        }
    }
}