<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LearningForm.aspx.cs" Inherits="PLF.PLFForm.LearningForm" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Verify User </title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache">
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />

    <style type="text/css">
        body {
            font-family: Arial, sans-serif,'Arial Narrow';
            font-size: small;
        }

        .FormTable1 {
            width: 100%;
            border-spacing: 0px;
            border-collapse: separate;
        }

        td {
            vertical-align: top;
        }

        .FormTable1 td, th {
            border: 1px solid grey;
        }

        .BDABox, .PLPBox2 {
            background-color: floralwhite;
            width: 99%;
            font-family: Arial, sans-serif, 'Arial Narrow';
            font-size: x-small;
            border: 0px;
        }

        .BDABox2 {
            background-color: floralwhite;
            width: 100%;
            color: black;
            border: 0px;
        }


        .LabelP {
            font-size: 12px;
            vertical-align: top;
            width: 20%;
        }

        #pageBody {
            height: 580px;
            width: 100%;
            overflow: auto;
        }

        .imgButton {
            width: 18px;
            height: 18px;
            padding-right: 25px;
            margin-bottom: -5px;
            border: 0px;
        }

        .linkbutton {
            width: 180px;
            height: 25px;
            border: 1px outset grey;
            padding: 3px 30px 2px 20px;
            margin-left: 20px;
        }

            .linkbutton:hover {
                background-color: lightskyblue;
            }

        #ButtonSave {
            height: 25px;
        }

        .BDAtitle {
            width: 20%;
        }

        .BDAtitle2 {
            width: 80%;
        }

        .BottonTab {
            height: 25px;
            display: inline;
            margin: 1px 0px 1px 0px;
            margin-right: -3px;
            padding: 3px 5px 0px 5px;
            border: 1px solid lightsalmon;
            border-top-left-radius: 9px;
            border-top-right-radius: 9px;
            border-radius: 9px 9px 0px 0px;
            background-color: transparent;
            width: 250px;
        }

        .selectedTab {
            color: white;
            border-top: 3px solid orange;
            border-bottom: 2px solid dodgerblue;
            background: dodgerblue; /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(lightblue,dodgerblue ); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(lightblue,dodgerblue ); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(lightblue,dodgerblue); /* For Firefox 3.6 to 15 */
            background: linear-gradient( lightblue,dodgerblue); /* Standard syntax */
        }

        .ApiCall {
            background-color: red;
        }
    </style>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Models/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div id="pageTop" runat="server">
            <asp:HiddenField ID="hfSchoolyear" runat="server" />
            <asp:HiddenField ID="hfSchoolcode" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfSignOff" runat="server" />
            <asp:HiddenField ID="hfSignOffSO" runat="server" />
            <asp:HiddenField ID="hfPublish" runat="server" />
            <asp:HiddenField ID="hfComplete" runat="server" />
            <asp:Button ID="ButtonSave" runat="server" Text="Save & Submit" />
            <a id="PrintPLF" href="#" runat="server" class="linkbutton" style="height: 25px;">
                <img alt="pdf file" src="../images/pdfReport.bmp" class="imgButton" />
                View PDF Form</a>
            <a id="SignOffPLF" href="#" runat="server" class="linkbutton">
                <img alt="sign off" src="../images/signature.png" class="imgButton" />
                Sign Off Form</a>
            <a id="PublishPLF" href="#" runat="server" class="linkbutton">
                <img alt="Publish" src="../images/publish.png" class="imgButton" />
                Publish Form</a>
            <asp:Label ID="LabelSaveResult" runat="server" Text=""></asp:Label>


        </div>
        <div style="text-align: center;">
            <h2>Toronto Catholic District School Board
                <br />
                K to 12 Professional Learning Form
                <asp:Label ID="LabelSchoolyear" runat="server" Text="2018-2019"></asp:Label>

            </h2>
        </div>
        <div>
            School Name:
            <asp:Label ID="LabelSchool" runat="server" Text="2018-2019"></asp:Label>
            <br />
            Principal Name:
            <asp:Label ID="LabelPrincipal" runat="server" Text="School Principal"></asp:Label>
            <br />
            Superintendent:
            <asp:Label ID="LabelSuperintendent" runat="server" Text="Area Superintendent "></asp:Label>
        </div>
        <div style="display: none;">
            Based on analysis of the data, in collaboration with staff identify a critical learning need area
            or strategy that addresses the learning of your school community (i.e., numeracy, assessment, 
            problem solving, inquiry learning, learning skills, etc.) 
        </div>
        <div id="PageTab" style="margin-bottom: -1px;">

            <asp:Button ID="btnDataReview" runat="server" Text="Data Review" CssClass="BottonTab" />
            <asp:Button ID="btnPlanning" runat="server" Text="Professional Learning Planning" CssClass="BottonTab" />
            <asp:HiddenField ID="hfSelectedTab" runat="server" />


        </div>
        <div id="pageBody" runat="server">



            <div id="FormContent" runat="server">
                <div id="DataReview" runat="server">
                    <table class="FormTable1">
                        <%--  <tr>
                            <td colspan="5" style="text-align: center">
                                <h3>DATA REVIEW </h3>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA01" runat="server" Text="BDA01" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA01" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA02" runat="server" Text="BDA02" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA02" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <th class="BDAtitle">
                                <asp:Label ID="LabelBDA11" runat="server" Text="BDA11" CssClass="LabelP"></asp:Label></th>
                            <th class="BDAtitle">
                                <asp:Label ID="LabelBDA12" runat="server" Text="BDA12" CssClass="LabelP"></asp:Label></th>
                            <th class="BDAtitle">
                                <asp:Label ID="LabelBDA13" runat="server" Text="BDA13" CssClass="LabelP"></asp:Label></th>
                            <th class="BDAtitle">
                                <asp:Label ID="LabelBDA14" runat="server" Text="BDA14" CssClass="LabelP"></asp:Label></th>
                            <th class="BDAtitle">
                                <asp:Label ID="LabelBDA15" runat="server" Text="BDA15" CssClass="LabelP"></asp:Label></th>
                        </tr>
                        <tr style="height: 300px;">
                            <td class="BDAtitle">
                                <textarea id="TextBDA11" runat="server" textmode="MultiLine" class="BDABox" rows="25" cols="20"></textarea>
                            </td>
                            <td class="BDAtitle">
                                <textarea id="TextBDA12" runat="server" textmode="MultiLine" class="BDABox" rows="25" cols="22"></textarea></td>
                            <td class="BDAtitle">
                                <textarea id="TextBDA13" runat="server" textmode="MultiLine" class="BDABox" rows="25" cols="22"></textarea></td>
                            <td class="BDAtitle">
                                <textarea id="TextBDA14" runat="server" textmode="MultiLine" class="BDABox" rows="25" cols="22"></textarea></td>
                            <td class="BDAtitle">
                                <textarea id="TextBDA15" runat="server" textmode="MultiLine" class="BDABox" rows="25" cols="22"></textarea></td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA21" runat="server" Text="BDA21" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA21" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA22" runat="server" Text="BDA22" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA22" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA23" runat="server" Text="BDA23" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA23" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA24" runat="server" Text="BDA24" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA24" runat="server" textmode="MultiLine" class="PLPBox2" rows="15" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA25" runat="server" Text="BDA25" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA25" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelBDA26" runat="server" Text="BDA26" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle" colspan="4">
                                <textarea id="TextBDA26" runat="server" textmode="MultiLine" class="PLPBox2" rows="18"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="PLPlanning" runat="server">
                    <table class="FormTable1">
                        <%-- <tr>
                            <td colspan="2" class="BDAtitle" style="text-align: center">
                                <h3>PROFESSIONAL LEARNING PLANNING: </h3>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP11" runat="server" Text="PLP11" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP11" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP12" runat="server" Text="PLP12" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP12" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP13" runat="server" Text="PLP13" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP13" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP14" runat="server" Text="PLP14" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP14" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP15" runat="server" Text="PLP15" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP15" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP16" runat="server" Text="PLP16" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP16" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP17" runat="server" Text="PLP17" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP17" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP18" runat="server" Text="PLP18" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP18" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP19" runat="server" Text="PLP19" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP19" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="BDAtitle">
                                <asp:Label ID="LabelPLP20" runat="server" Text="PLP20" CssClass="LabelP"></asp:Label>
                            </td>
                            <td class="BDAtitle2">
                                <textarea id="TextPLP20" runat="server" textmode="MultiLine" class="PLPBox2" rows="10" cols="108"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="pageFooter" runat="server"></div>

        <div id="ActionPOPDIV" class="bubble epahide">
            <div class="editTitle" style="display: block; padding-top: 2px;">
                <div id="ActionTitle" style="display: inline; float: left; width: 93%; font-weight: 600;"></div>
                <div style="display: inline; float: left;">
                    <img id="closeActionPOP" src="../images/close.ico" style="height: 25px; width: 25px; margin: -3px 0 -3px 0" />
                </div>
            </div>
            <iframe id="ActioniFramePage" name="ActioniFramePage" style="height: 300px; width: 99%" frameborder="0" scrolling="auto" src="iBlankPage.html" runat="server"></iframe>
        </div>
    </form>
