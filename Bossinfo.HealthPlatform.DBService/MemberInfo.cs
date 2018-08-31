﻿using Bossinfo.HealthPlatform.UtilityTools;
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

            Log log = new Log();
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
                log.Error($"產生與資料庫相關的錯誤\n" +
                      $"Data：{ex.ToString()}");
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
            Log log = new Log();
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (db.MemberInfo.Any(x => x.IDNo == IDNo))
                    {
                        log.Info($"會員資料存在，回傳資料");
                        return db.MemberInfo.Where(x => x.IDNo == IDNo).FirstOrDefault().ID;
                    }
                    else
                    {
                        log.Info($"會員資料不存在，回傳空值");
                        return string.Empty;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                new Log().Error($"產生與資料庫相關的錯誤\n" +
                                $"Data：{ex.ToString()}");
                return string.Empty;
            }
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="IDNo">身分證字號</param>
        /// <returns></returns>
        public static Models.Entity.MemberInfo GetMemberInfoByIDNo(string IDNo)
        {
            Log log = new Log();
            try
            {
                using (var db = new HealthPaltformContext())
                {
                    if (string.IsNullOrEmpty(IDNo))
                    {
                        log.Info($"會員資料不存在");
                        return new Models.Entity.MemberInfo();
                    }
                    else
                    {
                        log.Info($"會員資料存在");
                        return db.MemberInfo.Where(x => x.IDNo == IDNo).FirstOrDefault();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                new Log().Error($"產生與資料庫相關的錯誤\n" +
                                $"Data：{ex.ToString()}");
                return new Models.Entity.MemberInfo();
            }
        }
    }
}
