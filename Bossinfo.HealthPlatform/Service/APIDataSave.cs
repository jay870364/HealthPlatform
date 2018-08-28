//using Bossinfo.HealthPlatform.Models.Entity;
//using Bossinfo.HealthPlatform.Models.Utility;
//using Bossinfo.HealthPlatform.UtilityTools;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Bossinfo.HealthPlatform.Service
//{
//    public class APIDataSave
//    {
//        public string Save(MIData M)
//        {
//            var dbIDNo = DBService.MemberInfo.QueryMemberInfoByIDNo(MIData.Member_IDNo);

//            try
//            {
//                if (string.IsNullOrEmpty(dbIDNo))
//                {
//                    //儲存該筆資料
//                    var memberInfo = new MemberInfo();
//                    //取得系統ID
//                    var tmpID = ToolLibs.GetDateTimeNowDefaultString();

//                    #region MemberInfo

//                    memberInfo.ID = tmpID;
//                    memberInfo.IDNo = MIData.Member_IDNo;
//                    memberInfo.Name = "Test";
//                    memberInfo.Genger = 0;
//                    memberInfo.BDate = DateTime.Now;
//                    memberInfo.Tel = "";
//                    memberInfo.Mobile = "";
//                    memberInfo.Email = "";
//                    memberInfo.Fax = "";
//                    memberInfo.Occupation = "";
//                    memberInfo.CreateDate = DateTime.Now;

//                    #endregion

//                    DBService.MemberInfo.InsertMemberInfo(memberInfo);
//                }

//                //建立新的測量資料
//                var measuerInfo = new MeasureInfo();

//                //傳入身份證字號
//                measuerInfo.MemberIDNo = MIData.Member_IDNo;

//                //字串處理，將多餘的 \n \r 去除，並將數據帶入
//                measuerInfo.MIData = Regex.Replace(plainText, @"\n|\r", "");

//                //帶入現在時間
//                measuerInfo.MIDate = DateTime.Now;

//                //新增資料，並紀錄新增後的UID
//                var measureInfoID = DBService.MeasureInfo.InsertMeasureInfo(measuerInfo).ToString();

//                //將網址帶入的UID加密
//                var encryptID = ToolLibs.EncryptDES(measureInfoID, Config.DESKey, Config.DESIV);

//                //組出網址
//                var encryptCodeURL = $"{Config.BaseURL}MInfo.aspx?UID={encryptID}";

//                System.Diagnostics.Debug.WriteLine($"IMVS\t{encryptCodeURL}");
//            }
//    }
//    }