function solve() {
  let table = document.querySelector("tbody");
  let rows = document.querySelectorAll('tr');

  table.addEventListener("click", (e) => {

    if (e.target.tagName === "TD") {
      let row = e.target.parentNode;
      if(row.style.backgroundColor !== ''){
        row.style.backgroundColor = ""; 
      }else{
        
        [...rows].forEach(r => r.style.backgroundColor = '');
        row.style.backgroundColor = "#413f5e";
      }
    }
    });
}