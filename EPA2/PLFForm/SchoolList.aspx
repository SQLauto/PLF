<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolList.aspx.cs" Inherits="PLF.PLFForm.SchoolList" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Position Publsh List</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ListPage.css" rel="stylesheet" />
    <link href="../Scripts/JQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Scripts/JQueryUI/jquery-ui.theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/JQueryUI/jquery-ui.structure.min.css" rel="stylesheet" />

    <style type="text/css">
        body {
            height: 99.5%;
            width: 99.5%;
            font-size: x-small;
        }

        div {
            font-family: Arial;
            font-size: small;
        }


        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
            table-layout: auto;
            display: block;
            height: 99%;
        }



        .SubstituedCell {
            color: red;
            text-decoration: underline;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }


        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }

        .highlightBoard {
            border: 1px blue solid;
        }

        .defaultBoard {
            border: 1px blue none;
        }

        #ActionMenuDIV {
            border: 2px lightblue ridge;
            height: 140px;
            width: 210px;
            background: lightblue; /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(lightblue, white); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(lightblue, white); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(lightblue, white); /* For Firefox 3.6 to 15 */
            background: linear-gradient(lightblue, white); /* Standard syntax */
        }

            #ActionMenuDIV li {
                height: 25px;
            }

        .hfSchoolYear, .hfSchoolCode, .hfEmployeeID, .hfTeacherName, .hfmyKey {
            display: none;
            width: 0px;
        }

        img {
            border-color: yellow;
        }

        #EmailTemplateDIV {
            border: 2px solid #00c2ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/Models/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <table class="TableFont1B">
                <tr>
                    <td>School Year: 
                            <asp:DropDownList ID="ddlSchoolYear" runat="server" Height="30px" Width="100px" BackColor="Transparent"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlSchoolYear_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
                    <td>School Area:
                            <asp:DropDownList ID="ddlSuperarea" runat="server" Width="135px" Visible="False"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlSuperarea_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LabelSchool" runat="server" BackColor="Transparent"
                            Text="School:"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolCode" runat="server" Height="30px" Width="60px" Enabled="False"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSchools" runat="server" Height="30px" Width="400px" Enabled="False"
                            AutoPostBack="True">
                        </asp:DropDownList>

                    </td>

                </tr>
            </table>
        </div>

        <div>

            <div id="DivRoot" style="width: 100%; height: 550px;">
                <div style="overflow: hidden;" id="DivHeaderRow">
                    <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellpadding="1" gridlines="Both">
                    </table>
                </div>

                <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Appraisal Staff in current search condition" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                        <Columns>

                            <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="myAction">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("GoAction") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="5%" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="School Name" ItemStyle-CssClass="mySchoolname">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("SchoolName") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="20%" Wrap="False" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Principal" ItemStyle-CssClass="myPrincipal">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("Principal") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="School Sign Off" ItemStyle-CssClass="mySchoolSignOff">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("SchoolSignOffDate") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SO Sign Off" ItemStyle-CssClass="mySOSignOff">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("SOSignOffDate") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Publish Date" ItemStyle-CssClass="myPublish">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link6" runat="server" Text='<%# Bind("PublishDate") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="SchoolArea" HeaderText="School Area" ItemStyle-CssClass="mySchoolArea">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Comments" HeaderText="Comments">
                                <ItemStyle Width="25%" />
                            </asp:BoundField>
                            <%--                                    <asp:BoundField DataField="myKey" ReadOnly="True" ItemStyle-CssClass="hfmyKey" />--%>
                            <asp:BoundField DataField="SchoolCode" ReadOnly="True" ItemStyle-CssClass="hfmyKey" />

                        </Columns>

                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />

                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                </div>
            </div>


        </div>
        <div style="color: Red; font-size: x-small; height: 20%">
            <asp:Label runat="server" ID="remaind22" Text="* Click on the Apply button to see interview candidate list "> </asp:Label>
        </div>


        <div id="cellEditDateDiv" class="bubble epahide">
            <input id="cellEditDeadLineDate" runat="server" type="text" size="9" style="display: none;" />
        </div>

        <div>
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfSignOff" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfSelectedID" runat="server" />
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />

        </div>
    </form>
</body>
</html>

<script src="../Scripts/jquery-3.2.1.min.js"></script>
<script src="../Scripts/JQueryUI/jquery-ui.min.js" type="text/javascript"></script>
<script src="../Scripts/GridView.js"></script>
<script src="../Scripts/Appr_ListPage.js"></script>
<script type="text/javascript">
    var IE = document.all ? true : false
    document.onmousemove = getMousepoints;
    var mousex = 0;
    var mousey = 0;
    function getMousepoints() {
        mousex = event.clientX + document.body.scrollLeft;
        mousey = event.clientY + document.body.scrollTop;
        return true;
    }
