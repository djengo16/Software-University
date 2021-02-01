function lockedProfile() {
  let btns = document.getElementsByTagName("button");
  Array.from(btns).forEach((btn) => {
    btn.addEventListener("click", showHide);
  });

  function showHide(e) {
    let isLocked = e.currentTarget.parentElement.children[2].checked;
    let option = e.currentTarget.textContent;
    let div = e.currentTarget.previousElementSibling;

    if (isLocked) {
      return;
    }
    if (option === "Hide it") {
      div.style.display = "none";
      e.currentTarget.textContent = "Show more";
    } else {
      div.style.display = "block";
      e.currentTarget.textContent = "Hide it";
    }
  }
}
