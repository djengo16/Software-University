function solve(input){
let cars = {};
input.forEach(element => {
    let [manufacturer, model, producedCars] = element.split(' | ');
    if(!cars[manufacturer]){
        cars[manufacturer] = [];
    }
    if(cars[manufacturer].some(x => x['model'] === model)){
        cars[manufacturer].forEach(x => {
            if(x['model'] === model){
                x['producedCars'] += Number(producedCars);
            }
        })
    }else{
    producedCars = Number(producedCars);
    cars[manufacturer].push({model, producedCars});
    }
});
Object.keys(cars).forEach(car =>{
    console.log(car);
    cars[car].forEach(current => {
        console.log(`###${current['model']} -> ${current['producedCars']}`);
    })
})
}

solve(['Audi | Q7 | 1000',
'Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);