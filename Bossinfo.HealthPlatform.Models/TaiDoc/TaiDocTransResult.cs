using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.Models.TaiDoc
{
    public class TaiDocTransResult
    {
        /// <summary>
        /// 身分證號碼
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 量測時間 yyyyMMdd hh:mm:ss:fff
        /// </summary>
        public DateTime? MeasureTime { get; set; }

        /// <summary>
        /// 收縮壓
        /// </summary>
        public int Systolic { get; set; }

        /// <summary>
        /// 舒張壓
        /// </summary>
        public int Diastolic { get; set; }

        /// <summary>
        /// 心跳
        /// </summary>
        public int Heartbeat { get; set; }

        /// <summary>
        /// 血氧
        /// </summary>
        public int Oxygen { get; set; }

        /// <summary>
        /// 血糖
        /// </summary>
        public int Sugar { get; set; }

        /// <summary>
        /// 體溫
        /// </summary>
        public decimal Temperature { get; set; }
    }
}
