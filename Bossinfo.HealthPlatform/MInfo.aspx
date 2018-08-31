﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MInfo.aspx.cs" Inherits="Bossinfo.HealthPlatform.MInfo" %>

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
                    <div id="BMI" class="content"><%= htmlBMI %> </div>
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
                    <%=htmlBMIRemark %><br>
                    <%=htmlHPRemark %>
                </div>
            </div>
        </div>
        <script>
            $(document).ready(function () {
                if ('<%= htmlAlertStatus%>' == 'Y')
                    alert('查無資料');
            });
        </script>
        
    </form>
</body>
</html>
