function createArticle() {
  let titleInput = document.getElementById("createTitle");
  let contentInput = document.getElementById("createContent");
  if (titleInput.value != "" && contentInput.value != "") {
    let titleElement = document.createElement("h3");
    titleElement.innerHTML = titleInput.value;
    let contentElement = document.createElement("p");
    contentElement.innerHTML = contentInput.value;

    let articleElement = document.createElement("article");
    articleElement.appendChild(titleElement);
    articleElement.appendChild(contentElement);

    let documentArticle = document.getElementById("articles");
    documentArticle.appendChild(articleElement);

    titleInput.value = "";
    contentInput.value = "";
  }
}
