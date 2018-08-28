﻿using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Bossinfo.HealthPlatform.Models;
using global::Bossinfo.HealthPlatform.Models.TaiDoc;
using System.Reflection;
using Bossinfo.HealthPlatform.UtilityTools;
using System.Text.RegularExpressions;

namespace Bossinfo.HealthPlatform.Device
{
    public partial class TaiDoc : System.Web.UI.Page
    {
        //private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string documentContents;
                using (Stream receiveStream = Request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Request.ContentEncoding))
                    {

                        documentContents = readStream.ReadToEnd();
                        //LOG.Debug("IP:" + Request.UserHostAddress);
                        //LOG.Debug(documentContents + Environment.NewLine);
                    }
                }
                string[] str = documentContents.Replace("\r\n", "\n").Split('\n');

                Dictionary<string, string> dic = str.Where(x => !x.StartsWith("Feedback")).ToDictionary(x => x.Split('=')[0].Trim(), x => x.Substring(x.IndexOf('=') + 1).Trim());
                if (dic.ContainsKey(string.Empty))
                    dic.Remove(string.Empty);
                ChangeValue(ref dic);

                TaiDocModel result = DictionaryToObject<TaiDocModel>(dic);
                List<Feedback> fbl = new List<Feedback>();
                List<string> dif = str.Where(x => x.StartsWith("Feedback")).ToList();
                foreach (string d in dif) //解析feedbak內容
                {
                    string t = d.Replace("Feedback", "");
                    t = d.Substring(d.IndexOf('=') + 1).Trim();
                    Dictionary<string, string> fb = t.Replace("@#@", "\n").Split('\n').ToDictionary(x => x.Split('=')[0].Trim(), x => x.Substring(x.IndexOf('=') + 1).Trim());
                    fbl.Add(DictionaryToObject<Feedback>(fb));
                }
                if (fbl.Count > 0)
                    result.Feedback = fbl.ToList();
                var settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };
                string json = JsonConvert.SerializeObject(result, settings);
                //LOG.Info(json);

                #region APIDataSave


                var dbIDNo = DBService.MemberInfo.QueryMemberInfoByIDNo(result.Member_IDNo);

                if (string.IsNullOrEmpty(dbIDNo))
                {
                    //儲存該筆資料
                    var memberInfo = new Models.Entity.MemberInfo();
                    //取得系統ID
                    var tmpID = ToolLibs.GetDateTimeNowDefaultString();

                    #region MemberInfo

                    memberInfo.ID = tmpID;
                    memberInfo.IDNo = result.Member_IDNo;
                    memberInfo.Name = "Test";
                    memberInfo.Genger = 0;
                    memberInfo.BDate = DateTime.Now;
                    memberInfo.Tel = "";
                    memberInfo.Mobile = "";
                    memberInfo.Email = "";
                    memberInfo.Fax = "";
                    memberInfo.Occupation = "";
                    memberInfo.CreateDate = DateTime.Now;

                    #endregion

                    DBService.MemberInfo.InsertMemberInfo(memberInfo);
                }

                //建立新的測量資料
                var measuerInfo = new Models.Entity.MeasureInfo();

                //傳入身份證字號
                measuerInfo.MemberIDNo = result.Member_IDNo;

                //字串處理，將多餘的 \n \r 去除，並將數據帶入
                measuerInfo.MIData = Regex.Replace(json, @"\n|\r", "");

                //帶入現在時間
                measuerInfo.MIDate = DateTime.Now;

                //新增資料，並紀錄新增後的UID
                var measureInfoID = DBService.MeasureInfo.InsertMeasureInfo(measuerInfo).ToString();

                //將網址帶入的UID加密
                var encryptID = ToolLibs.EncryptDES(measureInfoID, Config.DESKey, Config.DESIV);

                //組出網址
                var encryptCodeURL = $"{Config.BaseURL}MInfo.aspx?UID={encryptID}";

                System.Diagnostics.Debug.WriteLine($"IMVS\t{encryptCodeURL}");

                #endregion


                Response.Clear();
                Response.ContentType = "text/plain";
                Response.StatusCode = 200;
                Response.Write("200");
                Response.End();
            }
        }

        private static T DictionaryToObject<T>(IDictionary<string, string> dict) where T : new()
        {
            var t = new T();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }

        private void ChangeValue(ref Dictionary<string, string> dic)
        {
            if (dic.Count == 0) return;
            ///替換掉身分證的TAG
            if (dic.ContainsKey("PatientID"))
            {
                string val = dic["PatientID"];
                dic.Remove("PatientID");
                dic.Add("Member_IDNo", val);
            }
            if (dic.ContainsKey("Year") && dic.ContainsKey("Month") && dic.ContainsKey("Day") && dic.ContainsKey("Hour") && dic.ContainsKey("Minute") && dic.ContainsKey("Second") && dic.ContainsKey("Year"))
            {
                string DateTime = string.Format("{0}/{1}/{2} {3}:{4}:{5}", dic["Year"], dic["Month"], dic["Day"], dic["Hour"], dic["Minute"], dic["Second"]);
                dic.Add("DateTime", DateTime);
            }
            if (dic.ContainsKey("DataType"))
            {
                List<string> cn = TaiDocDataType.DataType[dic["DataType"]].Split(',').ToList();
                ChangeName(ref dic, cn);
            }
        }

        /// <summary>
        /// 變更dictionary key值,用來直接轉換json用
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="vals"></param>
        private void ChangeName(ref Dictionary<string, string> dic, List<string> vals)
        {
            int i = 1;
            foreach (string val in vals)
            {
                if (!string.IsNullOrEmpty(val)) //非空值
                {
                    dic.RenameKey(string.Format("Value{0}", i), val);
                }
                i++;
            }
        }

        private void ChangeSlotData(ref Dictionary<string, string> dic)
        {
            if (dic.ContainsKey("DataType") && dic.ContainsKey("Slot"))
            {
                Dictionary<string, string> slottype = TaiDocDataType.GetSlotType(dic["DataType"]);
                if (slottype.ContainsKey(dic["Slot"]))
                    dic["Slot"] = slottype[dic["Slot"]];
            }
        }
    }
}