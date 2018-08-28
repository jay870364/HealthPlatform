using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Bossinfo.HealthPlatform.Enums;

namespace Bossinfo.HealthPlatform.DBService
{
    public class ResultRemark
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public static bool InitialResultRemark()
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (!db.ResultRemark.Any())
                    {
                        var tmp = UtilityTools.ToolLibs.GetResultRemarkData();
                        var obj = UtilityTools.ToolLibs.ConvertJSONToObj(tmp);

                        if (obj.Result.Count > 0)
                        {

                            foreach (var unit in obj.Result)
                            {
                                var tmpResult = new Models.Entity.ResultRemark();
                                tmpResult = new Models.Entity.ResultRemark();
                                tmpResult.Type = UtilityTools.ToolLibs.GetEnum<ResultRemarkType>(unit.Type);
                                tmpResult.LowRange = Convert.ToDouble(unit.LowRange);
                                tmpResult.HightRange = Convert.ToDouble(unit.HightRange);
                                tmpResult.Level = unit.Level;
                                tmpResult.Message = unit.Message;
                                tmpResult.CreateDate = DateTime.Now;
                                db.ResultRemark.Add(tmpResult);
                            }
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                return false;
                //log
            }
        }
    }
}
