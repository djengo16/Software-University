const elemets = {
  catsSection: () => document.querySelector("#allCats"),
};

Promise.all([getTemplate("./list.hbs"), getTemplate("./catTemplate.hbs")])
  .then(([globalTemplate, partialTemplate]) => {
    elemets.catsSection().innerHTML += "";

    const template = Handlebars.compile(globalTemplate);
    Handlebars.registerPartial("catTemplate", partialTemplate);
    const resultHTML = template({ cats });

    elemets.catsSection().innerHTML += resultHTML;

    addEventToBtns();
  })
  .catch((err) => {
    console.log(err);
  });

function addEventToBtns() {
  elemets.catsSection().addEventListener("click", (e) => {
    if (e.target.classList.contains("showBtn")) {
      const detailsDiv = e.target.nextElementSibling;
      if (detailsDiv.style.display != "block") {
        detailsDiv.style.display = "block";
      } else {
        detailsDiv.style.display = "none";
      }
    }
  });
}

function getTemplate(location) {
  return fetch(location)
    .then((r) => r.text())
    .catch((e) => console.err(e));
}
