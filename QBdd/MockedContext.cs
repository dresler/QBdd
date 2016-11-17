using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace QBdd
{
    /// <summary>
    /// Represents context of given type instance with its dependecies in form of mocks.
    /// It provides equivalent methods like in RhinoMocks extensions.
    /// </summary>
    /// <typeparam name="TUnderTest">Type under test. The type must have only one constructor and each parameter must be of interface type.</typeparam>
    public class MockedContext<TUnderTest>
    {
        private readonly IEnumerable<object> _mocks; 

        public TUnderTest UnderTest { get; }

        /// <summary>
        /// Constructor is called by Mockery.
        /// </summary>
        /// <param name="underTest">Instance of type under test.</param>
        /// <param name="mocks">Mocks of type dependencies</param>
        internal MockedContext(TUnderTest underTest, params object[] mocks)
        {
            UnderTest = underTest;
            _mocks = mocks;
        }

        public IMethodOptions<object> Stub<TMock>(Action<TMock> action)
            where TMock : class
        {
            return Get<TMock>().Stub(action);
        }

        public void AssertWasCalled<TMock>(Func<TMock, object> function)
        {
            Get<TMock>().AssertWasCalled(function);
        }

        public void AssertWasCalled<TMock>(Func<TMock, object> function, Action<IMethodOptions<object>> setupConstraints)
        {
            Get<TMock>().AssertWasCalled(function, setupConstraints);
        }

        public void AssertWasCalled<TMock>(Action<TMock> action)
        {
            Get<TMock>().AssertWasCalled(action);
        }

        public void AssertWasCalled<TMock>(Action<TMock> action, Action<IMethodOptions<object>> setupConstraints)
        {
            Get<TMock>().AssertWasCalled(action, setupConstraints);
        }

        public void AssertWasNotCalled<TMock>(Func<TMock, object> function)
        {
            Get<TMock>().AssertWasNotCalled(function);
        }

        public void AssertWasNotCalled<TMock>(Action<TMock> action)
        {
            Get<TMock>().AssertWasNotCalled(action);
        }

        public static implicit operator TUnderTest(MockedContext<TUnderTest> mockedContext)
        {
            return mockedContext.UnderTest;
        }

        private TMock Get<TMock>()
        {
            return _mocks.OfType<TMock>().Single();
        }
    }
}