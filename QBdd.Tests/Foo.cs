namespace QBdd.Tests
{
    public class Foo
    {
        private IBar Bar { get; }
        private IFuzz Fuzz { get; }

        public Foo(IBar bar, IFuzz fuzz)
        {
            Bar = bar;
            Fuzz = fuzz;
        }

        public int FooMethod()
        {
            var valueFromBar = Bar.BarFunction();
            Fuzz.FuzzMethod(valueFromBar);
            return valueFromBar;
        }
    }

    public interface IFuzz
    {
        void FuzzMethod(int param);
    }

    public interface IBar
    {
        int BarFunction();
    }
}