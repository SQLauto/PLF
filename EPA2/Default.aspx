<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PLF.Default" %>

<!DOCTYPE html>


<html>
<head id="Head1" runat="server">
    <title>Professional Learning Form</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/DeviceMedia.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/BubbleHelp.css" rel="stylesheet" />

    <link href="Content/TopLink.css" rel="stylesheet" />
    <link href="Content/TopNavList.css" rel="stylesheet" />
    <link href="Content/TopNavListM.css" rel="stylesheet" />
    <link href="Content/DefaultPage.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/NavTopList.js"></script>


    <style>
        html, body {
            height: 100%;
            width: 100%;
            margin: auto;
        }

        /*.iFrameDIV {
            height: 100%;
            width: 100%;
            float: left;
            table-layout: auto;
            margin-bottom:-15px; 
        }*/

        #GoList {
            font-size: small;
            font-family: Arial;
            table-layout: auto;
            height: 100%;
            width: 100%;
            border: 0px solid red;
            margin: auto;
            margin-bottom: -20px;
            margin-top: -5px;
        }

        .CenterDIV {
            width: 300px;
            margin: auto;
            background-color: azure;
            border: 2px blue outset;
            padding: 30px;
        }



        .appheader {
            /*height: 100px;*/
            width: 100%;
            border-top: 2px solid #56c0e9;
        }

        #appriFrame {
            margin-bottom: -2px;
            width: 100%;
        }

        .inVisibleBtn {
            display: none;
        }

        #TableVersion {
            margin-right: 0px;
            margin-top: 0px;
        }

        #rblLoginAS input {
            font-family: Arial;
            font-size: x-small;
            font-weight: 100;
        }

        #rblLoginAS label:hover {
            text-decoration: underline;
            color: purple;
        }

        #MobileMenu {
            margin-top: 0px;
            margin-bottom: 1px;
            height: 32px;
            width: 43px;
            color: yellow;
        }

        .epahide {
            display: none;
        }
    </style>

  

</head>
<body>
    <form id="form2" runat="server">
        <header>
            <div class="appheader">
                <div id="LogoCol" style="display: inline; width: 10%; float: left;" class="pull-left visible-sm visible-md visible-lg">

                    <img id="Image3" src="images/boardLogo.gif" alt="TCDSB Logo" border="0" style="width: 200px; height: 95px" />
                </div>
                <div id="messageCol" style="display: inline; text-align: right; width: 40%; float: left" class="visible-md visible-lg">

                    <asp:Button ID="btnLogout" CssClass="inVisibleBtn" runat="server" Text="" OnClick="btnLogout_Click" Visible="true" Height="0px" Width="0px" />
                    <asp:Label ID="LabelTrain" runat="server" Height="20px" Visible="False"
                        Font-Size="Large" ForeColor="#00C000"> Training</asp:Label>

                    <br />
                    <br />
                    <br />
                    <div style="vertical-align: baseline; font-size: small;">
                        <a href="javascript:openParameter();">School Year:</a>
                        <asp:Label ID="LabelSchoolYear" runat="server" BackColor="Transparent"
                            ForeColor="purple"> </asp:Label>
                        <a href="javascript:openParameter();">School:   </a>

                        <asp:Label ID="LabelSchoolCode" runat="server" BackColor="Transparent"
                            ForeColor="purple"> </asp:Label>
                        <asp:Label ID="LabelSchool" runat="server" BackColor="Transparent"
                            ForeColor="purple"> </asp:Label>
                    </div>

                </div>
                <div id="linkCol" style="display: inline; width: 600px; float: right;">
                    <table cellspacing="0" cellpadding="0" width="600px" align="right" style="display: inline-block;"
                        border="0" id="TableVersion" runat="server">
                        <tr style="height: 30px;">
                            <td style="text-align: right; vertical-align: top; width: 30px" class="visible-sm visible-md visible-lg">
                                <img height="30" src="images/curve.png" width="50" alt="" />
                            </td>

                            <td class="LinkCell" style="width: 600px">

                                <ul id="navlistLink" style="margin-right: 10px;">
                                    <li>
                                        <img style="margin-bottom: 5px" src="images/user.png" width="22" height="20" />
                                        <a href="#" id="LoginUserRole" runat="server">UserRole </a>
                                        <asp:HiddenField ID="hfCurrentUserRole" runat="server" />

                                    </li>
                                    <li><a href="http://owa.tcdsb.org" id="TopMenu3" runat="server" target="_blank">Web Mail </a></li>
                                    <li>
                                        <a href="https://www.tcdsb.org" id="A1" runat="server" target="_blank">TCDSB Web site</a>
                                    </li>
                                   <li>
                                        <a href="https://intranet.tcdsb.org" id="A2" runat="server" target="_blank">Intranet</a>
                                    </li>

                                    <li><a href="javascript:logoutApp()" id="Logout" runat="server">Log out </a>

                                    </li>

                                </ul>
                            </td>
                        </tr>
                        <tr>

                            <td style="height: 20px; margin-right: 20px; text-align: right; color: #cc0033; font-size: large;" colspan="3">

                                <asp:Label ID="lblApplication" runat="server" Text="TCDSB K to 12 Professional Learning Form"></asp:Label>
                                (<a id="appLink" runat="server" href="~/Default.aspx">PLF</a>) 
                                 
                            </td>
                        </tr>
                        <tr class=" visible-sm visible-md visible-lg">
                            <td>&nbsp;</td>
                        </tr>
                        <tr class=" visible-sm visible-md visible-lg">

                            <td style="text-align: right" colspan="3">
                                <asp:Label ID="lblTCDSB" runat="server" Text="TCDSB " ForeColor="#CC0033" ToolTip="Show Application Support"></asp:Label>
                                <asp:Label ID="lblVersion" runat="server" Text=" (Version 1.0.1 )" ToolTip="Edit Application Support"></asp:Label>

                            </td>
                        </tr>

                    </table>
                </div>
                <div id="LoginAsDIV" class="bubble epahide">
                    <asp:RadioButtonList ID="rblLoginAS" runat="server" AutoPostBack="true" Font-Bold="false" OnSelectedIndexChanged="rblLoginAS_SelectedIndexChanged"></asp:RadioButtonList>
                </div>
            </div>

            <div class="TopMenubar">
                <nav id="TopNav" class="pull-left visible-sm visible-md visible-lg">
                </nav>

                <div class="navbar-header pull-left visible-xs">

                    <button id="MobileMenu" type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#collapsable-nav" aria-expanded="false">
                        <%--<span class="sr-only">Toggle navigation</span>--%>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <div id="collapsable-nav" class="collapse navbar-collapse" style="margin-top: -10px; margin-left: 0px; padding: 0px;">
                        <nav id="TopNavM">
                        </nav>
                    </div>
                </div>

            </div>

        </header>

        <asp:HiddenField ID="hfPageID" runat="server" />
        <asp:HiddenField ID="hfUserLoginRole" runat="server" />
        <asp:HiddenField ID="hfRunningModel" runat="server" />
        <section style="text-align: center;">
            <div class="iFrameDIV">
                <iframe id="GoList" name="GoList" frameborder="0" scrolling="auto" src="Loading.aspx?pID=HomePage" runat="server"></iframe>
            </div>
            <div id="EditDIV" runat="server" class="EditDIV bubble epahide">
                <div class="editTitle">
                    <table>
                        <tr>
                            <td style="width: 98%">
                                <div id="EditTitle"></div>
                            </td>
                            <td>
                                <img id="closeMe" src="images/close.png" style="height: 30px; width: 30px; margin: -3px 0 -3px 0" /></td>
                        </tr>
                    </table>
                </div>
                <iframe class="EditPage" id="editiFrame" name="editiFrame" frameborder="0" scrolling="auto" src="iBlankPage.html" runat="server"></iframe>
            </div>
            <div style="width: 100%; height: 100%; align-content: center">
                <div id="ApprDIV" runat="server" class="ApprDIV bubble epahide" tabindex="998" style="height: 748px; width: 1024px; text-align: center">

                    <iframe class="ApprPage" id="appriFrame" name="appriFrame" frameborder="0" scrolling="auto" src="iBlankPage.html" runat="server" style="height: 100%"></iframe>
                </div>
            </div>

            <div id="PopUpDIV" class="bubble epahide"></div>
        </section>



    </form>
