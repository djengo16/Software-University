import genEl from "../02.Students/dom-generator.js";

const baseUrl =
"https://my-movies-bb71a-default-rtdb.europe-west1.firebasedatabase.app/movies";
const extension = ".json";
let detailsImg;
let detailsHeader;
let detailsP;

function initializeApp() {
  // Your web app's Firebase configuration
  // For Firebase JS SDK v7.20.0 and later, measurementId is optional
  var firebaseConfig = {
    apiKey: "AIzaSyDenm8KkEoC2-sIZ_k2ZZfnUAC2W9Vkwy0",
    authDomain: "my-movies-bb71a.firebaseapp.com",
    projectId: "my-movies-bb71a",
    storageBucket: "my-movies-bb71a.appspot.com",
    messagingSenderId: "700762810650",
    appId: "1:700762810650:web:89aa547a5302827af0e4a3",
    measurementId: "G-9XQDX6EPPK",
  };
  // Initialize Firebase
  firebase.initializeApp(firebaseConfig);
  firebase.analytics();
  const auth = firebase.auth();

  document.getElementById("submit").addEventListener("click", logUser);

  function logUser() {
    const emailElement = document.getElementById("email");
    const passwordElement = document.getElementById("password");
    const loginForm = document.querySelector(".loginForm");
    const header = document.querySelector("#header");

    auth
      .signInWithEmailAndPassword(emailElement.value, passwordElement.value)
      .then((userCredential) => {
        // Signed in
        var user = userCredential.user;
        loginForm.setAttribute("style", "display:none;");
        header.textContent = `Hello ${user.email} ! :)`;
        onUserLogin();
        // ...
      })
      .catch((error) => {
        var errorCode = error.code;
        var errorMessage = error.message;
        header.textContent = `Error ${errorCode}: ${errorMessage}`;
      });
  }

  async function onUserLogin() {
    const moviesElement = document.querySelector("#movies");
    let ulElement = genEl("ul", "");

    await fetch(`${baseUrl}${extension}`)
      .then((res) => res.json())
      .then((data) => {
        Object.entries(data).forEach(([key, value]) => {
          let liEL = genEl("li", value.title, {
            className: "titleListItem",
            "data-id": key,
          });
          liEL.addEventListener("click", showDetails);
          ulElement.appendChild(liEL);
        });
        moviesElement.style.display = "block";
        moviesElement.appendChild(ulElement);

        detailsImg = genEl("img", "", { className: "details-img" }),
        detailsHeader = genEl("h3", "", { className: "details-h3" }),
        detailsP = genEl('p',"",{className:'details-p'}),

        moviesElement.appendChild(
          genEl(
            "div",
            [detailsImg,
            detailsHeader,
            detailsP],
            {
              className: "movie-details"
            }
          )
        );
      });
  }

  async function showDetails(e) {
    const id = e.currentTarget["data-id"];
    await fetch(`${baseUrl}/${id}.json`)
      .then((res) => res.json())
      .then((data) => {
        detailsImg.src = data['img-url'];
        detailsHeader.textContent = data['title'];
        detailsP.textContent = `Cast:\n${data['actors'].join(', ')}`;
      });
  }
}

initializeApp();