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
        protected void Page_Load(object sender, EventArgs e)
        {
            //var dbContext = new DBService.HealthPaltformContext();

            var plainText = GetDocumentContents(new HttpRequestWrapper(this.Request));
            var MIData = JsonConvert.DeserializeObject<MIData>(plainText);

            var dbIDNo = DBService.MemberInfo.QueryMemberInfoByIDNo(MIData.Member_IDNo);

            try
            {
                if (string.IsNullOrEmpty(dbIDNo))
                {
                    //儲存該筆資料
                    var memberInfo = new MemberInfo();
                    //取得系統ID
                    var tmpID = ToolLibs.GetDateTimeNowDefaultString();

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

                System.Diagnostics.Debug.WriteLine($"IMVS\t{encryptCodeURL}");

                if (encryptCodeURL == "")
                {
                    Response.Write(JsonConvert.SerializeObject(new { ResultCode = 404, ErrorMessage = "轉換失敗" }));
                }
                else
                {
                    Response.Write(JsonConvert.SerializeObject(new { ResultCode = 200, Url = encryptCodeURL }));
                }
            }
            catch (Exception ex)
            {
                Response.Write(JsonConvert.SerializeObject(new { ResultCode = 404, ErrorMessage = $"{ex.ToString()}" }));
            }




            ////轉換成QRCode
            //var qrCodeStream = QRCodeGen(qrCodeURL);
            //Response.ClearContent();
            //Response.ContentType = "image/Png";
            //Response.BinaryWrite(qrCodeStream.ToArray());
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