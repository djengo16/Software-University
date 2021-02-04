function solve() {
  let ulEl = document.querySelector("#dropdown-ul");
  let dropdownBtn = document.querySelector("#dropdown");
  let box = document.querySelector("#box");

  dropdownBtn.addEventListener("click", (e) => {
    ulEl.style.display === "none" || ulEl.style.display === ""
      ? (ulEl.style.display = "block")
      : (ulEl.style.display = "none");
    box.style.color = "white";
    box.style["background-color"] = "black";
  });

  ulEl.addEventListener("click", (e) => {
    let rgb = e.target.textContent;
    box.style.color = "black";
    box.style["background-color"] = rgb;
  });
}
