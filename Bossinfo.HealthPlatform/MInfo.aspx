<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MInfo.aspx.cs" Inherits="Bossinfo.HealthPlatform.MInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Bootstrap</title>
    <link href="Content/css/default.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <div class="container">
                <div style="z-index: -100;">
                    <img src="./Content/images/bk_ok.png" style="width: 100%" />
                </div>
                <div class="box">
                    <div id="BMI" class="content"><%=htmlBMI %> </div>
                    <hr id="BMI_Hr" />
                    <div id="BMI_Dot" class="content">
                        <span class="dot"></span>
                    </div>
                    <div id="HeightValue" class=" valueDiv"><%=htmlHeight %></div>
                    <div id="WeightValue" class=" valueDiv"><%=htmlWeight %></div>
                    <div id="LowBP" class=" valueDiv"><%=htmlLowBP %></div>
                    <div id="LowBPUnit" class=" valueDiv">mmHG</div>
                    <div id="HighBP" class=" valueDiv"><%=htmlHighBP %></div>
                    <div id="HighBPUnit" class=" valueDiv">mmHG</div>
                    <div id="HeartBeat" class=" valueDiv"><%=htmlHeartBeat %></div>
                    <div id="BodyTemperture" class=" valueDiv"><%=htmlBodyTemperture %></div>
                </div>
                <div id="Remark">
                    <%=htmlBMIRemark %><br />
                    <%=htmlHPRemark %>
                </div>
            </div>
        </div>
        <script>
            $(document).ready(function () {
                //if ('<%= htmlAlertStatus%>' == 'Y')
                    if(false)
                    alert('查無資料');
                else {
                    var y = <%=htmlBMI %>;
                    var x = (38 + (y * 0.926));
                    var dot_location = x + '%';
                    var l = (y * 0.917);
                    var line_location = l + '%';

                    if (y <= 35) {
                        $('#BMI_Dot').css('left', dot_location);
                        $('#BMI_Hr').css('width', line_location);
                    }
                    else {
                        $('#BMI_Dot').addClass('hide');
                        $('#BMI_Hr').css('width', '43.2%');
                    }
                }
            });
        </script>

    </form>
</body>
</html>
