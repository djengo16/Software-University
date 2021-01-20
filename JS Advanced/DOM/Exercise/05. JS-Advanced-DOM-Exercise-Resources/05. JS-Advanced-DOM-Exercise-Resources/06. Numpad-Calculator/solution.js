function solve() {
  let keys = document.getElementsByClassName("keys")[0].childNodes;
  Array.from(keys).forEach((key) => key.addEventListener("click", clickKey));

  document.getElementsByClassName("clear")[0].addEventListener("click", () => {
    document.getElementById("expressionOutput").textContent = "";
    document.getElementById("resultOutput").textContent = "";
  });

  function clickKey(e) {
    let value = e.target.value;
    if (value !== "=") {
      let expressions = ["-", "+", "/", "*"];

      if (expressions.includes(value)) {
        document.getElementById("expressionOutput").textContent += ` ${value} `;
      } else {
        document.getElementById("expressionOutput").textContent += value;
      }
    } else {
      let operationElements = document
        .getElementById("expressionOutput")
        .textContent.trim()
        .split(" ");

      let resultElement = document.getElementById("resultOutput");

      if (operationElements.length != 3) {
        resultElement.textContent = "NaN";
      } else {
        let firstOperand = Number(operationElements[0]);
        let expression = operationElements[1];
        let secondOperand = Number(operationElements[2]);
        let operations = {
          "+": () => firstOperand + secondOperand,
          "-": () => firstOperand - secondOperand,
          "*": () => firstOperand * secondOperand,
          "/": () => firstOperand / secondOperand,
        };
        resultElement.textContent = operations[expression]();
      }
    }
  }
}