</script>
<script type="text/javascript">
    var rowNo;
    var teachername;
    var schoolyear;
    var schoolcode;
    var signtype;
    var signOffDate;
    var myKey;
    var currentTR;
    var eventCell;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            MakeStaticHeader("GridView1", 600, 1000, 25, false);
            $("#GridView1 th").each(function () {
                var headText = $(this).text();
                if (headText.length == 1) {
                    $(this).addClass("HideColumn");
                }
            })
            $("#GridView2 th").each(function () {
                var headText = $(this).text();
                if (headText.length == 1) {
                    $(this).addClass("HideColumn");
                }
            })


        });

    }
    function openDateCellEdit(vKey, vTop, vLeft, vHeight, vWidth) {
        $("#cellEditDateDiv").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#cellEditDateDiv").show();// .fadeToggle("fast");
    }
    function onSuccess(result) {
        // alert(result);
    }
    function onFailure(result) {
    }


    function IECompatibility() {
        var agentStr = navigator.userAgent;
        this.IsIE = false;
        this.IsOn = undefined;  //defined only if IE
        this.Version = undefined;
        this.Compatible = undefined;

        if (agentStr.indexOf("compatible") > -1) {
            this.IsIE = true;
            this.IsOn = true;
            this.Compatible = true;
        }
        else {
            this.Compatible = false;
        }

    }

    function openForm(sYear, sCode) {
        var actionMessage = CheckUserActionMessage("OpenForm", "OK");
        if (actionMessage == "OK") {
            var goPage = "PLFForm/Loading.aspx?pID=FormContent&yID=" + sYear + "&sID=" + sCode
            var vHeight = window.screen.height - 150;
            var vWidth = 980;
            var pTitle = "Professional Learning Form";
            openEditPage4(vHeight, vWidth, goPage, pTitle);
        } else {
            window.alert(actionMessage);
        }

    }

    function openSignOff(sYear, sCode, sType, checkResult) {
        //  checkResult is School signOff result if sType is SO
        //  checkResult is from complete result if sType is School
        if (sType == "Publish") {
            openPublish(sYear, sCode, checkResult);
        }
        else {
            var actionMessage = CheckUserActionMessage(sType, checkResult);
            if (actionMessage == "OK") {
                var goPage = "PLFForm/Loading.aspx?pID=FormSignOff&yID=" + sYear + "&sID=" + sCode + "&sType=" + sType
                var vHeight = 300;
                var vWidth = 450;
                var pTitle = "Form Sign Off";
                openEditPage4(vHeight, vWidth, goPage, pTitle);
            } else {
                window.alert(actionMessage);
            }
        }
    }

    function openPublish(sYear, sCode, checkResult) {
        // checkResult is SOSignOff result
      //  var SOSignOff = sDate;
        if (checkResult != "Incomplete")
        {
            checkResult = "Complete";
        }
        var actionMessage = CheckUserActionMessage("Publish", checkResult);
        if (actionMessage == "OK") {
            var goPage = "PLFForm/Loading.aspx?pID=FormPublish&yID=" + sYear + "&sID=" + sCode + "&sType=Publish"
            var vHeight = 300;
            var vWidth = 450;
            var pTitle = "Form Publish";
            openEditPage4(vHeight, vWidth, goPage, pTitle);
        } else {
            window.alert(actionMessage);
        }
    }
    function openEditPage4(vHeight, vWidth, goPage, pTitle) {
        var vLeft = (screen.width / 2) - (vWidth / 2) - 50;
        var vTop = (screen.height / 2) - (vHeight / 2) - 50;
        // goPage = goPage + "&yID=" + schoolyear + "&cID=" + schoolcode;
        try {
            if (pTitle == "Professional Learning Form") {
                vTop = 1;
            }
            $("#ActionMenuDIV").hide();
            $("#editiFrame", parent.document).attr('src', goPage);
            $("#EditTitle", parent.document).html(pTitle);

            $("#EditDIV", parent.document).css({
                top: vTop,
                left: vLeft,
                height: vHeight,
                width: vWidth
            })
            $("#editiFrame", parent.document).css({
                height: vHeight,
                width: vWidth,
                border: 0
            })
            $("#PopUpDIV", parent.document).fadeToggle("fast");
            $("#EditDIV", parent.document).fadeToggle("fast");

        }

        catch (e) {
            window.alert("a Exception");
        }

    }
    function CheckUserActionMessage(action, checkResult) {
        //checkResult: form complete for school sign off
        //             school sign off for SO sign off
        //             SO sign off for publish  
        var userRole = $("#hfUserRole").val();
        var returnMessage = "";
        if (action == "OpenForm") {
            if (userRole == "Principal" || userRole == "SiteTeam" || userRole == "Superintendent" || userRole == "Admin")
                returnMessage = "OK";
            else
            { returnMessage = "No Permission to open the Form!"; }
        }
        if (action == "SchoolSignOff" || action == "School" ) {
            if (userRole == "Principal" || userRole == "Admin") {
                if (checkResult == "Complete" || checkResult == "SignedOff")
                { returnMessage = "OK"; }
                else
                    returnMessage = "Please complete the Form first.";
            }
            else { returnMessage = "No permission to sign off the Form!"; }
        }
        if (action == "SOSignOff" || action == "SO") {
            if (userRole == "Superintendent" || userRole == "Admin") {
                if (checkResult == "Complete" || checkResult == "SignedOff")
                { returnMessage = "OK"; }
                else
                { returnMessage = "School Principal sign off first!"; }
            }
            else { returnMessage = "This is SO sign off task. No permission to sign off the Form!"; }
        }
        if (action == "Publish") {
            if (userRole == "Principal" || userRole == "Admin") {
                if (checkResult == "Complete" || checkResult == "Published")
                    returnMessage = "OK";
                else
                    returnMessage = "School superintendent sign off first!";
            }
            else { returnMessage = "No permission to Publish the Form!"; }
        }
        return returnMessage;
    }

</script>
