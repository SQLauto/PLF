<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading2.aspx.cs" Inherits="PLF.PLFForm.Loading2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style media ="screen">
        .loader {
            position:fixed;
            z-index:99;
            top:0;
            left:0;
            width:100%;
            height:100%;
            background-color:transparent;
            display:flex;
            justify-content:center;
            align-items:center;
        }
        .loader > img {
            width:100px;
        }
        .loader.hidden {
            animation:fadeout 1s;
            animation-fill-mode:forwards;
        }
        @keyframes fadeout {
            100% {
                opacity:0;
                visibility:hidden;
            }
        }
        .thumb {
            height:100px;
            border:1px solid black;
            margin:10px;
        }
    </style>

</head>
<body>
    <div class ="loader">
       <img src="../images/Loading.gif" alt="Loading..." /> Loading ......
    </div>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
     <script type="text/javascript">
         window.addEventListener("load", function () {
             const loader = document.querySelector(".loader");
             loader.className += " hidden";
         });

     </script>
</body>
</html>
