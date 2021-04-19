import genEl from "./dom-generator.js";

const baseUrl = "https://students-ea182-default-rtdb.firebaseio.com";
const elements = {
  errorDiv: () => document.querySelector("#error"),
  firstNameInput: () => document.querySelector("#firstName"),
  lastNameInput: () => document.querySelector("#lastName"),
  facultyNumInput: () => document.querySelector("#facultyNum"),
  gradeInput: () => document.querySelector("#grade"),
  sumbitBtn: () => document.querySelector("#submit"),
  tbody: () => document.querySelector("tbody"),
};

window.addEventListener("load", () => {
  listStudents();
});

async function listStudents() {
  elements.tbody().innerHTML = '';
  fetch(`${baseUrl}/students/.json`)
    .then((res) => res.json())
    .then((data) => {
      Object.entries(data)
        .sort((x, y) => {
          return x[1]["ID"] - y[1]["ID"];
        })
        .forEach(([key, value]) => {
          elements
            .tbody()
            .appendChild(
              genEl("tr", [
                genEl("td", value["id"]),
                genEl("td", value["firstName"]),
                genEl("td", value["lastName"]),
                genEl("td", value["facultyNum"]),
                genEl("td", value["grade"]),
              ])
            );
        });
    })
    .catch(handleError);
}

elements.sumbitBtn().addEventListener("click", async (e) => {
  e.preventDefault();
  fetch(baseUrl + "/students.json")
    .then((res) => res.json())
    .then((data) => data != undefined ? Object.keys(data).length : 0)
    .then((length) => {
      const firstName = elements.firstNameInput().value;
      const lastName = elements.lastNameInput().value;
      const facultyNum = elements.facultyNumInput().value;
      const gradeInput = elements.gradeInput().value;

      if (
        firstName.trim() != "" &&
        lastName.trim() != "" &&
        facultyNum.trim() != "" &&
        gradeInput.trim() != ""
      ) {
        try {
          createStudent({
            id: length + 1,
            firstName,
            lastName,
            facultyNum,
            grade: gradeInput,
          });
          listStudents();
        } catch (err) {
          handleError(err);
        }
      } else {
        handleError(`All fields are required.`);
      }
    })
    .catch(handleError);
});

async function createStudent(obj) {
  fetch(`${baseUrl}/students/.json`, {
    method: "POST",
    body: JSON.stringify(obj),
  });
}

function handleError(err) {
  const errDiv = elements.errorDiv();
  errDiv.textContent = err;
  errDiv.setAttribute("style", "display: block");
  setInterval((err) => {
    errDiv.textContent = "";
    errDiv.setAttribute("style", "display: none");
  }, 3000);
}
