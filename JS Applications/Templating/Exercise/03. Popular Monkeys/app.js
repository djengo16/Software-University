import monkeys from './monkeys.js'

const elements = {
    monkeysDiv: () => document.querySelectorAll('.monkeys')[0]
}

fetch('./monkeys.hbs')
.then(r => r.text())
.then(source => {
const template = Handlebars.compile(source);

const resultHTML = template({monkeys});

elements.monkeysDiv().innerHTML = '';
elements.monkeysDiv().innerHTML += resultHTML;
elements.monkeysDiv().addEventListener('click',(e) =>{
    if (e.target.innerText == 'INFO') {
        const detailsDiv = e.target.nextElementSibling;
        if (detailsDiv.style.display != "block") {
          detailsDiv.style.display = "block";
        } else {
          detailsDiv.style.display = "none";
        }
      }
})
})


