<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AD.aspx.cs" Inherits="Bossinfo.HealthPlatform.AD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/css/AD.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <div class="container myMOUSE">
                <div style="z-index: -100">
                    <img src="Content/images/AD_ok.png" style="width: 100%" />
                </div>
                <div id="top" class="img">
                    <img id="top_img" src="Content/images/top.png" />
                </div>
                <div id="bot" class="img">
                    <img id="bot_img" src="Content/images/bot.png" />
                </div>
            </div>
        </div>
        <script>
            $(document).ready(function () {
                $('#bot_img').mouseover(function () {
                    $('.myMOUSE').css('cursor', 'pointer');
                });

                $('#bot_img').mouseout(function () {
                    $('.myMOUSE').css('cursor', 'default');
                });

                $('#bot_img').click(function () {
                    window.location.assign('<%=htmlRedirectUrl %>');
                });
            });

        </script>
    </form>
</body>
</html>
