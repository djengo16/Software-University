function focus() {
  let inputs = document.getElementsByTagName("input");
  let lastFocused;
  for (const input of inputs) {
    input.addEventListener("focus", doFocus);
  }

  function doFocus(e) {
    let div = e.currentTarget.parentElement;
    div.classList.add("focused");
    if (lastFocused) {
      lastFocused.classList.remove("focused");
    }
    lastFocused = div;
  }
}
