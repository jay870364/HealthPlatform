using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.Models.TaiDoc
{
    public class TaiDocResultData
    {
        public TaiDocResultData()
        {
            Data = new List<Data>();
        }
        public bool Success { get; set; }

        public List<Data> Data { get; set; }
    }

    public class Data
    {
        public string ID { get; set; }

        public string MeasureTime { get; set; }

        public string Systolic { get; set; }

        public string Diastolic { get; set; }

        public string Heartbeat { get; set; }

        public string Oxygen { get; set; }

        public string Sugar { get; set; }

        public string Temperature { get; set; }
    }
}
