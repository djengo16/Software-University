function addItem() {
  let textInput = document.getElementById("newItemText");
  let valueInput = document.getElementById("newItemValue");
  let newOption = document.createElement("option");
  newOption.setAttribute("value", valueInput.value);
  newOption.textContent = textInput.value;
  document.getElementById("menu").appendChild(newOption);
  textInput.value = "";
  valueInput.value = "";
}
