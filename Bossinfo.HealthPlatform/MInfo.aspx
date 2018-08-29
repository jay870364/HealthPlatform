﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MInfo.aspx.cs" Inherits="Bossinfo.HealthPlatform.MInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Bootstrap</title>
    <link href="Content/css/t3.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <div class="container">
                <div style="z-index:-100;"><img src="./Content/images/bk_ok.png" style="width:100%" /></div>
                <div class="box">
                    <div id="BMI" class="content">233</div>
                    <div id="HeightValue" class=" valueDiv">180.9</div>
                    <div id="WeightValue" class=" valueDiv">78.0</div>
                    <div id="LowBP" class=" valueDiv">110</div>
                    <div id="LowBPUnit" class=" valueDiv">mmHG</div>
                    <div id="HighBP" class=" valueDiv">070</div>
                    <div id="HighBPUnit" class=" valueDiv">mmHG</div>
                    <div id="HeartBeat" class=" valueDiv">700</div>
                    <div id="BodyTemperture" class=" valueDiv">36.5</div>
                </div>
                <div id="Remark"></div>
            </div>
        </div>
        <script src="Scripts/jquery-1.10.2.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>
