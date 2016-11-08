using System;
using System.Collections.Generic;

namespace LightInject
{
    internal static class EnumerableTypeExtensions
    {
        private static readonly ThreadSafeDictionary<Type, Type> EnumerableTypes = new ThreadSafeDictionary<Type, Type>();

        public static Type GetEnumerableType(this Type returnType)
        {
            return EnumerableTypes.GetOrAdd(returnType, CreateEnumerableType);
        }

        private static Type CreateEnumerableType(Type type)
        {
            return typeof(IEnumerable<>).MakeGenericType(type);
        }
    }
}