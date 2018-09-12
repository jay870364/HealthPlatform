using Bossinfo.HealthPlatform.UtilityTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bossinfo.HealthPlatform
{
    public partial class DESKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var DeUid = Request["DeUid"];
            var EnUid = Request["EnUid"];
            var message = "404，參數空值";
            if (string.IsNullOrEmpty(EnUid))
            {
            }
            else
            {
                var longUid = ToolLibs.EncryptDES(EnUid, Config.DESKey, Config.DESIV);
                message = $"加密後：{longUid.ToString()}";
            }

            if (string.IsNullOrEmpty(DeUid))
            {


            }
            else
            {
                var longUid = Convert.ToInt64(ToolLibs.DecryptDES(DeUid, Config.DESKey, Config.DESIV));
                message = $"解密後：{longUid.ToString()}";
            }

            Response.Write(message);
        }
    }
}