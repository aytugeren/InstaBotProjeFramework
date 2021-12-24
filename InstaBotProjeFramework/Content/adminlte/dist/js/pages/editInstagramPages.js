let pwEdit = document.getElementById("passwordEdit");
let cfEdit = document.getElementById("confirmPasswordEdit");

usernameEdit.addEventListener('input',function(){
    if (username.value == ''){
        addClass('warningTextPassword', 'btn btn-block bg-gradient-danger btn-xs','Eğer Boş Bırakırsanız Eski Şifreniz Kayıtlı Olarak Devam Edecektir!')
        checkSubmitIsAvailable(userCheckListData, true);
    }
})

pwEdit.addEventListener("input", function(){
    if (password.value == ''){
        addClass('warningTextPassword', 'btn btn-block bg-gradient-danger btn-xs','Eğer Boş Bırakırsanız Eski Şifreniz Kayıtlı Olarak Devam Edecektir!')
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

cfEdit.addEventListener("input", function(){
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