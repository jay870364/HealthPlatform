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
        public string htmlBMI = "";
        public string htmlHeight = "";
        public string htmlWeight = "";
        public string htmlLowBP = "";
        public string htmlHighBP = "";
        public string htmlHeartBeat = "";
        public string htmlBodyTemperture = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request["UID"];
            System.Diagnostics.Debug.WriteLine($"IM\t{uid}");

            PrepareData(uid);
        }
        public void PrepareData(string uid)
        {


            //將Request回來的UID解密
            var longUid = Convert.ToInt64(ToolLibs.DecryptDES(uid, Config.DESKey, Config.DESIV));

            //取得檢測資料
            var measureInfo = DBService.MeasureInfo.GetMeasureInfoByUID(longUid);

            System.Diagnostics.Debug.WriteLine($"Data\t{measureInfo.MIData}");

            //取得會員資料
            var memberInfo = DBService.MemberInfo.GetMemberInfoByIDNo(measureInfo.MemberIDNo);

            //所記錄的測量資料
            var mIData = JsonConvert.DeserializeObject<Models.Utility.MIData>(measureInfo.MIData);

            //舒張壓
            var tmpBP_Systolic = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.LBP, ToolLibs.ConvertStrToDouble(mIData.BP_Systolic));

            System.Diagnostics.Debug.WriteLine($"{tmpBP_Systolic.Message}\t{tmpBP_Systolic.Level}");

            //收縮壓
            var tmpHP_Diastolic = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.HBP, ToolLibs.ConvertStrToDouble(mIData.BP_Diastolic));

            System.Diagnostics.Debug.WriteLine($"{tmpHP_Diastolic.Message}\t{tmpHP_Diastolic.Level}");

            //脈博
            var tmpHeatRate = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.HR, ToolLibs.ConvertStrToDouble(mIData.HeatRate));

            System.Diagnostics.Debug.WriteLine($"{tmpHeatRate.Message}\t{tmpHeatRate.Level}");

            //BMI
            var tmpBMI = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.BMI, ToolLibs.ConvertStrToDouble(mIData.BMI));

            System.Diagnostics.Debug.WriteLine($"{tmpBMI.Message}\t{tmpBMI.Level}");

            htmlBMI = mIData.BMI;

            htmlHeight = mIData.Height;

            htmlWeight = mIData.Weight;

            htmlLowBP = mIData.BP_Systolic;

            htmlHighBP = mIData.BP_Diastolic;

            htmlHeartBeat = mIData.HeatRate;

            htmlBodyTemperture = mIData.BodyTemperture;

            
        }

        //Response.Write(measureInfo.MIData);
    }

}
