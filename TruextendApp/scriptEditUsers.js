document.getElementById("EditUserFrm").addEventListener("submit",PutUser)

async function PutUser(event){
    event.preventDefault();
    const formElement = event.target.elements;
    var url = 'https://localhost:44305/api/index';
    var data = {
        id: formElement.EditUserId.value,
        avatar_url: formElement.EditUserAvatar.value,
        github_url: formElement.EditUserGitHub.value,
        name: formElement.EditUserName.value,
        nickName: formElement.EditUserNickName.value
    };
    fetch(url, {
    method: 'PUT',
    body: JSON.stringify(data),
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => window.alert("User Doesn't Exist !!!!"))
    .then((response) => {
        window.alert("User Edited !!!!");
        console.log('Success:', response);
        window.history.back();
    });
}