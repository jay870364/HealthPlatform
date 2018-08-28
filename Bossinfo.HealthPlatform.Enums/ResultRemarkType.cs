using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.Enums
{
    /// <summary>
    /// 測量的項目型態
    /// </summary>
    public enum ResultRemarkType
    {
        /// <summary>
        /// 收縮壓
        /// </summary>
        LBP = 0,

        /// <summary>
        /// 舒張壓
        /// </summary>
        HBP,

        /// <summary>
        /// 心跳
        /// </summary>
        HR,

        /// <summary>
        /// 身高體重指數
        /// </summary>
        BMI
    }
}
