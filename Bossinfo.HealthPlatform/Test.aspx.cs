using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bossinfo.HealthPlatform
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        public string RegexStringParsing(string MedicalRecordNumber)
        {

            Regex medicalRecordNumberRule = new Regex("[0-9]+");
            Match result = medicalRecordNumberRule.Match(MedicalRecordNumber);
            return result.ToString();

        }
    }
}