window.addEventListener('load', () => {
    const baseUrl = 'https://fisher-game.firebaseio.com';
    const loadBtn = document.querySelector('.load');
    const addBtn = document.querySelector('.add');
    const catchesDiv = document.querySelector('#catches');

    loadBtn.addEventListener('click', loadCatches);
    addBtn.addEventListener('click', addNewCatch);


    async function loadCatches(){
        await fetch(`${baseUrl}/catches.json`)
        .then(res => res.json())
        .then(data => Object.keys(data).forEach(key => {
            let element = `<div class="catch" data-id="${key}">
                <label>Angler</label>
                <input type="text" class="angler" value="${data[key].angler}" />
                <hr>
                <label>Weight</label>      
                <input type="number" class="weight" value="${data[key].weight}" />
                <hr>
                <label>Species</label>
                <input type="text" class="species" value="${data[key].species}" />
                <hr>
                <label>Location</label>
                <input type="text" class="location" value="${data[key].location}" />
                <hr>
                <label>Bait</label>
                <input type="text" class="bait" value="${data[key].bait}" />
                <hr>
                <label>Capture Time</label>
                <input type="number" class="captureTime" value="${data[key].captureTime}" />
                <hr>
                <button class="update">Update</button>
                <button class="delete">Delete</button>
            </div>`

            catchesDiv.innerHTML += element;
        }))
    }

    async function addNewCatch(){
        let inputElements = document.getElementsByTagName('input');
        let body = {};
        [...inputElements].forEach(element => {
            body[element.className] = element.value;
            element.value = '';
        });

        await fetch(`${baseUrl}/catches.json`,{
            method: 'Post',
            body: JSON.stringify(body)
        }).json();
    }


})