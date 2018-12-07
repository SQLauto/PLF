var ApiContainer = document.getElementById("APIcontainer");
var btnAjaxCall = document.getElementById("btnAjaxCallGet");
var btnAjaxCallPost = document.getElementById("btnAjaxCallPost");

btnAjaxCall.addEventListener("click", function () {
    // var myData = getmyJSONData();
    var myRequest = new XMLHttpRequest();
    var myUrl = "https://www.wordpress.com/wordpress/wp/v2/posts?category=6&order=asc";
    myRequest.open('GET', myUrl);
    myRequest.onload = function () {
        if (myRequest.status >= 200 && myRequest.status < 400) {
            var myData = JSON.parse(myRequest.responseText);
            createHTML(myData);
            btnAjaxCall.remove();
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
 
function createHTML(data) {

    var htmlString ="";
    for (i = 0; i < data.length; i++) {
        htmlString += '<h2>' + data[i].title.rendered +  "</h2>";
        htmlString += data[i].content.rendered;     
    };
  
   
    ApiContainer.innerHTML = myGeneratedHTML;
}

var quickAddButton = document.querySelector("#btnAjaxCallPost");
if (quickAddButton)
{
    quickAddButton.addEventListener("click", function () {
        var myPostData = {
            "title": document.querySelector('.admin-quick-add [name="title"]').value,
            "content": document.querySelector('.admin-quick-add [name="content"]').value,
            "status":"publish"
       }
        var createPost = new XMLHttpRequest();
        createPost.open("POST", "https://www.wordpress.com/wordpress/wp/v2/posts");
        createPost.setRequestHeader("X-WP-Nonce",SerialziedNumber);
        createPost.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        createPost.send(JSON.stringify(myPostData));
        createPost.onreadystatechange = function () {
            if (createPost.readyState === 4) {
                if (createPost.status === 201) {
                    document.querySelector('.admin-quick-add [name="title"]').value = "";
                    document.querySelector('.admin-quick-add [name="content"]').value = "";
                } else {
                    alert("Error - try again.")
                }
            }
        }
    });
        
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



 