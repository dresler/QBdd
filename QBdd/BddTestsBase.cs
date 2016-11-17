using NUnit.Framework;

namespace QBdd
{
    /// <summary>
    /// Base class for BDD tests.
    /// </summary>
    [TestFixture]
    public abstract class BddTestsBase
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        protected virtual void Given() { }
        protected virtual void When() { }
    }

    /// <summary>
    /// Base class for BDD tests with support for MockedContext.
    /// </summary>
    /// <typeparam name="TUnderTest">Type under tests.</typeparam>
    [TestFixture]
    public abstract class BddTestsBase<TUnderTest>
        where TUnderTest : class
    {
        protected MockedContext<TUnderTest> Context { get; private set; }

        [OneTimeSetUp]
        public new void SetUp()
        {
            Context = Mockery.Create<TUnderTest>();

            Given();
            When();
        }

        protected abstract void Given();
        protected abstract void When();
    }
}