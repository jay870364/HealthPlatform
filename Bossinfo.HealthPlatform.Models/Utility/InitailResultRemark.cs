using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.Models.Utility
{
    public class InitialResultRemark
    {
        InitialResultRemark()
        {
            List<Unit> Result = new List<Unit>();
        }


        public List<Unit> Result { get; set; }
    }

    public class Unit
    {
        public string Type { get; set; }

        public string Level { get; set; }

        public string LowRange { get; set; }

        public string HightRange { get; set; }

        public string Message { get; set; }

    }
}
