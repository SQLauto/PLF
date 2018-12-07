﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading.aspx.cs" Inherits="PLF.Documents.Loading" %>


<!DOCTYPE  ">
<html>

<head runat="server">
    <title>Loading Page</title>
    <style>
        div {
            height: 100%;
            width: 100%;
            text-align: center;
            margin: 0 auto;
            padding-top: 15%;
        }
    </style>
</head>
<body>
    <div>
        <img src="../images/ajax-Loading.gif" />
        <a id="PageURL" runat="server" href='#' target="_self">Loading ...... Appraisal</a>

    </div>

    <script type="text/javascript">
        var myHref = document.getElementById("PageURL").getAttribute("href");
        window.location.href = myHref;
    </script>

</body>
</html>
