<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EventCalendar.Test" %>

<%@ Register Src="~/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/eventCalendar.css" rel="stylesheet" />
    <link href="css/eventCalendar_theme_responsive.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Calendar runat="server" Id="Calendar" />
    </form>
</body>
</html>