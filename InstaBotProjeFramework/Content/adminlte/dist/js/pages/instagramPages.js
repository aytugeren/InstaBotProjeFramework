let userCheckListData = [];
let userCheckListDataEdit = [];

let username = document.getElementById("username");
let url = document.getElementById("url");
let password = document.getElementById("password");
let confirmPassword = document.getElementById("confirmPassword");
let submitButton = document.getElementById("submitButtonForUser");

userCheckListData.push(username)
userCheckListData.push(url);
userCheckListData.push(password)
userCheckListData.push(confirmPassword);

let usernameEdit = document.getElementById("usernameEdit");
let urlEdit = document.getElementById("urlEdit");
let descriptionEdit = document.getElementById("descriptionEdit");
let pwEdit = document.getElementById("passwordEdit");
let cfEdit = document.getElementById("confirmPasswordEdit");
let Id = document.getElementById("Id");
let submitButtonEdit = document.getElementById("submitButtonForUserEdit");

userCheckListDataEdit.push(usernameEdit)
userCheckListDataEdit.push(urlEdit);


function ready(callback){

    if (document.readyState!='loading') callback();


    else if (document.addEventListener) 

    document.addEventListener('DOMContentLoaded', callback);


    else document.attachEvent('onreadystatechange', function(){

        if (document.readyState=='complete') callback();
    });
}

ready(function(){
    checkSubmitIsAvailable(userCheckListData, false);
})

username.addEventListener("focusout", function(){
    checkUsernameOfUser(username.value);
});

url.addEventListener("focusout", function(){
    checkUrlOfUser(url.value);
})

url.addEventListener("focus",function(){
    removeClass("warningTextUrl", 'btn btn-block bg-gradient-danger btn-xs')
})


password.addEventListener("input", function(){
    if (password.value == ''){
        addClass('warningTextPassword', 'btn btn-block bg-gradient-danger btn-xs','Lütfen ilgili alanı doldurunuz!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else if (confirmPassword.value !== password.value){
        addClass('warningTextPassword', 'btn btn-block bg-gradient-danger btn-xs','Lütfen şifrenizi doğrulayınız!')
    }
    else{
        removeClass("warningTextPassword", 'btn btn-block bg-gradient-danger btn-xs')
        checkSubmitIsAvailable(userCheckListData, false);
        checkUsernameOfUser(username.value);
    }
})

confirmPassword.addEventListener("input", function(){
    if (confirmPassword.value !== password.value){
        addClass('warningTextConfirmPassword', 'btn btn-block bg-gradient-danger btn-xs','Parola ayni olmali!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else{
        removeClass("warningTextConfirmPassword", 'btn btn-block bg-gradient-danger btn-xs')
        removeClass("warningTextPassword", 'btn btn-block bg-gradient-danger btn-xs')
        checkSubmitIsAvailable(userCheckListData, false);
        checkUsernameOfUser(username.value);
        checkUrlOfUser(url.value);
    }
})

async function submitTheForm(data){
    const response = await fetch("/InstagramPages/AddInstagramPages",{
        method:'POST',
        mode:'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => res.json())
    .then(data => {console.log(data)});
}

async function checkUsernameOfUser(username){
    var data = { username : username};
    const response = await fetch("/InstagramPages/CheckUsernameOfUser",{
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => res.json())
    .then(data => {result = data})
    .catch((error) => {
        console.log("Error", error);
    });

    if (result){
        addClass('warningTextUsername', 'btn btn-block bg-gradient-danger btn-xs','Böyle bir kullanıcı bulunmaktadır.')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else if (username == '' || username == undefined){
        addClass('warningTextUsername', 'btn btn-block bg-gradient-danger btn-xs','Lütfen ilgili alanı doldurunuz!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else{
        removeClass("warningTextUsername", 'btn btn-block bg-gradient-danger btn-xs')
        checkSubmitIsAvailable(userCheckListData, false);
    }
}

async function checkUrlOfUser(url){
    var data = { url : url};
    const response = await fetch("/InstagramPages/CheckUsernameOfUrl",{
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => res.json())
    .then(data => {result = data})
    .catch((error) => {
        console.log("Error", error);
    });

    if (result){
        addClass('warningTextUrl', 'btn btn-block bg-gradient-danger btn-xs','Böyle bir Url vardır!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else if (url == '' || url == undefined){
        addClass('warningTextUrl', 'btn btn-block bg-gradient-danger btn-xs','Lütfen ilgili alanı doldurunuz!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
    else{
        removeClass("warningTextUrl", 'btn btn-block bg-gradient-danger btn-xs')
        checkSubmitIsAvailable(userCheckListData, false);
        checkUsernameOfUser(username.value)
    }
}

const addClass = (selector, classList, warningText) => {
    const element = document.getElementById(selector);
    const classes = classList.split(' ')
    classes.forEach((item, id) =>{
        element.classList.add(item)
    });
    element.innerHTML = warningText;
}

const removeClass = (selector, classList) => {
    const element = document.getElementById(selector);
    const classes = classList.split(' ')
    classes.forEach((item, id) =>{
        element.classList.remove(item)
    });
    element.innerHTML = "";
}

const checkSubmitIsAvailable = (list, isError) => {
    var result = "Kaydet";
    var resultStatus = false;
    list.forEach((item) =>{
        if ((item.value == null || item.value == '') || isError){
            result = "Lütfen ilgili alanları doldurunuz!";
            resultStatus = true;
        }
    });
    
    submitButton.innerHTML = result;
    submitButton.disabled = resultStatus;
}

const checkSubmitIsAvailableForEditModel = (list, isError) => {
    var result = "Kaydet";
    var resultStatus = false;
    list.forEach((item) =>{
        if ((item.value == null || item.value == '') || isError){
            result = "Lütfen ilgili alanları doldurunuz!";
            resultStatus = true;
        }
    });
    
    submitButtonEdit.innerHTML = result;
    submitButtonEdit.disabled = resultStatus;
}

function getEditModalByUrl(url){
    editInstagramProfile(url);
}

async function editInstagramProfile(url) {
    const response = await fetch("/InstagramPages/EditInstagramProfileByUrl",{
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify({
            url : url
        })
    }).then(res => res.json())
    .then(data => {return data})
    .catch((error) => {
        console.log("Error", error);
    });

    usernameEdit.value = response.Username;
    urlEdit.value = response.Url;
    descriptionEdit.value = response.Description;
    Id.value= response.Id;
}

usernameEdit.addEventListener('input',function(){
    if (usernameEdit.value == ''){
        addClass('warningTextUsernameEdit', 'btn btn-block bg-gradient-danger btn-xs','Lütfen ilgili alanı doldurunuz!')
        checkSubmitIsAvailableForEditModel(userCheckListDataEdit);
    }
    else{
        removeClass("warningTextUsernameEdit", 'btn btn-block bg-gradient-danger btn-xs')
        checkSubmitIsAvailableForEditModel(userCheckListDataEdit);
    }
})

async function getRemoveModalById(id){
    const response = await fetch("/InstagramPages/DeleteInstagramProfile",{
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers:{
            'Content-Type' : 'application/json'
        },
        body:JSON.stringify({
            id : id
        })
    });
}