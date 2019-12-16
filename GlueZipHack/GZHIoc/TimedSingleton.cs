using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZHIoc
{
	public class TimedSingleton
	{
		private static MemoryCache TimedSingletonCache { get; set; } = new MemoryCache(new MemoryCacheOptions());
		private TimeSpan _expirationTimeSpan { get; set; }
		public TimedSingleton(TimeSpan expirationTimeSpan)
		{
			_expirationTimeSpan = expirationTimeSpan;
  }
		public Func<T> SingletonFunc<T>(Func<T> func)
		{
		
			return (() => 
			{
				T singletonValue = TimedSingletonCache.GetOrCreate("TimedSingletonCache", cacheEntry =>
				{
					cacheEntry.SetAbsoluteExpiration(_expirationTimeSpan);
					return func.Invoke();
				});
				return singletonValue;
   
   });
		}
	}
}
