using GlueZipHack.ConfigN;
using GlueZipHack.HandlerN;
using GZHIoc;
using System;

namespace GlueZipHack
{
	class Program
	{
		static void Main(string[] args)
		{
		
			Resolver resolver = new Resolver();
			resolver.Register<IBaseConfig>(() =>
			{
				return new BaseConfig();
			}, LifeTimeType.SingletonFunc);


			var f1 = new Func<IBaseHandler> (()=>
			{
			 return new BaseHandler(resolver.Create<IBaseConfig>());
		});
		var f = new TimedSingleton(new System.TimeSpan(0, 0, 4)).SingletonFunc<IBaseHandler>(f1);



			resolver.Register(
				new TimedSingleton(new System.TimeSpan(0, 0, 4))
				.SingletonFunc(
					new Func<IBaseHandler>(
						() =>
			{
				return new BaseHandler(resolver.Create<IBaseConfig>());
			})
					));


			var handler = resolver.Create<IBaseHandler>();
			handler.Handle();
			var handler2 = resolver.Create<IBaseHandler>();
			handler2.Handle();
			System.Threading.Thread.Sleep(5000);
			var handler3 = resolver.Create<IBaseHandler>();
			handler3.Handle();
			var handler4 = resolver.Create<IBaseHandler>();
			handler4.Handle();

		}
	}
}
