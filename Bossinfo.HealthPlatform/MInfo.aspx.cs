using Bossinfo.HealthPlatform.UtilityTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Bossinfo.HealthPlatform
{
    public partial class MInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request["UID"];
            System.Diagnostics.Debug.WriteLine($"IM\t{uid}");

            var longUid = Convert.ToInt64(ToolLibs.DecryptDES(uid, Config.DESKey, Config.DESIV));
            var measureInfo = DBService.MeasureInfo.GetMeasureInfoByUID(longUid);
            System.Diagnostics.Debug.WriteLine($"Data\t{measureInfo.MIData}");
            var basicInfo = DBService.MemberInfo.
            var mIData = JsonConvert.DeserializeObject<Models.Utility.MIData>(measureInfo.MIData);

            
            Response.Write(measureInfo.MIData);
        }
    }
}