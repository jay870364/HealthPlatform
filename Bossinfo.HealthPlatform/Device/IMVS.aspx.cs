using Bossinfo.HealthPlatform.Models;
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

namespace Bossinfo.HealthPlatform
{
    public partial class IMVS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var str = GetDocumentContents(new HttpRequestWrapper(this.Request));
            var dataResult = JsonConvert.DeserializeObject<Minfo>(str);

            var x = "";//去取回ID比較
                       //if (dataResult.Member_IDNo == "A000002")
            if (true)
            {
                //儲存該筆資料

            }
            else
            {
                //DBservice 新增一筆ID
                //加入新的檢測資料
            }

            Response.Write("");
        }


        /// <summary>
        /// 從阿諾那取得JSON，回傳網址
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

    }
}