</body>
</html>

<script type="text/javascript">
    myTopNav(myTopMenu);
    var currentY = 0;
    var currentNodeLevel1;
    var currentNodeLevel2;
</script>
<script>
    $(document).ready(function () {

        var vHeight = window.innerHeight - 140;
        //var vWidth = screen.width;
        //var vHeight = window.innerHeight - apprScreenH1;
        $("#GoList").css("height", vHeight)

        //$("#GoList").css({
        //     height: vHeight
        //    //width: vWidth
        //})
        $("#LoginUserRole").click(function (event) {
            if ($("#hfUserLoginRole").val() === "Admin") {
                var vTop = $("#LoginUserRole")[0].offsetParent.offsetTop + 25;      // event.originalEvent.clientY +5;
                var vLeft = $("#LoginUserRole")[0].offsetParent.offsetLeft + 140;    //    event.originalEvent.clientX + 50;
                $("#LoginAsDIV").css({
                    top: vTop,
                    left: vLeft - 100,
                    height: 170,
                    width: 180
                })

                $("#LoginAsDIV").fadeToggle("fast");
                //   $("#LoginAsDIV").addClass("visible");
            }
        });

        $("#closeMe").click(function (event) {

            $("#PopUpDIV").fadeToggle("fast");

            if ($("#EditDIV").css('display') === "block")
            { $("#EditDIV").fadeToggle("fast"); }

            if ($("#ApprDIV").css('display') === "block")
            { $("#ApprDIV").fadeToggle("fast"); }


        });
        $("#MobileMenu").click(function (event) {
            //  window.alert($(".iFrameDIV").css("display"));


            //if ($(".iFrameDIV").css("display") === "block") {
            //    $(".iFrameDIV").hide();
            //}
            //else {
            //    $(".iFrameDIV").show();
            //}
            if ($("#GoList").attr("src") === "iBlankPage.html") {
                $("#TopNavM").hide();
                $("#GoList").attr("src", "DefaultSummary.aspx");
            }
            else {
                $("#TopNavM").show();
                $("#GoList").attr("src", "iBlankPage.html");
            }

            //   myTopNavM(myTopMenu);

        });

    });
    function changeAppsRole() {
        if ($("#hfUserLoginRole").val() === "Admin") {
            var vTop = $("#LoginUserRole")[0].offsetParent.offsetTop + 25;
            var vLeft = $("#LoginUserRole")[0].offsetParent.offsetLeft + 150;
            window.alert($("#hfUserLoginRole").val());
            window.alert($(vTop + "  " + vLeft).val());
            $("#LoginAsDIV").css({
                top: vTop,
                left: vLeft - 100,
                height: 170,
                width: 180
            })

            $("#LoginAsDIV").fadeToggle("fast");
        }

    }
    function logoutApp() {
        $("#btnLogout").click();
    }

</script>
