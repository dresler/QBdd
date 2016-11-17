using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;

namespace QBdd
{
    /// <summary>
    /// It is responsible for creation of MockedContext instances.
    /// </summary>
    public static class Mockery
    {
        /// <summary>
        /// Creates a context with instance of given type.
        /// </summary>
        /// <typeparam name="TUnderTest">Type under test.</typeparam>
        /// <returns>Instance of Type wrapped in MockedContext. It provides methods to control dependencies.</returns>
        public static MockedContext<TUnderTest> Create<TUnderTest>()
            where TUnderTest : class
        {
            var constructorParameterTypes = GetConstructorParameterTypes<TUnderTest>();
            var mocks = constructorParameterTypes.Select(CreateMock).ToArray();
            var underTestInstance = Activator.CreateInstance(typeof(TUnderTest), mocks) as TUnderTest;

            return new MockedContext<TUnderTest>(underTestInstance, mocks);
        }

        private static object CreateMock(Type type)
        {
            return MockRepository.GenerateMock(type, new Type[0]);
        }

        private static IReadOnlyList<Type> GetConstructorParameterTypes<T>()
        {
            var publicConstructors = typeof(T).GetConstructors();

            if (publicConstructors.Count() != 1)
            {
                throw new InvalidOperationException($"Type {typeof(T).Name} must have only one public constructor.");
            }

            var parameterTypes = publicConstructors.First().GetParameters().Select(p => p.ParameterType).ToList();

            var parameterNonInterface = parameterTypes.FirstOrDefault(pt => !pt.IsInterface);
            if (parameterNonInterface != null)
            {
                throw new InvalidOperationException($"The parameter of type {parameterNonInterface} in {typeof(T).Name} constructor is not of interface type.");
            }

            return parameterTypes;
        }
    }
}