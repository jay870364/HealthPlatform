using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bossinfo.HealthPlatform.Device
{
    public partial class TimeSync : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.StatusCode = 200;
                Response.Write("2000\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                Response.End();
            }
        }
    }
}