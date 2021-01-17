function growingWord() {
  let title = document.querySelector("#exercise > p");
  let px = 2;
  let colorChanges = {
    blue: "green",
    green: "red",
    red: "blue",
  };
  if (!title.hasAttribute("style")) {
    title.setAttribute("style", `color:blue; font-size: ${px}px`);
  } else {
    let currentPx = title.style["font-size"];
    let currentColor = title.style["color"];
    px = currentPx.substr(0, currentPx.length - 2) * 2;
    title.setAttribute(
      "style",
      `color:${colorChanges[currentColor]}; font-size: ${px}px`
    );
  }
}
