function solve() {
  document.querySelector(".cards").addEventListener("click", pickCard);
  let result = document.querySelector("#result");
  let history = document.querySelector("#history");
  let currGameTopResult = result.children[0];
  let currGameBottomResult = result.children[2];
  let currGameTopCard;
  let currGameBottomCard;
  function pickCard(e) {
    if (
      currGameTopResult.textContent != "" &&
      currGameBottomResult.textContent != ""
    ) {
      currGameBottomResult.textContent = "";
      currGameTopResult.textContent = "";
    }

    if ((e.target.parentElement.id = "player1Div")) {
      currGameTopResult.textContent = Number(e.target.name);
      currGameTopCard = e.target;
    } else {
      currGameBottomResult.textContent = Number(e.target.name);
      currGameBottomCard = e.target;
    }
    //both of them selected
    e.target.src = "images/whiteCard.jpg";
    if (
      currGameTopResult.textContent != "" &&
      currGameBottomResult.textContent != ""
    ) {
      if (currGameTopResult.textContent > currGameTopResult.textContent) {
        currGameTopCard.setAttribute("style", "2px solid green");
        currGameBottomCard.setAttribute("style", "2px solid red");
      } else {
        currGameTopCard.setAttribute("style", "2px solid red");
        currGameBottomCard.setAttribute("style", "2px solid green");
      }
      history.textContent += `[${currGameTopResult} vs ${currGameBottomCard}}]`;
    }
  }
}
