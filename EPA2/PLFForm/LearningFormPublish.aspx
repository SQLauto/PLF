<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LearningFormPublish.aspx.cs" Inherits="PLF.PLFForm.LearningFormPublish" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Scripts/JqueryUI/jquery-ui.min.css" rel="stylesheet" />

    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/JqueryUI/jquery-ui.min.js"></script>
    <style>
        header {
            display: none;
        }

        #TextBoxDate {
            display: none;
        }

        .labelTitle {
            color: forestgreen;
            font-family: Arial, sans-serif;
            font-weight: 500;
            font-size: 1.1em;
        }

        .labelMessage {
            font-style: italic;
            font-family: Arial, sans-serif;
            color: #75ab75;
        }

        .AppraisaleeSignOff {
            text-align: center;
            vertical-align: middle;
        }

        .labelTitleX {
            font-family: Arial, sans-serif;
            font-weight: 700;
            font-size: 1em;
        }

        #SignatureDIV {
            border: 2px solid lightsalmon;
            height: 250px;
            width: 400px;
            background: lightblue; /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(skyblue, white); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(skyblue, white); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(skyblue, white); /* For Firefox 3.6 to 15 */
            background: linear-gradient(skyblue, white); /* Standard syntax */
        }

        .disableMe {
        }

        .imgSetup {
            width: 21px;
            height: 21px;
            margin-bottom: -3px;
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

        <table style="width: 300px; text-align: center; margin: auto">

            <tr>
                <td colspan="3">
                    <h4>
                        <asp:Label ID="LabelSignOffTitle" runat="server" Text="Publish Document - Verify User"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td>Domain:</td>
                <td>
                    <asp:TextBox ID="txtDomain" runat="server" Width="120px" Text="cec" /></td>
                <td></td>
            </tr>
            <tr>
                <td>User ID :</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="120px" Text="mif" ReadOnly="true" /></td>
                <td></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" Width="120px" runat="server" />
                </td>
                <td></td>

            </tr>
            <tr>
                <td></td>
                <td>

                    <asp:Button ID="btnVerifyUser" Text="Verify User" Width="100px" runat="server" OnClick="btnVerifyUser_Click" />

                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="errorlabel" ForeColor="red" runat="server" Text="" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr id="SignOffDateDiv" runat="server">
                <td>Publish Date:</td>
                <td>
                    <input runat="server" type="text" id="SignOffDate" name="SignOffDate" size="9" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnReturn" Text="Publish" Width="100px" runat="server" OnClick="btnReturn_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <div class="loading">

                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <img src="../images/indicator.gif" alt="" />
                                <b>Publish......</b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                    </div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>


<script>

    var UserID = $("#hfUserID").val();
    var CategoryID = $("#hfCategory").val();
    var AreaID = $("#hfArea").val();
    var ItemCode = $("#hfCode").val();
    var SignOffWho;
    var SignOffImg;


    $(document).ready(function () {
        $("#SignOffDate").datepicker(
            {
                dateFormat: 'yy/mm/dd',
                showOn: "button",
                buttonImage: "../images/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                //minDate: minD,
                //maxDate: maxD,
                val: new Date().toDateString
            });

        $("#btnReturn").hide();
        //  $("section").css("height", vHeight)
        $("#SignOffDate").change(function () {
            $("#btnReturn").show();
        });

        $("#btnReturn").click(function (event) {
            try {
                //  $("#ActionPOPDIV", parent.document).fadeToggle("fast");
            }
            catch (ex)
            { window.alert("Sign off failed."); }
        });
    });



</script>
