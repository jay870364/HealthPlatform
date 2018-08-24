<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MInfo.aspx.cs" Inherits="Bossinfo.HealthPlatform.MInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Test Bootstrap</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/css/default.css" rel="stylesheet"/>
    <style type="text/css"> div { border: 1px solid; } </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div id="header" class="row-fluid">
                <div class="col-md-12">
                    Header
                </div>
            </div>
            <div id="content"class="row-fluid">
                <div class="col-md-2">
                    Navigator
                </div>
                <div class="col-md-10">
                    Content
                </div>
            </div>
            <div  id="footer"class="row-fluid">
                <div class="col-md-12">
                    Footer
                </div>
            </div>
        </div>
        <script src="Scripts/jquery-1.10.2.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>