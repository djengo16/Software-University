import genEl from "./dom_generator.js";

window.addEventListener("load", () => {
  const baseUrl = "https://fisher-game.firebaseio.com";
  const loadBtn = document.querySelector(".load");
  const addBtn = document.querySelector(".add");
  const catchesDiv = document.querySelector("#catches");

  loadBtn.addEventListener("click", loadCatches);
  addBtn.addEventListener("click", addNewCatch);

  async function loadCatches() {
    catchesDiv.innerHTML = "";
    await fetch(`${baseUrl}/catches.json`)
      .then((res) => res.json())
      .then((data) =>
        Object.keys(data).forEach((id) => {
          let updateBtn = genEl("button", "Update", { className: "updata" });
          let delBtn = genEl("button", "Delete", { className: "delete" });

          let catchDiv = genEl(
            "div",
            [
              genEl("label", "Angler"),
              genEl("input", "", {
                type: "text",
                className: "angler",
                value: data[id].angler,
              }),
              document.createElement("hr"),
              genEl("label", "Weight"),
              genEl("input", "", {
                type: "text",
                className: "weight",
                value: data[id].weight,
              }),
              document.createElement("hr"),
              genEl("label", "Species"),
              genEl("input", "", {
                type: "text",
                className: "species",
                value: data[id].species,
              }),
              document.createElement("hr"),
              genEl("label", "Location"),
              genEl("input", "", {
                type: "text",
                className: "location",
                value: data[id].location,
              }),
              document.createElement("hr"),
              genEl("label", "Bait"),
              genEl("input", "", {
                type: "text",
                className: "bait",
                value: data[id].bait,
              }),
              document.createElement("hr"),
              genEl("label", "Capture Time"),
              genEl("input", "", {
                type: "text",
                className: "captureTime",
                value: data[id].captureTime,
              }),
              document.createElement("hr"),
              updateBtn,
              delBtn,
            ],
            { className: "catch", id: id }
          );

          delBtn.addEventListener("click", function () {
            fetch(`${baseUrl}/catches/${id}.json`, {
              method: "DELETE",
            })
              .then(() => {
                delBtn.textContent = "DELETING...";
                delBtn.disabled = true;
                setInterval(() => {
                  delBtn.textContent = "DELETE";
                  delBtn.disabled = false;
                }, 1500);

                catchDiv.remove();
              })
              .catch((err) => {
                delBtn.textContent = err.value;
              });
          });

          updateBtn.addEventListener("click", function () {
            let inputElements = document.querySelectorAll(`#${id} input`);
            let body = {};
            [...inputElements].forEach((element) => {
              body[element.className] = element.value;
            });

            fetch(`${baseUrl}/catches/${id}.json`, {
              method: "PUT",
              body: JSON.stringify(body),
            })
              .then(() => {
                updateBtn.textContent = "UPDATING...";
                updateBtn.disabled = true;
                setInterval(() => {
                  updateBtn.textContent = "UPDATE";
                  updateBtn.disabled = false;
                }, 1500);
              })
              .catch((err) => {
                delBtn.textContent = err.value;
              });
          });

          catchesDiv.appendChild(catchDiv);
        })
      );
  }

  async function addNewCatch() {
    let inputElements = document.querySelectorAll("#addForm input");
    let body = {};
    [...inputElements].forEach((element) => {
      body[element.className] = element.value;
      element.value = "";
    });

    await fetch(`${baseUrl}/catches.json`, {
      method: "POST",
      body: JSON.stringify(body),
    });
  }
});
