namespace GlueZipHack.ConfigN
{
	public class BaseConfig : IBaseConfig
	{
		public string LogPath { get; set; }
		public BaseConfig()
		{
			LogPath = "c:\\logss\\";
  }
	}
}
