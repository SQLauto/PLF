<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolTeam.aspx.cs" Inherits="PLF.PLFForm.SchoolTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
            height:600px;
            width:900px;
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

        .hfSchoolYear, .hfSchoolCode, .hfEmployeeID, .hfTeacherName, .hfmyKey , .myTeacherID {
            display: none;
            width: 0px;
        }

        img {
            border-color: yellow;
        }

        #EmailTemplateDIV {
            border: 2px solid #00c2ff;
        }
         .myComment {
            background-color: transparent;
            border: 0;
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
            <table>
                <tr>
                    <td>

                        <asp:Label ID="Label3" runat="server" Text="School Year: "></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="90px" AutoPostBack="True" OnSelectedIndexChanged="ddlSchoolYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td><td>
                        <asp:Label ID="Label2" runat="server" Text="School"></asp:Label>
                            </td><td>
                        <asp:DropDownList ID="ddlSchoolCode" runat="server" Width="60px"  Enabled="false" >
                        </asp:DropDownList></td><td>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="300px"  Enabled="false">
                        </asp:DropDownList></td><td>

                        <asp:Button ID="btnSearch" runat="server" Text="Go" OnClick="btnSearch_Click" Visible="false" />
                    </td>
                  
                </tr>
            </table>
        </div>

        <div>

            <div id="DivRoot" style="width: 100%; height: 500px;">
                <div style="overflow: hidden;" id="DivHeaderRow">
                    <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellpadding="1" gridlines="Both">
                    </table>
                </div>

                <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Appraisal Staff in current search condition" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Selected">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" Checked='<%# Bind("SelectedC") %>' runat="server" CssClass="myCheck"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" HorizontalAlign="Center" />
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Obeservation Notes">
                                    <ItemStyle Width="65%" Wrap="True" />
                                    <ItemTemplate>
                                         <asp:TextBox ID="editText" runat="server" Text='<%# Eval("Comments") %>' CssClass="myComment" Width="100%" TextMode="MultiLine" >  </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                           
                            <asp:BoundField DataField="TeacherID" ReadOnly="True" ItemStyle-CssClass="myTeacherID" />

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
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
            <asp:HiddenField ID="hfSelectedID" runat="server" />
            <asp:HiddenField ID="hfSchoolYear" runat="server" />
            <asp:HiddenField ID="hfSchoolCode" runat="server" />
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

 
    var currentTR;
    var myParameter = {
        "UserID":"",
        "SchoolYear": "",
        "SchoolCode": "",
        "TeacherID": "",
        "Checked": "",
        "Comment": "",
        "ActionType":""
    }
   

        $(document).ready(function () {
            MakeStaticHeader("GridView1", 600, 900, 25, false);
            //$('#GridView1 tr').mouseenter(function (event) {
            //    if (currentTR != undefined) { currentTR.removeClass("highlightBoard"); }
            //    currentTR = $(this)
            //    currentTR.addClass("highlightBoard");
            //});
            var userRole = $("#hfUserRole").val();


            var x = 0;
            $('td > .myCheck').click(function (event) {
                var eventCell = $(this);
                var checkValue = (eventCell[0].childNodes['0'].checked ? "X" : "");
                if (userRole == "Principal" || userRole == "Admin")
                {
                    myParameter.TeacherID =$(this).closest('tr').find('td.myTeacherID').text();                   
                    myParameter.SchoolYear = $("#hfSchoolYear").val();
                    myParameter.SchoolCode = $("#hfSchoolCode").val();
                    myParameter.UserID = $("#hfUserID").val();
                    myParameter.Checked = checkValue;
                    myParameter.ActionType = "Check";
                    myParameter.Comment =""
                    ChangeSelectSign();
                }
            });
            $('td > .myComment').change(function (event) {
                var eventCell = $(this);

                if (userRole == "Principal" || userRole == "Admin")
                {
                    var teacherID = $(this).closest('tr').find('td.myTeacherID').text();
                    var comments = eventCell[0].value;
                    myParameter.TeacherID = $(this).closest('tr').find('td.myTeacherID').text();
                    myParameter.SchoolYear = $("#hfSchoolYear").val();
                    myParameter.SchoolCode = $("#hfSchoolCode").val();
                    myParameter.UserID = $("#hfUserID").val();
                    myParameter.Checked = "";
                    myParameter.ActionType = "Comments";
                    myParameter.Comment = comments
                    ChangeSelectSign();
                }
            });
        });
  
    
    var signCell;

    function ChangeSelectSign() {

        var newSelect = PLF.Models.WebService.SaveTeam(myParameter.UserID, myParameter.SchoolYear, myParameter.SchoolCode, myParameter.TeacherID, myParameter.Checked, myParameter.Comment, myParameter.ActionType, onSuccess, onFailure);

    }

    function onSuccess(result) {
        //  changeSign(result)
        $("#labelSelected").text(result);

    }
    function onFailure(result) {
        $("#labelSelected").text(result);
        window.alert(result);
    }


</script>
