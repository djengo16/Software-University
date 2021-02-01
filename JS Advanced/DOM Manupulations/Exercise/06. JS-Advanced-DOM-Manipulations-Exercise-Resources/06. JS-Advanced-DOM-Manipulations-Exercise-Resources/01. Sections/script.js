function create(words) {
  let content = document.getElementById("content");
  words.forEach((word) => {
    let div = document.createElement("div");
    let p = document.createElement("p");
    div.addEventListener("click", show);
    p.textContent = word;
    p.style.display = "none";
    div.appendChild(p);
    content.appendChild(div);
  });

  function show(e) {
    let target = e.currentTarget.children[0];
    target.style.display = "block";
  }
}
