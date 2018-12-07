var pageCount = 1;
var myDIV = document.getElementById("myDIV");
var btnAjaxCall = document.getElementById("btnAjaxCall");
btnAjaxCall.addEventListener("click", function () {
    // var myData = getmyJSONData();
    var myRequest = new XMLHttpRequest();
    var myUrl = "https://webapp.tcdsb.org/LTO/api/Applicants";
    myRequest.open('GET', myUrl);
    myRequest.onload = function () {
        if (myRequest.status >= 200 && myRequest.status < 400) {
            var myData = JSON.parse(myRequest.responseText);
            renderHTMLonPage(myData);
        } else {
            window.alert("Server connected. but data access wrong");
        }

    };
    myRequest.onerror = function () {
        window.alert("Ajax Call Failed");
    };
    myRequest.send();
    pageCount++;
    if (pageCount > 4) {
        btnAjaxCall.classList.add("hide-me");
    }
});
function renderHTMLonPage(data) {
    var htmlString = "This is my Ajax call Data content '< br/>' ";
    for (i = 0; i < data.length; i++) {
        htmlString += "<P> Posting No. = " + data[i].PostingNo + "; Title is " + data[i].Title + "; School Name is " + data[i].School + "</p>";
        htmlString += " and Top5 applicant are: "
        var applicant = data[i].Applicant;
        for (j = 0; j < applicant.length; j++) {
            if (j === 0) {
                htmlString += applicant.Top5[j];
            } else { htmlString += " and " +  applicant.Top5[j];}
        };
        htmlString += " and Roster applicant are: "
        for (j = 0; j < applicant.length; j++) {
            if (j === 0) {
                htmlString += applicant.Top5[j];
            } else { htmlString += " and " + applicant.Roster[j]; }
        };
    };
    myDIV.insertAdjacentHTML('beforeend', htmlString);

}
// for Handlerbar register function
Handlebars.registerHelper("calculateAge", function (birthYear) {
    var age = new Date().getUTCFullYear() - birthYear;
    if (age > 0)
    { return age + " years old"; }
    else {
        return "Less than a year old";
    }
}); 
// for Handlerbar add to HTL container
function createHTML(data) {
    var rawTemplate = documument.getElementById("myTemplate").innerHTML;
    var compiledTemplate = Handlebars.compile(rawTemplate);
    var myGeneratedHTML = compiledTemplate(data);

    var myContainer = documument.getElementById("myContainer");
    myContainer.innerHTML = myGeneratedHTML;
}

function getmyJSONData() {
    var myRequest = new XMLHttpRequest();
    var myUrl = "https://webapp.tcdsb.org/LTO/api/postings";
    myRequest.open('GET', myUrl);
    myRequest.onload = function () {
        var myData = JSON.parse(myRequest.responseText);
        // console.log(myData[0]);
        // console.log(myData[0].Title);
        renderHTMLonPage(myData);
    }
    myRequest.send();
    return myData;
}



var mySource = [
    {
        "PostingNo": "2018-1001",
        "Title": "English Gr6. Teacher",
        "School": "St. Mary school",
        "Applicant": {
            "Top5": ["appplicant 1", "appplicant 2", "appplicant 3"],
            "Roster": ["Roster1", "Roster2", "Rostr3"]
        }
    },
    {
        "PostingNo": "2018-1002",
        "Title": "Math Teacher",
        "School": "St. Mary school",
        "Applicant": {
            "Top5": ["appplicant 1", "appplicant 2", "appplicant 3"],
            "Roster": ["Roster1", "Roster2", "Rostr3"]
        }
    },
    {
        "PostingNo": "2018-1003",
        "Title": "French core Teacher",
        "School": "St. Josphone school",
        "Applicant": {
            "Top5": ["appplicant 1", "appplicant 2", "appplicant 3"],
            "Roster": ["Roster1", "Roster2", "Rostr3"]
        }
    }
]