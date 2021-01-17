function solve() {
  let buttonElement = document.getElementsByTagName("button")[0];
  buttonElement.addEventListener("click", (event) => {
    let nameElement = document.getElementsByTagName("input")[0].value;
    let letter = nameElement.slice(0, 1).toUpperCase();
    let letterPosition = letter.charCodeAt(0) - 64;
    let liElement = document.getElementsByTagName("li")[letterPosition - 1];
    if (!liElement.textContent) {
      liElement.textContent = nameElement;
      nameElement.value = "";
    } else {
      liElement.textContent += `, ${nameElement}`;
      nameElement.value = "";
    }
  });
}
