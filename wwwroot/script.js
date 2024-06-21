const userName = document.getElementById("Username")
const lastName = document.getElementById("LastN")
const firstName = document.getElementById("FirstN")
const mail = document.getElementById("Mail")
const password = document.getElementById("Passwod")

function createUsers() {
  fetch('https://localhost:5001/api/User')
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

const createUser = () => {
  fetch("https://localhost:5001/api/User", {
    method: "POST",
    headers: {
      "Content-type": "application/json"
    },
    body: JSON.stringify({
      username: userName.value,
      lastName: lastName.value,
      firstName: firstName.value,
      email: mail.value,
      password: password.value,
    })
  }).then(res => res.json)
  .then(res => {
    console.log(res);
  })
}

firstName.addEventListener("input", () => {
  console.log("script is run")
})