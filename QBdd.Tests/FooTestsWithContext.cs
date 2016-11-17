using NUnit.Framework;

namespace QBdd.Tests
{
    [TestFixture]
    public class FooTestsWithContext
    {
        [Test]
        public void FooMethod_ForBarFunctionReturning1_ShouldReturn1()
        {
            var mockedFoo = Mockery.Create<Foo>();
            mockedFoo.Stub<IBar>(x => x.BarFunction()).Return(1);

            var result = mockedFoo.UnderTest.FooMethod();

            Assert.AreEqual(1, result);
        }
    }
}
