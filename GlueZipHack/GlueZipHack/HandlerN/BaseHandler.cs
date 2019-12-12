
using GlueZipHack.ConfigN;

namespace GlueZipHack.HandlerN
{
	public class BaseHandler : IBaseHandler
	{
		public IBaseConfig BaseConfig { get; set; }
		public BaseHandler(IBaseConfig baseConfig)
		{
			BaseConfig = baseConfig;
  }
		public void Handle()
		{
			System.IO.File.WriteAllText($"{BaseConfig.LogPath}tes.txt","123");
		}
	}
}
