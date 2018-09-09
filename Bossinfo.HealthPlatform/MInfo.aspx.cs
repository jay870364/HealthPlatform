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
        public string htmlBMI = "50";
        public int htmlBMICHart = 0;
        public string htmlHeight = "";
        public string htmlWeight = "";
        public string htmlLowBP = "";
        public string htmlHighBP = "";
        public string htmlHeartBeat = "";
        public string htmlBodyTemperture = "";
        public string htmlHPRemark = "";
        public string htmlBMIRemark = "";
        public string htmlAlertStatus = "N";
        public Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request["UID"];
            System.Diagnostics.Debug.WriteLine($"IM\t{uid}");
            log.Info($"Minfo.aspx\tUid：{uid}");

            if (string.IsNullOrEmpty(uid))
            {

                log.Info($"Minfo.aspx\tUid是空值：{uid}");
                htmlAlertStatus = "Y";
            }
            else
            {
                try
                {
                    log.Info($"Minfo.aspx\tUid：{uid}");
                    PrepareData(uid);
                    htmlAlertStatus = "N";
                }
                catch (Exception ex)
                {
                    new Log().Error($"Minfo載入異常\n" +
                                    $"Data：{ex.ToString()}");
                    htmlAlertStatus = "Y";
                }
            }
        }
        public void PrepareData(string uid)
        {


            //將Request回來的UID解密
            var longUid = Convert.ToInt64(ToolLibs.DecryptDES(uid, Config.DESKey, Config.DESIV));

            log.Info($"取得檢測資料\tUid：{longUid}");

            //取得檢測資料
            var measureInfo = DBService.MeasureInfo.GetMeasureInfoByUID(longUid);

            log.Trace($"Data\t{measureInfo.MIData}");

            log.Info($"取得會員資料\t身分證：{measureInfo.MemberIDNo}");
            //取得會員資料
            var memberInfo = DBService.MemberInfo.GetMemberInfoByIDNo(measureInfo.MemberIDNo);

            //所記錄的測量資料
            var mIData = JsonConvert.DeserializeObject<Models.Utility.MIData>(measureInfo.MIData);

            //舒張壓
            var tmpBP_Systolic = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.LBP, ToolLibs.ConvertStrToDouble(mIData.BP_Systolic));

            log.Info($"舒張壓 Remark\t{tmpBP_Systolic.Message}\t{tmpBP_Systolic.Level}");

            //收縮壓
            var tmpHP_Diastolic = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.HBP, ToolLibs.ConvertStrToDouble(mIData.BP_Diastolic));


            log.Info($"收縮壓 Remark\t{tmpHP_Diastolic.Message}\t{tmpHP_Diastolic.Level}");

            //脈博
            var tmpHeatRate = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.HR, ToolLibs.ConvertStrToDouble(mIData.HeatRate));
            var HPRemark = $"{tmpHeatRate.Level}，{tmpHeatRate.Message}";
            log.Info($"脈博 Remark\t{tmpHeatRate.Message}\t{tmpHeatRate.Level}");

            //BMI
            var tmpBMI = DBService.ResultRemark.GetRemarkByType(Enums.ResultRemarkType.BMI, ToolLibs.ConvertStrToDouble(mIData.BMI));

            var BMIRemark = tmpBMI.Message == "正常" ? $"{tmpBMI.Message}" : $"{tmpBMI.Message}需多注意飲食管理";

            log.Info($"BMI Remark\t{tmpBMI.Message}\t{tmpBMI.Level}");

            htmlBMI = mIData.BMI;

            htmlHeight = mIData.Height;

            htmlWeight = mIData.Weight;

            htmlLowBP = mIData.BP_Systolic;

            htmlHighBP = mIData.BP_Diastolic;

            htmlHeartBeat = mIData.HeatRate;

            htmlBodyTemperture = mIData.BodyTemperture;

            htmlBMIRemark = BMIRemark;

            htmlHPRemark = HPRemark;

            log.Info($"網頁帶入的資料BMI：{htmlBMI}\t" +
                $"身高：{htmlHeight}\t" +
                $"體重：{htmlWeight}\t" +
                $"舒張壓：{htmlLowBP}\t" +
                $"收縮壓：{htmlHighBP}\t" +
                $"脈搏：{htmlHeartBeat}\t" +
                $"體溫：{htmlBodyTemperture}\t" +
                $"BMI註記：{htmlBMIRemark}\t" +
                $"血壓註記：{htmlHPRemark}");
        }

    }

}
