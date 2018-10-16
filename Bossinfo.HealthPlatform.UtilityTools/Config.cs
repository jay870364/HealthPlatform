using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.UtilityTools
{
    public class Config
    {
        /// <summary>
        /// 讀取configAPPSettings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 讀取config連線
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConn(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ToString();
        }

        /// <summary>
        /// DES Key
        /// </summary>
        public static string DESKey
        {
            get
            {
                return GetConfig("DESKey");
            }
        }

        /// <summary>
        /// DES Key
        /// </summary>
        public static string DESIV
        {
            get
            {
                return GetConfig("DESIV");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string BaseURL
        {
            get
            {
                return GetConfig("BaseURL");
            }
        }

        public static string InitialDataFile
        {
            get
            {
                return GetConfig("InitialDBData");
            }
        }

        public static string RedirectUrl
        {
            get
            {
                return GetConfig("RedirectUrl");
            }
        }

        public static string HtmlTitle
        {
            get
            {
                return GetConfig("HtmlTitle");
            }
        }
    }
}
