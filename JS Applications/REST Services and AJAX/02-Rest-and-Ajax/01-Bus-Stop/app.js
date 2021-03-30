function getInfo() {
  const stopName = document.querySelector("#stopName");
  const ul = document.querySelector("#buses");
  const stopId = document.querySelector("#stopId").value;
  const url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
  const validIds = [1287, 1308, 1327, 2334];
  ul.innerHTML = '';

  if (validIds.includes(Number.parseInt(stopId))) {
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        stopName.textContent = data.name;
        Object.entries(data.buses)
        .forEach(([id,time]) => {
            ul.innerHTML += `<li>Bus ${id} arrives in ${time}</li>`;
        })
      });
  } else {
    stopName.textContent = 'Error';
  }
}
