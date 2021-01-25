function addItem() {
  let input = document.getElementById("newItemText");
  let element = document.createElement("li");
  element.textContent = input.value;
  document.getElementById("items").appendChild(element);
  input.value = "";
}
