using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.Models
{
    public class Minfo
    {
        public string DeviceID { get; set; }
        public string Member_IDNo { get; set; }
        public string BP { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyFat { get; set; }
        public string BMI { get; set; }
        public string HbA1c { get; set; }
        public string Ketone { get; set; }
        public string BG { get; set; }
        public string BG_Type { get; set; }
        public string Cholesterol { get; set; }
        public string UricAcid { get; set; }
        public string BP_Systolic { get; set; }
        public string BP_Diastolic { get; set; }
        public string HeatRate { get; set; }
        public string BodyTemperture { get; set; }
        public string EarTemperture { get; set; }
        public string ForHeadTemperture { get; set; }
        public string SPO2 { get; set; }
        public string RespiratoryRate { get; set; }
        public string PainIndex { get; set; }
        public string BowelMovement { get; set; }
        public string DataTime { get; set; }
        public int Source_SN { get; set; }
    }
}