</body>
</html>

<script src="../Scripts/jquery-3.2.1.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>

<script type="text/javascript">

    var UserID = $("#hfUserID").val();
    var schoolyear = $("#hfSchoolyear").val();
    var schoolcode = $("#hfSchoolcode").val();

    var workingYear;


    function openActionPage(vTop, vLeft, vHeight, vWidth, goPage, pTitle, signType) {
        goPage = goPage + "?yID=" + schoolyear + "&sID=" + schoolcode + "&tID=" + signType;
        try {
            $("#ActioniFramePage").attr('src', goPage);
            $("#ActionTitle").html(pTitle);
            $("#ActionPOPDIV").css({
                top: vTop,
                left: vLeft,
                height: vHeight,
                width: vWidth
            })

            $("#ActionPOPDIV").fadeToggle("fast");
        }
        catch (e) { }
    }

    $(document).ready(function () {

      //   getJSONJquery(); // test Web API Call  Get Method. This call works
        $("#closeActionPOP").click(function (event) {
            $("#ActionPOPDIV").fadeToggle("fast");
        });

        $("#PLPlanning").hide();
        $("#btnDataReview").addClass("selectedTab");
        $("#btnPlanning").click(function () {
            $("#DataReview").hide();
            $("#PLPlanning").show();
            $("#btnDataReview").removeClass("selectedTab")
            $("#btnPlanning").addClass("selectedTab");
            return false;
        })
        $("#btnDataReview").click(function () {
            $("#DataReview").show();
            $("#PLPlanning").hide();
            $("#btnDataReview").addClass("selectedTab")
            $("#btnPlanning").removeClass("selectedTab");
            return false;
        })
        $(".BDABox").change(function (event) {
            var id = $(this)[0].id; //event.id;
            var code = id.replace("Text", "");
            var value = $("#" + id).val();

            SaveTextContent(code, value);
        });
        //$("#ButtonSave").click(function () {
        //    return false;
        //})
        $(".PLPBox2").change(function (event) {
            var id = $(this)[0].id; //event.id;
            var code = id.replace("Text", "");
            var value = $("#" + id).val();

            SaveTextContent(code, value);
        });
        $(".PLPBox2").keydown(function (event) {
            $("#LabelSaveResult").text("");
        });
        $("#PrintPLF").click(function (event) {
            var rName = "PLFDocument"
            window.open('PDFPrint.aspx?rID=' + rName + '&yID=' + schoolyear + '&sID=' + schoolcode + '&rType=' + 'PDF' + '&rBlank=' + 'N', "PrintForm", "width=800 height=600, top=50, left=50, toolbars=no, scrollbars=no,status=no,resizable=yes");

        });
        $("#SignOffPLF").click(function (event) {
            var useRole = $("#hfUserRole").val();
            var complete = $("#hfComplete").val();
            if (useRole == "Principal" || useRole == "Admin") {
                if (complete == "Complete") {
                    var signType = "School";
                    var goPage = "LearningFormSignOff.aspx";
                    var pTitle = "PLF Sign Off";

                    openActionPage(100, 300, 250, 400, goPage, pTitle, signType);
                } else {
                    window.alert("Please complete all Professional Learning Form Fields!");
                }
            }
            else { window.alert("No Permission to sign off this Document.") }

        });
        $("#PublishPLF").click(function (event) {
            var useRole = $("#hfUserRole").val();
            var signedOff = $("#hfSignOffSO").val()
            if (useRole == "Principal" || useRole == "Admin") {
                if (signedOff == "SignedOff") {
                    var signType = "School";
                    var goPage = "LearningFormPublish.aspx";
                    var pTitle = "PLF Publish ";
                    openActionPage(100, 300, 250, 400, goPage, pTitle, signType);

                }
                else { window.alert("Please have your school superintendet sign off first! ") }
            }
            else { window.alert("No Permission to publish this Document.") }



        });

    });
    var DataUrl = {
        "SchoolYear": $("#hfSchoolyear").val(),
        "SchoolCode": $("#hfSchoolcode").val(),
        "myUrl": "https://webt.tcdsb.org/Webapi/PLF/Api/PLF/"
        //   "myUrl": "https://webt.tcdsb.org/Webapi/PLF/Api/PLF/?schoolYear=20182019&schoolCode=0290";
        //  "myUrl": "https://webt.tcdsb.org/Webapi/PLF/api/PLF";
        //  "myUrl": "https://learnwebcode.github.io/json-example/animals-1.json" test data link for verify AJAX call
    }

    function SaveTextContent(itemCode, value) {
        // Web service Call  this function works needs ScriptManager. uncomment below script.
         var helptext = PLF.Models.WebService.SaveText(UserID, schoolyear, schoolcode, itemCode, value, onSuccess, onFailure);
        //// using Restful POST method Call Web api to save data to DB  
        //var data = {
        //    "ItemCode": itemCode,
        //    "Title": UserID,
        //    "Notes": value.trim(),
        //    "IDS": 0,
        //    "SchoolYear": schoolyear,
        //    "SchoolCode": schoolcode
        //}
        //var apiUrl = DataUrl.myUrl;
        //// simple JQuery mothed call. worked
        //$.post(apiUrl, data, function (dataR, status) {
        //    var ok = status;
        //    alert("Data Saved Successfully");  //alert("Data: " + data + "\nStatus: " + status);
        //});
        //// Ajax Call  mothed works, 
        //$.ajax({
        //    url: apiUrl,
        //    type: 'POST',
        //    dataType: 'json',
        //    data: data,
        //    success: function (d) {
        //        alert("Data Saved Successfully");               
        //    },
        //    error: function () {
        //        alert("Data Save Failed");
        //    }
        //});

    }

   
    function onSuccess(result) {
        $("#LabelSaveResult").text("Save... : " + result);
    }
    function onFailure(result) {
        $("#LabelSaveResult").text("Save... : " + result);
    }


    var ApiCallButton = document.querySelector("#ButtonSave9");
    if (ApiCallButton)
        ApiCallButton.addEventListener("click", function () {

            //var objectA = {
            //    "name": "this my object property",
            //    "pLanguage": "javaScript",
            //    "sayHi": function () { return 'i  + ${this.name}'; },
            //    "askme": function (quest) { window.alert("This is a question:" + quest); }
            //}
            //alert(objectA.name);
            //alert(objectA.pLanguage);
            //alert(objectA.sayHi());
            //objectA.askme(" How old are you?");


            getJSONJquery();//  getmyJSONData(); this method works 

        });


    function renderHTMLonPage(data) {

        for (i = 0; i < data.length; i++) {
            var myLabel = "#Label" + data[i].ItemCode;
            var myArea = "#Text" + data[i].ItemCode;
            $(myLabel).text(data[i].Title);
            $(myArea).val(data[i].Notes);
            //  htmlString += "<P> Posting No. = " + data[i].ItemCode + "; Title is " + data[i].Title + "; PLF Content is " + data[i].Notes + "</p>";
            //  htmlString += " and Top5 applicant are: "
            // var applicant = data[i].Applicant;
            //for (j = 0; j < applicant.length; j++) {
            //    if (j === 0) {
            //        htmlString += applicant.Top5[j];
            //    } else { htmlString += " and " + applicant.Top5[j]; }
            //};
            //htmlString += " and Roster applicant are: "
            //for (j = 0; j < applicant.length; j++) {
            //    if (j === 0) {
            //        htmlString += applicant.Top5[j];
            //    } else { htmlString += " and " + applicant.Roster[j]; }
            //};
        };
        return false;
    }

    function getUrl() {
        return DataUrl.myUrl + "?schoolYear=" + DataUrl.SchoolYear + "&schoolCode=" + DataUrl.SchoolCode;
    }
    function getJSONJquery() {
        var myUrl = getUrl();
        $.get(myUrl, function (data, status) {
            // alert("Data: " + data + "\nStatus: " + status);
            renderHTMLonPage(data);
        });
        //$.getJSON(myUrl, function (result) {
        //    $.each(result, function (i, field) {
        //        $("div").append(field + " ");
        //    });
        //});
    }
    function getmyJSONData() {

        var myRequest = new XMLHttpRequest();

        //  myRequest.setRequestHeader("Access-Control-Allow-Origin", "https://webt.tcdsb.org/");
        //  myRequest.setRequestHeader("Content-Type", "application/json");
        var myUrl = getUrl();
        myRequest.open('GET', myUrl);
        myRequest.onload = function () {

            if (myRequest.status >= 200 && myRequest.status < 400) {
                var myData = JSON.parse(myRequest.responseText);
                renderHTMLonPage(myData);
            } else {
                window.alert("Server connected. but data access wrong");
            }
        };
        myRequest.onerror = function (ex) {
            var ms = ""
            window.alert("Ajax Call Failed. can not call from the link");
        };
        myRequest.send();
    }



</script>
