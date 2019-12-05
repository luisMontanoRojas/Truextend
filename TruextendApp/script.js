document.getElementById("getUsers").addEventListener("click", show);

async function show(){
        try{
            const request=await fetch('https://localhost:44305/api/index');
            const data=await request.json()
            document.getElementById("usersContainer").innerHTML=`<table><tr>
            <th>Id</th>
            <th>Avatar Url</th>
            <th>GitHub Url</th>
            <th>Name</th>
            <th>nickName</th>
            </tr>
            ${data.map(e=>`<tr>
                <td> ${e.id} </td>
                <td>
                    <img src="${e.avatar_url}" width=150" height="70"> 
                </td>
                <td> <a href="${e.github_url}" target="_blank"> ${e.github_url} </a></td>
                <td> ${e.name} </td>
                <td> ${e.nickName} </td>
            </tr>`).join('')}

            </table>`
        }
        catch(error){

        }
}

document.getElementById("DeleteUserForm").addEventListener("submit",DeleteUser)
async function DeleteUser(event){
    event.preventDefault();
    const formElement = event.target.elements;
    var url = 'https://localhost:44305/api/index';
    var data = formElement.GetUserToDeleteId.value;
    fetch(url, {
    method: 'DELETE',
    body: JSON.stringify(data),
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => 
        window.alert("User Doesn't Exist !!!!")
        )
    .then((response) => {
        window.alert("User Delete !!!!");
        console.log('Success:', response)
    });
}

document.getElementById("GetUserForm").addEventListener("submit",GetUser)
async function GetUser(event){
    event.preventDefault();
    const formElement = event.target.elements;
    var url = 'https://localhost:44305/api/index';
    var x =  formElement.GetUserId.value;
    url = url+'/'+x;
    fetch(url, {
    method: 'GET',
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => 
        window.alert("This user doesn't exist.")
        )
    .then((response) => {
        document.getElementById("usersContainer").innerHTML=`<table><tr>
            <td>Id</td>
            <td>${response.id}</td>
            </tr>
            <tr>
            <td>Avatar</td>
            <td><img src="${response.avatar_url}" width=150" height="200"></td>
            </tr>
            <tr>
            <td>GitHub url</td>
            <td><a href="${response.github_url}" target="_blank"> ${response.github_url} </a></td>
            </tr>
            <tr>
            <td>Name</td>
            <td>${response.name}</td>
            </tr>
            <tr>
            <td>NickName</td>
            <td>${response.nickName}</td>
            </tr>
            </table>`
    });
}

document.querySelector('#boton').addEventListener('click', traerDatos)
function traerDatos(){
    const xhttp = new XMLHttpRequest();
    console.log(xhttp);

    xhttp.open('GET', 'user.json',true);
    // xhttp.setRequestHeader('Content-type', 'application/json');

    xhttp.send();

    xhttp.onreadystatechange = function(){
        if(this.readyState == 4 && this.status == 200){
            let datos = JSON.parse(this.responseText);
            let res=document.querySelector('#res'); 
            res.innerHTML='';

            for(let item of datos){
                res.innerHTML += `
                    <tr>
                        <td>${item.id}</td>
                        <td>${item.avatar_url}</td>
                        <td>${item.github_url}</td>
                        <td>${item.name}</td>
                        <td>${item.nickName}</td>
                    </tr>
                `
            }

        }
    }
}