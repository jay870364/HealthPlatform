using System;
using System.Collections.Generic;
using Bossinfo.HealthPlatform.Models;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.DBService
{
    public class MeasureInfo
    {

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public static long InsertMeasureInfo(Models.Entity.MeasureInfo measure)
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    db.MeasureInfo.Add(measure);
                    db.SaveChanges();
                    return measure.UID;
                }
            }
            catch (DbEntityValidationException ex)
            {
                return -999;
                //log
            }
        }

        public static Models.Entity.MeasureInfo GetMeasureInfoByUID(long uid)
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (uid > 0)
                    {
                        return db.MeasureInfo.Where(x => x.UID == uid).FirstOrDefault();
                    }
                    else
                    {
                        return new Models.Entity.MeasureInfo();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                //log
                return new Models.Entity.MeasureInfo();
            }
        }
    }
}
