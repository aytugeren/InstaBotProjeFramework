let followingBotName = document.getElementById("FollowingBotName");
let workBot = document.getElementById("workBot");
let stopBot = document.getElementById("stopBot");
let warningTextOfFollowingBot = document.getElementById("warningTextOfFollowingBot");
let checkInstagramUser = document.getElementById("checkInstagramUser");
let getUserId = document.getElementById("profile");


//Sayfa Acildiginda
function ready(callback){

    if (document.readyState!='loading') callback();


    else if (document.addEventListener) 

    document.addEventListener('DOMContentLoaded', callback);


    else document.attachEvent('onreadystatechange', function(){

        if (document.readyState=='complete') callback();
    });
}

ready(function(){
    checkFollowingBotNameIsNull();
})

function getUsername(id){
    
}

function getParameterByName(name) {
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)");
    results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
 }

checkInstagramUser.addEventListener("click", function(){
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
      });

    const response = fetch("/Feature/CheckInstagramUser",{
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify({
            username : followingBotName.value,
            profileId : profile.innerText,
            featureId : getParameterByName('featureId')
        })
    }).then(res => res.json())
    .then(data => {
        if (data){
            Toast.fire({
                icon: 'success',
                title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
              })
        }else{
            Toast.fire({
                icon: 'warning',
                title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
              })
        }
    })
    .catch((error) => {
        Toast.fire({
            icon: 'warning',
            title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
          })
    });
})


function checkFollowingBotNameIsNull(){
    if (followingBotName.value == ''){
        workBot.hidden = true;
        stopBot.hidden = true;
        warningTextOfFollowingBot.innerText = "Lütfen Takipçisi Çekilecek Sayfayı Yazınız!";
    }
    else{
        workBot.hidden = false;
        stopBot.hidden = false;
        warningTextOfFollowingBot.innerText = "";
    }
}
