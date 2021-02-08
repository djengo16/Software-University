function solve() {
  let table = document.querySelector("tbody");

  table.addEventListener("click", (e) => {

    if (e.target.tagName === "TD") {
      if(e.target.parentElement.style.backgroundColor === "rgb(65, 63, 94)"){
        e.target.parentElement.style.backgroundColor = '';
        return;
      }
      [...e.currentTarget.children].forEach(e => e.removeAttribute("style"));
      e.target.parentElement.style.backgroundColor = "#413f5e";
      }
  });
}