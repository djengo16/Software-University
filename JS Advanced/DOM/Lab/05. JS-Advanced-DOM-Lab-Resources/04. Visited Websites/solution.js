function solve() {
  let sites = document.querySelectorAll(".link-1");

  Array.from(sites).forEach((x) =>
    x.addEventListener("click", (ev) => {
      let p = x.querySelector("p");
      let count = Number(p.textContent.split(" ")[1]);
      p.innerHTML = `visited ${count + 1} times`;
    })
  );
}
