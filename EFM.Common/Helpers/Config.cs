using System;
using System.Configuration;

namespace EFM.Common.Helpers
{
    public class Config
    {
        public static string GetByKey(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value == null ? throw new Exception($"Config key '{key}' not found.") : value;
        }
    }
}
