using NUnit.Framework;
using Rhino.Mocks;

namespace QBdd.Tests
{
    /// <summary>
    /// Example of a usage of BddTestsBase without support of MockedContext.
    /// </summary>
    public class When_FooMethod_Without_Context : BddTestsBase
    {
        private IBar barMock;
        private IFuzz fuzzMock;
        private Foo UnderTest;

        private int _result;

        protected override void Given()
        {
            barMock = MockRepository.GenerateMock<IBar>();
            fuzzMock = MockRepository.GenerateMock<IFuzz>();

            UnderTest = new Foo(barMock, fuzzMock);

            barMock.Stub(x => x.BarFunction()).Return(1);
        }

        protected override void When()
        {
            _result = UnderTest.FooMethod();
        }

        [Then]
        public void ShouldReturnExpected()
        {
            Assert.AreEqual(1, _result);
        }

        [Then]
        public void ShouldCallFuzzMethod()
        {
            fuzzMock.AssertWasCalled(x => x.FuzzMethod(Arg<int>.Is.Anything));
        }
    }
}