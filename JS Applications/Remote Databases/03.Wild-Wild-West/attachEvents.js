import genEl from "./dom-generator.js";
import loadCanvas from "./dom-generator.js"

const url = "https://students-ea182-default-rtdb.firebaseio.com";
const elements = {
  addPlayerBtn: () => document.querySelector("#addPlayer"),
  nameInput: () => document.querySelector("#addName"),
  playersDiv: () => document.querySelector("#players"),
  errorDiv: () => document.querySelector("#error"),
  canvas: () => document.querySelector("#canvas"),
  saveBtn: () => document.querySelector("#save"),
  reloadBtn: () => document.querySelector("#reload"),
};

function loadPlayers() {
  elements.playersDiv().innerHTML = "";
  fetch(`${url}/players.json`)
    .then((res) => res.json())
    .then((data) =>
      Object.entries(data).forEach(([key, value]) => {
        const playBtn = genEl("button", "Play", { className: "player-btn" });
        playBtn.setAttribute("data-id", key);
        playBtn.addEventListener("click", play);

        const deleteBtn = genEl("button", "Delete", {
          className: "player-btn",
        });
        deleteBtn.setAttribute("data-id", key);
        deleteBtn.addEventListener("click", deletePlayer);

        elements
          .playersDiv()
          .appendChild(
            genEl(
              "div",
              [
                genEl("li", `Name: ${value["name"]}`),
                genEl("li", `Money: ${value["money"]}`),
                genEl("li", `Bullets: ${value["bullets"]}`),
                playBtn,
                deleteBtn,
              ],
              { className: "player" }
            )
          );
      })
    )
    .catch(handleError);
}
loadPlayers();

elements.addPlayerBtn().addEventListener("click", addPlayer);

function addPlayer() {
  let name = elements.nameInput().value;
  elements.nameInput().value = "";
  if (name.trim() != "") {
    let player = {
      name,
      money: 500,
      bullets: 6,
    };
    fetch(`${url}/players.json`, {
      method: "POST",
      body: JSON.stringify(player),
    }).catch(handleError);
  }
}

function deletePlayer() {
  fetch(`${url}/players/${this.dataset.id}.json`, {
    method: "DELETE",
  })
    .then(loadPlayers)
    .catch(handleError);
}

function play() {
  elements.saveBtn().click();
  elements.saveBtn().setAttribute('style','display: block');
  elements.reloadBtn().setAttribute('style','display: block');
  elements.canvas().setAttribute('style','display: block');

  fetch(`${url}/players/${this.dataset.id}.json`)
  .then(res => res.json)
  .then(loadCanvas)
  .catch(handleError);
}

function handleError(err) {
  const errDiv = elements.errorDiv();
  errDiv.textContent = err;
  errDiv.setAttribute("style", "display: block");
  setInterval((err) => {
    errDiv.textContent = "";
    errDiv.setAttribute("style", "display: none");
  }, 3000);
}