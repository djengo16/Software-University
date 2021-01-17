function toggle() {
  let buttonElement = document.getElementsByClassName("button")[0];
  let spanContent = buttonElement.innerHTML;
  if (spanContent === "More") {
    buttonElement.innerHTML = "Less";
    document.getElementById("extra").setAttribute("style", "display: block");
  } else {
    buttonElement.innerHTML = "More";
    document.getElementById("extra").setAttribute("style", "display: none");
  }
}
