window.addEventListener("load", () => {
  const elements = {
    btnLoadTowns: () => document.querySelector("#btnLoadTowns"),
    root: () => document.querySelector("#root"),
    townsInput: () => document.querySelector("#towns"),
  };

  elements.btnLoadTowns().addEventListener("click", (e) => {
    e.preventDefault();
    fetch("./template.hbs")
      .then((res) => res.text())
      .then((templateSource) => {
        elements.root().innerHTML = "";

        let towns = elements.townsInput().value.split(", ");

        let townsTemplate = Handlebars.compile(templateSource);
        let townsHTML = townsTemplate({ towns });

        elements.root().innerHTML += townsHTML;
      });
  });
});
