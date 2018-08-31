using Bossinfo.HealthPlatform.Models.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bossinfo.HealthPlatform.Models.Entity;
using Bossinfo.HealthPlatform.UtilityTools;
using ThoughtWorks.QRCode.Codec;
using System.Text.RegularExpressions;

namespace Bossinfo.HealthPlatform.Device
{
    public partial class IMVS : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {

            var plainText = GetDocumentContents(new HttpRequestWrapper(this.Request));

            if (string.IsNullOrWhiteSpace(plainText))
            {
                log.Info($"收到的資料為空\n" +
                $"Data：{JsonConvert.SerializeObject(plainText)}\n");

                Response.Write(JsonConvert.SerializeObject(new { ResultCode = 404, ErrorMessage = $"轉換失敗，傳入的資料為空 Data：{plainText}" }));
                return;
            }

            log.Info($"開始解析資料，Data：{plainText}");
            var MIData = JsonConvert.DeserializeObject<MIData>(plainText);

            log.Info($"檢查是否存在會員資料：{MIData.Member_IDNo}");
            var dbIDNo = DBService.MemberInfo.QueryMemberInfoByIDNo(MIData.Member_IDNo);
            log.Trace($"回傳的會員資料UID", dbIDNo);

            try
            {
                if (string.IsNullOrEmpty(dbIDNo))
                {
                    log.Info($"新建會員資料");
                    //儲存該筆資料
                    var memberInfo = new MemberInfo();
                    //取得系統ID
                    var tmpID = ToolLibs.GetDateTimeNowDefaultString();
                    log.Info($"新建的會員資料ID：{tmpID}");
                    #region MemberInfo

                    memberInfo.ID = tmpID;
                    memberInfo.IDNo = MIData.Member_IDNo;
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
                    log.Trace("新增會員資料", memberInfo);
                    DBService.MemberInfo.InsertMemberInfo(memberInfo);
                }

                //建立新的測量資料
                var measuerInfo = new MeasureInfo();

                //傳入身份證字號
                measuerInfo.MemberIDNo = MIData.Member_IDNo;

                //字串處理，將多餘的 \n \r 去除，並將數據帶入
                measuerInfo.MIData = Regex.Replace(plainText, @"\n|\r", "");

                //帶入現在時間
                measuerInfo.MIDate = DateTime.Now;

                //新增資料，並紀錄新增後的UID
                var measureInfoID = DBService.MeasureInfo.InsertMeasureInfo(measuerInfo).ToString();

                //將網址帶入的UID加密
                var encryptID = ToolLibs.EncryptDES(measureInfoID, Config.DESKey, Config.DESIV);

                //組出網址
                var encryptCodeURL = $"{Config.BaseURL}MInfo.aspx?UID={encryptID}";

                log.Info($"回傳的網址",encryptCodeURL);

                var result = string.Empty;
                if (encryptCodeURL == "")
                {
                    result = JsonConvert.SerializeObject(new { ResultCode = 404, ErrorMessage = "轉換失敗" });
                    Response.Write(result);

                }
                else
                {
                    Response.Write(JsonConvert.SerializeObject(new { ResultCode = 200, Url = encryptCodeURL }));
                }
                log.Info($"回傳的結果，Data：{result}");
            }
            catch (Exception ex)
            {
                log.Error($"資料轉換錯誤\n" +
                                $"Data：{JsonConvert.SerializeObject(MIData)}\n" +
                                $"Exception：{ex.ToString()}");

                Response.Write(JsonConvert.SerializeObject(new { ResultCode = 404, ErrorMessage = $"{ex.ToString()}" }));
            }

        }


        /// <summary>
        /// 取得POST body context內的 JSON
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string GetDocumentContents(HttpRequestBase Request)
        {
            string documentContents;
            using (Stream receiveStream = Request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            return documentContents;
        }

        //private MemoryStream QRCodeGen(string url)
        //{
        //    if (!string.IsNullOrEmpty(url))
        //    {
        //        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        //        qrCodeEncoder.QRCodeScale = 4;
        //        qrCodeEncoder.QRCodeVersion = 8;
        //        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        //        System.Drawing.Bitmap image = qrCodeEncoder.Encode(url);
        //        System.IO.MemoryStream MStream = new System.IO.MemoryStream();
        //        image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);
        //        //context.Response.ClearContent();
        //        //context.Response.ContentType = "image/Png";
        //        return MStream;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}