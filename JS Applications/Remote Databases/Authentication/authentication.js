// Your web app's Firebase configuration
var firebaseConfig = {
  apiKey: "AIzaSyAYAvpuDDci5kA-Z0r4N7dEct3Bqj4TCvQ",
  authDomain: "books-9b100.firebaseapp.com",
  projectId: "books-9b100",
  storageBucket: "books-9b100.appspot.com",
  messagingSenderId: "41459110192",
  appId: "1:41459110192:web:01b05f3e0e5f0b288cb8f5",
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);
const auth = firebase.auth();

const registerElement = document.querySelector("#register");
const loginElement = document.querySelector("#login");

const registerBtn = document.querySelector("#register-btn");
const loginBtn = document.querySelector("#login-btn");

const registerEmailInput = document.querySelector("#register-email");
const registerPasswordInput = document.querySelector("#register-password");

const loginEmailInput = document.querySelector("#login-email");
const loginPasswordInput = document.querySelector("#login-password");

const messageElement = document.querySelector('#message');

const loggedInListItems = document.getElementsByClassName('logged-in');
const loggedOutListItems = document.getElementsByClassName('logged-out');

function showRegister() {
  loginElement.classList.add("d-none");
  registerElement.classList.remove("d-none");
}

function showLogin() {
  registerElement.classList.add("d-none");
  loginElement.classList.remove("d-none");
}

function logout(){
  messageElement.textContent = '';
  auth.signOut()
  .then(() => {
    [...loggedOutListItems]
    .forEach(e => e.classList.remove('d-none'));
    [...loggedInListItems]
    .forEach(e => e.classList.add('d-none'));
    showLogin();
  }).catch((error) => {
    var errorMessage = error.message;
    messageElement.textContent = errorMessage;
  });
}

registerBtn.addEventListener("click", async (e) => {
  e.preventDefault();
  let email = registerEmailInput.value;
  let password = registerPasswordInput.value;
  auth
    .createUserWithEmailAndPassword(email, password)
    .then((userCredential) => {
      registerEmailInput.value = "";
      registerPasswordInput.value = "";
      messageElement.textContent = "Successfully registered.Please login...";
      setInterval(() => {
        messageElement.textContent = "";
        showLogin();
      }, 2000);
    })
    .catch((error) => {
      var errorMessage = error.message;
      messageElement.textContent = errorMessage;
    });
});

loginBtn.addEventListener("click", async (e) => {
  e.preventDefault();
  let email = loginEmailInput.value;
  let password = loginPasswordInput.value;
  auth
    .signInWithEmailAndPassword(email, password)
    .then((userCredential) => {
      loginEmailInput.value = "";
      loginPasswordInput.value = "";
      loginElement.classList.add("d-none");
      registerElement.classList.add("d-none");

     [...loggedOutListItems]
     .forEach(e => e.classList.add('d-none'));
     [...loggedInListItems]
     .forEach(e => e.classList.remove('d-none'));

      messageElement.textContent = `Hello, ${userCredential.user.email}, you're logged in!`;
    })
    .catch((error) => {
      var errorMessage = error.message;
      messageElement.textContent = errorMessage;
    });
})
