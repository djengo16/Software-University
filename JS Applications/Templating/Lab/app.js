import contactsView from './template.js'
import contacts from './contancts.js'

const contactsDiv = document.querySelector("#contacts");

const contactTemplate = Handlebars.compile(contactsView);

const contactsHTML = contactTemplate({contacts});
console.log(contactsHTML);
contactsDiv.innerHTML += contactsHTML;

contactsDiv.addEventListener('click',(e) => {
    if(e.target.classList.contains('detailsBtn')){
        let detailsDiv = e.target.nextElementSibling;
        if(detailsDiv.style.display != 'block'){
            detailsDiv.style.display = 'block';
        }else{
            detailsDiv.style.display = 'none';
        }
    }
})