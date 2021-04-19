import genEl from "../02.Students/dom-generator.js";

const elements = {
  loadBtn: () => document.getElementById("loadBooks"),
  submitBtn: () => document.getElementById("submit"),
  existingBooksEl: () => document.querySelector("#existing-books > tbody"),
  titleInput: () => document.querySelector("#create-title"),
  isbnInput: () => document.querySelector("#create-isbn"),
  authorInput: () => document.querySelector("#create-author"),
  messageDiv: () => document.querySelector("#message"),
  createForm: () => document.querySelector("#create-form"),
  editBtn: () => document.querySelector("#edit"),
};
const baseUrl = "https://books-9b100-default-rtdb.firebaseio.com/books";

elements.loadBtn().addEventListener("click", renderBooks);
elements.submitBtn().addEventListener("click", createBook);

async function renderBooks() {
  await fetch(baseUrl + ".json")
    .then((response) => response.json())
    .then((data) => {
      elements.existingBooksEl().innerHTML = "";

      Object.entries(data).forEach(([id, value]) => {
        let editBtn = genEl("button", "Edit");
        let delBtn = genEl("button", "Delete");
        editBtn.setAttribute("data-id", id);
        delBtn.setAttribute("data-id", id);

        const bookRow = genEl("tr", [
          genEl("td", value["title"]),
          genEl("td", value["author"]),
          genEl("td", value["isbn"]),
          genEl("td", [editBtn, delBtn]),
        ]);

        delBtn.addEventListener("click", async () => {
          try {
            await deleteBook(id);
            bookRow.remove();
          } catch (err) {
            showMessage(err);
          }
        });
        editBtn.addEventListener("click", editEntry);

        elements.existingBooksEl().appendChild(bookRow);
      });
    });
}

async function editEntry(e) {
  let id = this.dataset.id;
  let obj = await getBook(id);
  const editBtn = elements.editBtn();
  const submitBtn = elements.submitBtn();
  submitBtn.setAttribute("style", "display: none;");
  editBtn.setAttribute("style", "display: block;");

  let authorInput = elements.authorInput();
  let titleInput = elements.titleInput();
  let isbnInput = elements.isbnInput();

  authorInput.value = obj["author"];
  titleInput.value = obj["title"];
  isbnInput.value = obj["isbn"];

  editBtn.addEventListener("click", async (e) => {
    e.preventDefault();
    if (
      authorInput.value.trim() !== "" &&
      titleInput.value.trim() !== "" &&
      isbnInput.value.trim() != ""
    ) {
      try {
        await editBook(id ,{
          author: authorInput.value,
          isbn: isbnInput.value,
          title: titleInput.value,
        });
        await renderBooks();

        submitBtn.setAttribute("style", "display: block;");
        editBtn.setAttribute("style", "display: none;");

        elements.createForm().reset();
      } catch (e) {
        showMessage(e);
      }
    } else {
      showMessage({ message: "All fields are required!" });
    }
  });
}

async function createBook(e) {
  e.preventDefault();
  let author = elements.authorInput().value;
  let title = elements.titleInput().value;
  let isbn = elements.isbnInput().value;

  if (author.trim() !== "" && title.trim !== "" && isbn.trim() != "") {
    try {
      await addBook({ author, isbn, title });
      await renderBooks();
      elements.createForm().reset()
    } catch (e) {
      showMessage(e);
    }
  } else {
    showMessage({ message: "All fields are required!" });
  }
}

async function addBook(obj) {
  await fetch(baseUrl + ".json", {
    method: "POST",
    body: JSON.stringify(obj),
  });
}

async function editBook(id, obj) {
  await fetch(`${baseUrl}/${id}.json`, {
    method: "PATCH",
    body: JSON.stringify(obj),
  });
}

async function deleteBook(id) {
  await fetch(`${baseUrl}/${id}.json`, {
    method: "DELETE",
  });
}

async function getBook(id) {
  return await fetch(`${baseUrl}/${id}.json`).then((response) =>
    response.json()
  );
}

function showMessage(e) {
  let message = elements.messageDiv();
  message.setAttribute('style','display: block;')
  message.textContent = e.message;
  setTimeout(() => {
    message.setAttribute('style','display: none;')
  }, 2000);
}