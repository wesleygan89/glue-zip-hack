using System;
using System.Collections.Concurrent;
namespace GZHIoc
{
	public class Resolver
	{

		private ConcurrentDictionary<Type, object> typeToCreator
					   = new ConcurrentDictionary<Type, object>();
		public void Register<T>(Func<T> func, Func<Func<T>, Func<T>> lifeTimeTypeFunc =  null)
		{
			if (lifeTimeTypeFunc==null)
			{
				lifeTimeTypeFunc = LifeTimeType.TransientFunc;
			}
			typeToCreator.TryAdd(typeof(T), lifeTimeTypeFunc(func));
		}

		public T Create<T>()
		{
			return ((Func<T>)typeToCreator[typeof(T)]).Invoke();
		}

	}
}
