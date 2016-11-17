using NUnit.Framework;
using Rhino.Mocks;

namespace QBdd.Tests
{
    /// <summary>
    /// Example of a usage of BddTestsBase<T>.
    /// </summary>
    public class When_FooMethod: BddTestsBase<Foo>
    {
        private int _result;

        protected override void Given()
        {
            Context.Stub<IBar>(x => x.BarFunction()).Return(1);
        }

        protected override void When()
        {
            _result = Context.UnderTest.FooMethod();
        }

        [Then]
        public void ItShouldReturnExpected()
        {
            Assert.AreEqual(1, _result);
        }

        [Then]
        public void ItShouldCallFuzzMethod()
        {
            Context.AssertWasCalled<IFuzz>(x => x.FuzzMethod(Arg<int>.Is.Anything));
        }
    }
}