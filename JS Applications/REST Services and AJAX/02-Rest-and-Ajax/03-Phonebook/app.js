function attachEvents() {
  const loadBtn = document.querySelector("#btnLoad");
  const createBtn = document.querySelector("#btnCreate");
  const url = "https://phonebook-nakov.firebaseio.com/phonebook";
  const ul = document.querySelector("#phonebook");

  createBtn.addEventListener("click", createEntity);
  loadBtn.addEventListener("click", loadEntities);

  function loadEntities() {
    ul.innerHTML = "";
    fetch(url + ".json")
      .then((response) => response.json())
      .then((data) => {
        Object.entries(data).forEach((entry) => {
          let li = document.createElement("li");

          let delBtn = document.createElement("button");
          delBtn.textContent = "Delete";
          delBtn.id = entry[0];
          delBtn.addEventListener("click", deleteEntity);

          li.textContent = `${entry[1].person}: ${entry[1].phone}`;
          li.appendChild(delBtn);

          ul.appendChild(li);
        });
      });
  }

  function createEntity() {
    let personInput = document.querySelector("#person");
    let phoneInput = document.querySelector("#phone");
    let obj = { person: personInput.value, phone: phoneInput.value };
    personInput.value = '';
    phoneInput.value = '';

    let json = JSON.stringify(obj);

    fetch(url + ".json", {
      method: "POST",
      body: json,
    }).then((response) => loadEntities());
  }

  function deleteEntity(e) {
    let id = e.currentTarget.id;
    fetch(url + `/${id}.json`, {
      method: "DELETE",
    }).then((res) => {
      loadEntities();
    });
  }
}

attachEvents();
