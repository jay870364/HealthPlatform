using Bossinfo.HealthPlatform.UtilityTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bossinfo.HealthPlatform
{
    public partial class AD : System.Web.UI.Page
    {
        public string htmlRedirectUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            htmlRedirectUrl = Config.RedirectUrl;
        }
    }
}