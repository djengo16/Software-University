function solution(){
    let store = {
     protein:0,
     carbohydrate: 0,
     fat: 0,
     flavour: 0
    }

    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
            order: ['carbohydrate','flavour']
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
            order: ['carbohydrate','flavour']
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
            order:['carbohydrate','fat','flavour']
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
            order: ['protein','fat','flavour']
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
            order: ['protein','carbohydrate','fat','flavour']
        }
    };
    
    let operations =  {
        restock,
        prepare,
        report
    }

    function restock(microelement,qty){
        store[microelement] += qty;

        return 'Success';
    }

    function prepare(meal,qty){
        let required = Object.assign({},recipes[meal]);
        required.order.forEach(key => required[key] *= qty);

        for (const element of required.order) {
            if(store[element] < required[element]){
                return `Error: not enough ${element} in stock`
            }
        }

        required.order.forEach(key => store[key] -= required[key]);

        return 'Success';
    }

    function report(){
        return `protein=${store.protein} carbohydrate=${store.carbohydrate} fat=${store.fat} flavour=${store.flavour}`
    }

    function manager(command){
        const tokens = command.split(' ');
        return operations[tokens[0]](tokens[1],Number(tokens[2]));
    }
    return manager;
}

let manager = solution();
console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));