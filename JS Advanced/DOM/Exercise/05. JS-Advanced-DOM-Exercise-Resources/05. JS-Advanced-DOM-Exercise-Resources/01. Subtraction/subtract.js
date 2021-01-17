function subtract() {
  let first = document.getElementById("firstNumber");
  let second = document.getElementById("secondNumber");
  let result = Number(first.value) - Number(second.value);
  document.getElementById("result").innerHTML = result;
}
