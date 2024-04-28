"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("UsersInRoom", (users) => {
    console.log(users);
    document.querySelector("chatlist").innerHTML = "";
    users.forEach(function(user){
        console.log(`USERID: ${user.userId}, ROOM ${user.room}`);
        document.querySelector("chatlist").innerHTML += `\
        <chatrow>
            <chatpic>${user.userId}</chatpic>
            <chatname>${user.room}</chatname>
        </chatrow>`;
    });
});

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var currentuser = document.getElementById("userInput").value;
    if(currentuser == user){
        li.classList.add("sent");
    } else {
        li.classList.add("received");
    }
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    var time = (new Date).toLocaleString();
    li.textContent = `${time} ${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    console.log("clicked send message");
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    scrollToBottom();
    event.preventDefault();
});

document.getElementById("joinRoom").addEventListener("click", function (event) {
    var userId = document.getElementById("userInput").value;
    var room = document.getElementById("roomNumber").value;
    console.log(`${userId} clicked join room`);
    connection.invoke("JoinRoom", {userId, room}).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function scrollToBottom(){
    console.log("scroll called");
    var chatwindow = document.querySelector("chatwindow");
    chatwindow.scrollTop = chatwindow.scrollHeight;
}