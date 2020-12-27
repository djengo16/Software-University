function solve(input){
let parsed = JSON.parse(input);
console.log(parsed);

let html = '<table>';
let first = parsed[0];

html += `<tr>${Object.keys(first).map(x => `<th>${x}</th>`).join('')}</tr>`;
parsed.forEach(x => {
    html += '<tr>';
    html += Object.values(x).map(current => `<td>${current}</td>`).join('');
    html += '</tr>';
})
html += '</table>';
 console.log(html);
}



solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);