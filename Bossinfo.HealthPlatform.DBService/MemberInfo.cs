using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.DBService
{
    public class MemberInfo
    {

        /// <summary>
        /// 新增會員資料
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static int InsertMemberInfo(Models.Entity.MemberInfo memberInfo)
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    db.MemberInfo.Add(memberInfo);

                    //log
                    return db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                //log
                return -999;
            }
        }

        /// <summary>
        /// 查詢是否已建立資料，回傳ID，若不存在新增一筆
        /// </summary>
        /// <param name="IDNo">身分證字號</param>
        /// <returns></returns>
        public static string QueryMemberInfoByIDNo(string IDNo)
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (db.MemberInfo.Any(x => x.IDNo == IDNo))
                    {
                        return db.MemberInfo.Where(x => x.IDNo == IDNo).FirstOrDefault().ID;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                //log
                return string.Empty;
            }
        }

        public static Models.Entity.MemberInfo GetMemberInfoByIDNo(string IDNo)
        {
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (string.IsNullOrEmpty(IDNo))
                    {
                        return new Models.Entity.MemberInfo();
                    }
                    else
                    {
                        return db.MemberInfo.Where(x => x.IDNo == IDNo).FirstOrDefault();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                //log
                return new Models.Entity.MemberInfo();
            }
        }
    }
}
