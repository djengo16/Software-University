function deleteByEmail() {
  let inputEmail = document.getElementsByName("email")[0];
  let rows = document.getElementsByTagName("tr");
  let message = "Not found.";
  Array.from(rows).forEach((row) => {
    if (row.children[1].textContent === inputEmail.value) {
      row.remove();
      message = "Deleted.";
    }
  });
  document.getElementById("result").textContent = message;
  inputEmail.value = "";
}
