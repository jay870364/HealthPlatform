using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bossinfo.HealthPlatform.Models.TaiDoc
{
    public static class TaiDocDataType
    {
        public static Dictionary<string, string> DataType = new Dictionary<string, string>
        {
            {"1", "BG,°C,CodeNo,MeasureType,HCT,HB" } ,
            {"2", "BP_Systolic,BP_Diastolic,BP_Pulse,MeanPressure,AverageMeasurement,IHB_Index" } ,
            {"7", "SPO2,HeartRate" } ,
            {"8", "Weigh,BodyFat,BMI" } ,
            {"11", "Ketone,,,,HCT,HB" } ,
            {"12", "Cholesterol,,,,HCT,HB" } ,
            {"13", "UricAcid,,,,HCT,HB" } ,
            {"14", "HbA1c" } ,
            {"41", "Step,Min" } ,
            {"42", "HeartRate" } ,
            {"60", "EarTemperture" } ,
            {"61", "ForeheadTemperture" } ,
            {"901" , "Height" } ,
            {"902" , "RespiratoryRate" } ,
            {"903" , "PainIndex" } ,
            {"904" , "BowelMovement" }
        };

        public static Dictionary<string, string> GetSlotType(string dataType)
        {
            Dictionary<string, string> SlotTye;
            switch (dataType)
            {
                case "1":
                    SlotTye = new Dictionary<string, string>()
                    {
                        {"1", "晨起" },
                        {"2", "早餐前" },
                        {"3", "早餐後" },
                        {"4", "午餐前" },
                        {"5", "午餐後" },
                        {"6", "晚餐前" },
                        {"7", "晚餐後" },
                        {"8", "睡前" },
                        {"9", "凌晨" },
                    };
                    break;
                case "2":
                    SlotTye = new Dictionary<string, string>()
                    {
                        {"1", "晨起" },
                        {"2", "早上" },
                        {"3", "中午" },
                        {"4", "下午" },
                        {"5", "晚上" },
                    };
                    break;
                case "7":
                    SlotTye = new Dictionary<string, string>()
                    {
                        {"1", "整天" }
                    };
                    break;
                case "8":
                case "60":
                case "61":
                    SlotTye = new Dictionary<string, string>()
                    {
                        {"1", "早上" },
                        {"2", "下午" },
                        {"3", "晚上" },
                    };
                    break;

                case "11":
                case "12":
                case "13":
                case "14":
                case "41":
                case "42":
                case "43":
                case "901":
                case "902":
                case "903":
                case "904":
                default:
                    SlotTye = null;
                    break;
            }

            return SlotTye;
        }


    }
}