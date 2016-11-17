using NUnit.Framework;

namespace QBdd.Tests
{
    [TestFixture]
    public class FooTestsWithContext
    {
        [Test]
        public void FooMethod_ForBarFunctionReturning1_ShouldReturn1()
        {
            var fooContext = Mockery.Create<Foo>();
            fooContext.Stub<IBar>(x => x.BarFunction()).Return(1);

            var result = fooContext.UnderTest.FooMethod();

            Assert.AreEqual(1, result);
        }
    }
}
