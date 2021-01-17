function solve() {
  let buttonElement = document.getElementsByTagName("button")[0];

  buttonElement.addEventListener("click", (event) => {
    let nameElement = document.getElementsByTagName("input")[0];
    let letter = nameElement.value.slice(0, 1).toUpperCase();
    let letterPosition = letter.charCodeAt(0) - 65;
    let liElement = document.getElementsByTagName("li")[letterPosition];

    nameElementValue =
      nameElement.value.slice(0, 1).toUpperCase() +
      nameElement.value.slice(1, nameElement.value.length).toLowerCase();

    if (!liElement.textContent) {
      liElement.textContent = nameElementValue;
    } else {
      liElement.textContent += `, ${nameElementValue}`;
    }
    nameElement.value = "";
  });
}
