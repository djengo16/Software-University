function solve() {
  document.getElementById("searchBtn").addEventListener("click", search);

  function search(e) {
    let keywords = document.getElementById("searchField").value;
    let tableBody = document.getElementsByTagName("tbody")[0];

    if (keywords.trim() != "") {
      Array.from(tableBody.children).forEach((row) => {
        if (row.textContent.includes(keywords)) {
          row.classList.add("select");
        } else {
          row.classList.remove("select");
        }
      });
    }
  }
}
