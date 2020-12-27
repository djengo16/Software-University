function solve(input){
let obj = {};
for(let i = 0;i < input.length;i++){
    let extracted = input[i].split(' <-> ');
    let city = extracted[0];
    let population = JSON.parse(extracted[1]);
    
    if(city in obj){
        obj[city] += population;
    }
    else {
        obj[city] = population;
    }
}
for (const [key, value] of Object.entries(obj)) {
    console.log(`${key} : ${value}`);
  }
}


solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);
