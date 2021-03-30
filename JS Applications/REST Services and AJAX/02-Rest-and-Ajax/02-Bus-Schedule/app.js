function solve() {
  const departBtn = document.querySelector("#depart");
  const arriveBtn = document.querySelector("#arrive");
  const infoDiv = document.querySelector("#info");
  let currentId = "depot";
  let currStopName;
  let url = 'https://judgetests.firebaseio.com/schedule/ ';

  function depart() {
    fetch(url + `${currentId}.json`)
      .then((res) => res.json())
      .then((data) => {
       // if (validateData(data)) {
          currStopName = data.name;
          currentId = data.next;
          infoDiv.textContent = `Next stop ${currStopName}`;
          switchBtn();
       // }
      }).catch(err => {
        infoDiv.textContent = 'Error';
      });
  }

  function switchBtn(){
    departBtn.disabled = !departBtn.disabled;
    arriveBtn.disabled = !departBtn.disabled;;
  }

  function validateData(data) {
    if (data.name == "" || data.next == "" || data == null) {
      departBtn.disabled = true;
      arriveBtn.disabled = true;
      infoDiv = 'Error';
      return false;
    }
    return true;
  }

  function arrive() {
    switchBtn();
    infoDiv.textContent = `Arriving at ${currStopName}`;
  }

  return {
    depart,
    arrive,
  };
}
let result = solve();