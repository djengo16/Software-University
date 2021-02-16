function solve() {
  let content = document.getElementById("content");
  let id = 0;

  function report(author, description, reproducible, severity){
    let innerHtml = `<div id="report_${id++}" class="report">
    <div class="body">
      <p>${description}</p>
    </div>
    <div class="title">
      <span class="author">Submitted by: ${author}</span>
      <span class="status">Open | ${severity}</span>
    </div>
  </div>
  `;
   content.innerHTML +=innerHtml;
  }

  function setStatus(id, newStatus){

  }

  function remove(id) {

  }

  function sort(method){

  }

  function output(selector){

  }

  return {
      report,
      setStatus,
      remove,
      sort,
      output
  }
}

let manipulation = solve();
manipulation.report('Ivan','DESCRIPTION!',false,16);
console.log();