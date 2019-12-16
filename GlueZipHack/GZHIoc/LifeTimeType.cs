using System;
using System.Collections.Generic;
using System.Text;

namespace GZHIoc
{
	public class LifeTimeType
	{

		public static Func<T> SingletonFunc<T>(Func<T> func)
		{
			var singletonValue = func.Invoke();
			return (() => { return singletonValue; });
		}

		public static Func<T> TransientFunc<T>(Func<T> func)
		{
			return func;
		}
	}
}
