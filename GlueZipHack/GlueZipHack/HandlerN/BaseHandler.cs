
using GlueZipHack.ConfigN;

namespace GlueZipHack.HandlerN
{
	public class BaseHandler : IBaseHandler
	{
		public IBaseConfig BaseConfig { get; set; }
		private int testVar { get; set; }
		public BaseHandler(IBaseConfig baseConfig)
		{
			BaseConfig = baseConfig;
  }
		public void Handle()
		{
			System.IO.File.WriteAllText($"{BaseConfig.LogPath}{testVar}_tes.txt","123_"+testVar.ToString());
			testVar += 1;
		}
	}
}
