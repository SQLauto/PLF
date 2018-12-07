var apprScreenH = 30;
var apprScreenH1 = 5;
var apprScreenH2 = 130;
var apprScreenH3 = 150;
$(".imgCommentsMenu").mouseenter(function (event) {

    var vTop = event.currentTarget.offsetTop;
    var vLeft = event.currentTarget.offsetLeft - 200;
    $("#ActionMenuDIV").css({
        top: vTop + 25,
        left: vLeft
    })
    $("#ActionMenuDIV").fadeToggle("fast");
});
$("#ActionMenuDIV .menuLink").click(function (event) {
    $("#ActionMenuDIV").fadeToggle("fast");
    var pID = $(this)[0].id;
    var vTop = event.currentTarget.offsetTop + 50;
    var vLeft = 100; //  event.currentTarget.offsetLeft -500;
    var vHeight = 410;
    if (pID === "BoardStrategyPlan") {
        $("#ActioniFramePage").css({
            height: 410,
        })
    }
    var vWidth = 650;
    var goPage = "Loading3.aspx?pID=" + pID;
    var pTitle = "Text Box Content " + pID;
    openActionPage(vTop, vLeft, vHeight, vWidth, goPage, pTitle);

});
$("#ActionMenuDIV .menuLinkAGP").click(function (event) {
    $("#ActionMenuDIV").fadeToggle("fast");
    var pID = $(this)[0].id;
    var vTop = event.currentTarget.offsetTop + 50;
    var vLeft = 100; //  event.currentTarget.offsetLeft -500;
    var vHeight = 410;
    var vWidth = 650;
    var goPage = "Loading3.aspx?pID=" + pID;
    var pTitle = "Text Box Content " + pID;
    openActionPageAGP(vTop, vLeft, vHeight, vWidth, goPage, pTitle);

});

$(".imgHelp").mouseenter(function (event) {

    // ItemCode = $(this)[0].id.replace("img_", "");
    var helptext = PLF.Models.WebService1.GetHelpContent("Read", UserID, CategoryID, AreaID, ItemCode, "Help", onSuccess, onFailure);

    var vTop = event.currentTarget.offsetTop;
    var vLeft = event.currentTarget.offsetLeft;
    if (vLeft < 100)
    { vLeft = vLeft + 20; }
    else {
        if (vLeft - 300 < 0)
        { vLeft = vLeft - 100; }
        else {
            vLeft = vLeft - 300;
        }
    }

    $("#HelpDIV").css({
        top: vTop + 25,
        left: vLeft
    })
    $("#HelpDIV").fadeToggle("fast");

});
$(".imgEP").mouseenter(function (event) {

    // ItemCode = $(this)[0].id.replace("img_", "");
    var helptext = PLF.Models.WebService1.GetHelpContent("Read", UserID, CategoryID, AreaID, ItemCode, "EP", onSuccess, onFailure);

    var vTop = event.currentTarget.offsetTop;
    var vLeft = event.currentTarget.offsetLeft;
    if (vLeft - 300 < 0)
    { vLeft = vLeft - 100; }
    else {
        vLeft = vLeft - 300;
    }
    $("#HelpDIV").css({
        top: vTop + 25,
        left: vLeft
    })
    $("#HelpDIV").fadeToggle("fast");

});

$(".imgHelp").mouseleave(function (event) {
    if ($("#HelpDIV").css('display') === "block") {
        $("#HelpDIV").fadeToggle("fast");
    }
});

$(".imgHelp").dblclick(function (event) {
    EditPageItemTitle();
});

$(".imgEP").mouseleave(function (event) {
    if ($("#HelpDIV").css('display') === "block") {
        $("#HelpDIV").fadeToggle("fast");
    }
});


//$(".labelTitle").dblclick(function (event) {
//    EditPageItemTitle();
//if ($("#hfUserLoginRole").val() === "Admin") {
//    if ($("#TitleEditDIV").css('display') === "block") {
//        $("#TitleEditDIV").fadeToggle("fast");
//    }
//    else {
//        var Helptext = PLF.Models.WebService1.GetHelpContent("Read", UserID, CategoryID, AreaID, ItemCode, "Help", onSuccess21, onFailure);
//        $("#TextTitleEdit").val($("#title_" + ItemCode).text());
//        if ($("#Subtitle_" + ItemCode) != "undefined") {
//            $("#TextSubTitleEdit").val($("#Subtitle_" + ItemCode).text());
//        }
//        var vTop = event.currentTarget.offsetTop;
//        var vLeft = event.currentTarget.offsetLeft;
//        $("#TitleEditDIV").css({
//            top: 50,
//            left: 50
//        })

//        $("#TitleEditDIV").fadeToggle("fast");
//    }
//}
//});


$(".imgRecovery").click(function (event) {
    var vTop = event.currentTarget.offsetTop + 100;
    var vLeft = 8; // event.currentTarget.offsetLeft;
    var vHeight = 400;
    var vWidth = 650;
    var goPage = "Loading3.aspx?pID=Recovery";
    var pTitle = "Text Box Content Recovery";
    openActionPage(vTop, vLeft, vHeight, vWidth, goPage, pTitle);
});
function onFailure(result) {
    window.alert(result);
}
function onSuccess(result) {
    // $("#textHelp").text(result);
    $("#HelpTextContent").val(result);
    var n = result.length;
    if (n > 500) {
        $("#HelpDIV").css({
            height: 400,
            width:600
        })
    }
    if (n > 200) {
        $("#HelpDIV").css({
            height: 350
        })
    }
}
function onSuccess2(result) {
    $("#TextHelpEdit").text(result);
}

function onSuccess3(result) {
    window.alert("Help Content Save " + result);
}
function onSuccess4(result) {
    $("#textHelp").text(result);
}



function EditPageItemTitle() {
    if ($("#hfRunningModel").val() === "Design") {
        if ($("#ActionPOPDIV").css('display') === "block")             //TitleEditDIV
        {
            $("#ActionPOPDIV").fadeToggle("fast");
        }
        else {
            var pTitle = "Title and Help Conetent Edit";
            $("#ActioniFramePage").css({
                height: 490
            })
            goPage = "Loading3.aspx?pID=HelpContent" + "&type=" + CategoryID + "&aID=" + AreaID + "&iCode=" + ItemCode;
            $("#ActioniFramePage").attr('src', goPage);
            $("#ActionTitle").html(pTitle);
            $("#ActionPOPDIV").css({
                top: 50,
                left: 5,
                height: 520,
                width: 700
            })
            $("#ActionPOPDIV").fadeToggle("fast");
        }
    }
}


function goActionPage(goPage) {
    var vTop = 100;
    var vLeft = 8;
    var vHeight = 400;
    var vWidth = 650;
    var pTitle = "Text Box Content" + goPage;
    var goPage = "Loading3.aspx?pID=" + goPage;
    openActionPage(vTop, vLeft, vHeight, vWidth, goPage, pTitle);
}

function openActionPage(vTop, vLeft, vHeight, vWidth, goPage, pTitle) {
    goPage = goPage + "&type=" + CategoryID + "&aID=" + AreaID + "&iCode=" + ItemCode + "&domainID=" + DomainID + "&competencyID=" + CompetencyID
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

function openActionPageAGP(vTop, vLeft, vHeight, vWidth, goPage, pTitle) {
    goPage = goPage + "&type=" + CategoryID + "&aID=" + AreaID + "&iCode=" + ItemCode + "&SeqNo=" + seqNo + "&ActionItem=" + actionItem;
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