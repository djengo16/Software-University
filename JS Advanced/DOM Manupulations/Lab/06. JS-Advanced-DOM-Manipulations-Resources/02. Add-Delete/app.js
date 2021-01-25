function addItem() {
  let ulElement = document.getElementById("items");
  let input = document.getElementById("newText");

  let deleteElement = document.createElement("a");
  deleteElement.textContent = "[Delete]";
  //   deleteElement.style.paddingLeft = `${10}px`;
  //   deleteElement.style.color = "red";
  //   deleteElement.style.fontstyle = "bold";
  //   deleteElement.style.cursor = "pointer";
  deleteElement.setAttribute("href", "#");

  deleteElement.addEventListener("click", (e) => {
    let parentElement = e.target.parentElement;
    parentElement.remove();
  });

  let li = document.createElement("li");
  li.textContent = input.value;
  li.appendChild(deleteElement);
  input.value = "";

  ulElement.appendChild(li);
}
