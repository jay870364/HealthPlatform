using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bossinfo.HealthPlatform.Models.TaiDoc;

namespace Bossinfo.HealthPlatform
{
    public partial class AddMeasureRecord2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var log = new UtilityTools.Log();
            var plainText = GetDocumentContents(new HttpRequestWrapper(this.Request));

            var obj = JsonConvert.DeserializeObject<TaiDocResultData>(plainText);
            log.Info($"TaiDocAPiPlainText\t{plainText}\n" +
                    $"TaiDocApiObj\t{obj}");

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
    }
}