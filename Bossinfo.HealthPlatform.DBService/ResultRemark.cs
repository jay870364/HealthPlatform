using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Bossinfo.HealthPlatform.Enums;
using Bossinfo.HealthPlatform.UtilityTools;

namespace Bossinfo.HealthPlatform.DBService
{
    public class ResultRemark
    {
        /// <summary>
        /// 建立評語的資料
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public static bool InitialResultRemark()
        {
            var result = false;
            try
            {
                using (var db = new HealthPaltformContext())
                {

                    if (!db.ResultRemark.Any())
                    {
                        var tmpData = ToolLibs.GetResultRemarkData();
                        var obj = ToolLibs.ResultRemarkConvert(tmpData);

                        if (obj.Result.Any())
                        {
                            foreach (var unit in obj.Result)
                            {
                                //建立新物件
                                var tmpResult = new Models.Entity.ResultRemark();

                                //型態
                                tmpResult.Type = ToolLibs.GetEnum<ResultRemarkType>(unit.Type);

                                //低標
                                tmpResult.LowRange = Convert.ToDouble(unit.LowRange);

                                //頂標
                                tmpResult.HightRange = Convert.ToDouble(unit.HightRange);

                                //等級
                                tmpResult.Level = unit.Level;

                                //評語
                                tmpResult.Message = unit.Message;

                                //建立日期
                                tmpResult.CreateDate = DateTime.Now;

                                //新增資料
                                db.ResultRemark.Add(tmpResult);
                            }
                            //儲存新增
                            if (db.SaveChanges() > 0)
                                result = true;
                        }
                    }
                }
                return result;
            }
            catch (DbEntityValidationException ex)
            {
                return result;
                //log
            }
        }

        public static Models.Entity.ResultRemark GetRemarkByType(ResultRemarkType type, double value)
        {
            var result = new Models.Entity.ResultRemark();
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (value > 0)
                    {
                        result = db.ResultRemark.Where(x => x.Type == type && value > x.LowRange && value < x.HightRange).FirstOrDefault();
                    }

                }
                return result;
            }
            catch (DbEntityValidationException ex)
            {
                //log
                return result;
            }
        }
    }
}
