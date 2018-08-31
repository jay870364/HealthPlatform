using Bossinfo.HealthPlatform.UtilityTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bossinfo.HealthPlatform
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log log = new Log();
            if (DBService.ResultRemark.InitialResultRemark())
            {
                log.Info("DB初始化成功");
                Response.Write("建立成功");
            }
            else
            {
                log.Info("連線正常");
                Response.Write("Status：200");
            }
        }
    }
}