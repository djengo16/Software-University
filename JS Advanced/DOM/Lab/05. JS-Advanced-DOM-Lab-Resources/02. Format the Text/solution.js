function solve() {
  let textInput = document.getElementById("input");
  let sentences = textInput.innerHTML.split(".").filter((x) => x != "");
  let divElement = document.getElementById("output");
  while (sentences.length != 0) {
    let elemets = [];
    for (let i = 0; i < 3; i++) {
      if (sentences[0]) {
        elemets.push(sentences.shift() + ".");
      }
    }
    let currentParagraph = document.createElement("p");
    currentParagraph.innerHTML = elemets.join("");
    divElement.appendChild(currentParagraph);
  }
}
