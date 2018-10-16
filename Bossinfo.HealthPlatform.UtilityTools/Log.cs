using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.UtilityTools
{
    public class Log
    {
        public static NLog.Logger log;

        public Log()
        {
            log = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Trace(string message)
        {
            Trace(message, null);
        }

        public void Trace(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            msg += System.Environment.NewLine;
            msg += "--------------------------------------------";
            msg += System.Environment.NewLine;

            log.Trace(msg);

            System.Diagnostics.Debug.WriteLine(msg);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Error(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            log.Error(msg);

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now}:{msg}");
        }

        public void Warn(string message)
        {
            log.Warn(message);
        }

        public void Info(string message)
        {
            Info(message, null);
        }

        public void Info(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            log.Info(msg);

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now}:{msg}");
        }
    }
}
