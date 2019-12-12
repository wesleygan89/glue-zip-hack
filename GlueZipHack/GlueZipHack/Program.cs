using GlueZipHack.ConfigN;
using GlueZipHack.HandlerN;
using GZHIoc;

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
			});
			resolver.Register<IBaseHandler>(() =>
			{
				return new BaseHandler(resolver.Create<IBaseConfig>());
			});
			var handler = resolver.Create<IBaseHandler>();
			handler.Handle();
		}
	}
}
