using Castle.Core.Internal;


namespace CollectionResolver.Sample1
{
    internal class Bar : IBar
    {
        private readonly IFoo[] _foos;

        public Bar(IFoo[] foos)
        {
            _foos = foos;
        }

        public void TellMeYourNames()
        {
            _foos.ForEach(foo => foo.SayMyName());
        }
    }
}