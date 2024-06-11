using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace Dashboard.Common.Configuration
{
    public class AppConfigs
    {
        private static IConfiguration _configuration;
        public static void LoadAll(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiUrlBase = GetConfigValue("Appconfig:ApiUrlBase", "");
            //FullPath = GetConfigValue("Appconfig:FullPath", "wwwroot\\upload\\");
            //MinFollowersPage = GetConfigValue("Criteria:MinFollowersPage", 100);
            //MinMemberGroup = GetConfigValue("Criteria:MinMemberGroup", 1000);
            //MinPostPerDayGroup = GetConfigValue("Criteria:MinPostPerDayGroup", 5);
            //MinResultSearch = GetConfigValue("Criteria:MinResultSearch", 100);
            //RandomScrollMin = GetConfigValue("RandomConfig:RandomScrollMin", 378);
            //RandomScrollMax = GetConfigValue("RandomConfig:RandomScrollMax", 683);
            //RandomDelayMin = GetConfigValue("RandomConfig:RandomDelayMin", 3000);
            //RandomDelayMax = GetConfigValue("RandomConfig:RandomDelayMax", 15500);
            //BravePath = GetConfigValue("Appconfig:BravePath", "");
        }
        public static string FullPath { get; set; }
        public static int MinFollowersPage { get; set; }
        public static int MinMemberGroup { get; set; }
        public static int MinPostPerDayGroup { get; set; }
        public static int MinResultSearch { get; set; }
        public static int RandomScrollMin { get; set; }
        public static int RandomScrollMax { get; set; }
        public static int RandomDelayMin { get; set; }
        public static int RandomDelayMax { get; set; }
        public static int OriginGateChrome = 9000;
        public static string BravePath = "";

        public static string ApiUrlBase { get; set; }
        public static int IdUser { get; set; }
        public static string HardwareId { get; set; } = "";
        private static T GetConfigValue<T>(string configKey, T defaultValue)
        {
            var value = defaultValue;
            var converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                if (converter != null)
                {
                    var setting = _configuration.GetSection(configKey).Value;
                    if (!string.IsNullOrEmpty(setting))
                    {
                        value = (T)converter.ConvertFromString(setting);
                    }
                }
            }
            catch
            {
                value = defaultValue;
            }
            return value;
        }

    }
}
