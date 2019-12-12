
using GlueZipHack.ConfigN;

namespace GlueZipHack.HandlerN
{
public interface IBaseHandler 
	{
		IBaseConfig BaseConfig { get; set; }
		void Handle();
	}
}
