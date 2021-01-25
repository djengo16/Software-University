function validate() {
  let inputField = document.getElementById("email");
  const mailFormat = /^[a-z]+@[a-z]+[.][a-z]+$/g;
  inputField.addEventListener("change", validate);

  function validate(e) {
    let value = e.currentTarget.value;

    if (!value.match(mailFormat)) {
      e.currentTarget.className = "error";
    } else {
      e.currentTarget.removeAttribute("class");
    }
  }
}
