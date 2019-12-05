document.getElementById("NewUserFrm").addEventListener("submit",PostUser)

async function PostUser(event){
    event.preventDefault();
    const formElement = event.target.elements;
    var url = 'https://localhost:44305/api/index';
    var data = {
        avatar_url: formElement.NewUserAvatar.value,
        github_url: formElement.NewUserGitHub.value,
        name: formElement.NewUserName.value,
        nickName: formElement.NewUserNickName.value
    };
    fetch(url, {
    method: 'POST',
    body: JSON.stringify(data),
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((response) => {
        window.alert("User Created !!!!");
        console.log('Success:', response)
        window.history.back();
    });
}