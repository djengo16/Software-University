function solve() {
  document.querySelector("button").addEventListener("click", show);
  document.querySelectorAll("button")[1].addEventListener("click", clear);
  let playground = [];
  let message = document.querySelector("#check").querySelector("p");
  let tableElement = document.querySelector("table");

  function clear() {
    let tds = [...document.querySelectorAll("input")];
    tds.forEach((x) => (x.value = ""));
    message.textContent = "";
    message.style.color = "";
    tableElement.style.border = "";
  }

  function show() {
    let tds = [...document.querySelectorAll("input")];
    let result = true;

    for (let i = 0; i < 9; i += 3) {
      playground.push([tds[i].value, tds[i + 1].value, tds[i + 2].value]);
    }

    for (let i = 0; i < 3; i++) {
      let firstRowNum = playground[0][i];
      let secRowNum = playground[1][i];
      let thirdRowNum = playground[2][i];

      if (firstRowNum == secRowNum || firstRowNum == thirdRowNum) {
        result = false;
        break;
      }
    }
    for (let i = 0; i < 3; i++) {
      let firstColNum = playground[i][0];
      let secColNum = playground[i][1];
      let thirdColNum = playground[i][2];

      if (firstColNum == secColNum || firstColNum == thirdColNum) {
        result = false;
        break;
      }
    }

    if (result) {
      tableElement.style.border = "2px solid green";
      message.textContent = "You solve it! Congratulations!";
      message.style.color = "green";
    } else {
      tableElement.style.border = "2px solid red";
      message.textContent = "NOP! You are not done yet...";
      message.style.color = "red";
    }
  }
}
