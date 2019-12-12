using System;
using System.Collections.Concurrent;
namespace GZHIoc
{
	public class Resolver
	{

		private readonly ConcurrentDictionary<Type, object> typeToCreator
					   = new ConcurrentDictionary<Type, object>();
		public void Register<T>(Func<T> func)
		{
			typeToCreator.TryAdd(typeof(T), func);
		}

		public T Create<T>()
		{
			return ((Func<T>)typeToCreator[typeof(T)]).Invoke();
		}

	}
}
