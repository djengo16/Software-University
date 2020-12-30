function solve(input){
    let html = '<table>\n'
    for (const object of input) {
        let parsed = JSON.parse(object);
        html +='\t<tr>\n';
        html += Object.values(parsed).map(x => `\t\t<td>${x}</td>\n`).join('');
        html += '\t</tr>\n'
    }
    html += '</table>'

    console.log(html);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);