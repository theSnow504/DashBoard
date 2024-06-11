using Dashboard.Common.Configuration;


namespace SmartBot.Common.Helpers
{
	public class TelerikHelper
	{
		public static string PathFileTypeExtention(string fileType)
		{
			var result = AppConfigs.FullPath + "extention/"+fileType.Replace(".","")+"/"+ fileType.Replace(".", "") + ".png";
            return result;
		}
	}
}
