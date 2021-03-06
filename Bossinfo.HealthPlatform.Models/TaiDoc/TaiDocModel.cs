﻿using System;
using System.Collections.Generic;

namespace Bossinfo.HealthPlatform.Models.TaiDoc
{
    [Serializable]
    public class TaiDocModel
    {
        /// <summary>
        /// 機器編號
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// 身分證號碼
        /// </summary>
        public string Member_IDNo { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 體重
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// 體脂肪
        /// </summary>
        public string BodyFat { get; set; }

        /// <summary>
        /// BMI
        /// </summary>
        public string BMI { get; set; }

        /// <summary>
        /// 糖化血色素
        /// </summary>
        public string HbA1c { get; set; }

        /// <summary>
        /// 酮體
        /// </summary>
        public string Ketone { get; set; }

        /// <summary>
        /// 血糖
        /// </summary>
        public string BG { get; set; }

        /// <summary>
        /// 血糖量測類別
        /// 0:一般 ; 1:飯前; 2:飯後; 3:測試
        /// </summary>
        public string BG_Type { get; set; }

        /// <summary>
        /// 膽固醇
        /// </summary>
        public string Cholesterol { get; set; }

        /// <summary>
        /// 尿酸
        /// </summary>
        public string UricAcid { get; set; }

        /// <summary>
        /// 血壓 - 收縮壓
        /// </summary>
        public string BP_Systolic { get; set; }

        /// <summary>
        /// 血壓 - 舒張壓
        /// </summary>
        public string BP_Diastolic { get; set; }

        /// <summary>
        /// 心跳
        /// </summary>
        public string HeartRate { get; set; }

        /// <summary>
        /// 體溫
        /// </summary>
        public string BodyTemperture { get; set; }

        /// <summary>
        /// 耳溫
        /// </summary>
        public string EarTemperture { get; set; }

        /// <summary>
        /// 額溫
        /// </summary>
        public string ForeheadTemperture { get; set; }

        /// <summary>
        /// 血氧濃度
        /// </summary>
        public string SPO2 { get; set; }

        /// <summary>
        /// 呼吸頻率
        /// </summary>
        public string RespiratoryRate { get; set; }

        /// <summary>
        /// 疼痛指數
        /// </summary>
        public string PainIndex { get; set; }

        /// <summary>
        /// 排便次數
        /// </summary>
        public string BowelMovement { get; set; }

        /// <summary>
        /// 資料日期時間
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 來源內部編號
        /// </summary>
        public decimal Source_SN { get; set; }

        /// <summary>
        /// Feedback
        /// </summary>
        public List<Feedback> Feedback { get; set; }

        /// <summary>
        /// 量測時段
        /// </summary>
        public string Slot { get; set; }
    }
}