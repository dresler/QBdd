using NUnit.Framework;
using Rhino.Mocks;

namespace QBdd.Tests
{
    [TestFixture]
    public class FooTestsWithoutContext
    {
        [Test]
        public void FooMethod_ForBarFunctionReturning1_ShouldReturn1()
        {
            var barMock = MockRepository.GenerateMock<IBar>();
            var fuzzMock = MockRepository.GenerateMock<IFuzz>();

            barMock.Stub(x => x.BarFunction()).Return(1);

            var underTest = new Foo(barMock, fuzzMock);

            var result = underTest.FooMethod();

            Assert.AreEqual(1, result);
        }
    }
}