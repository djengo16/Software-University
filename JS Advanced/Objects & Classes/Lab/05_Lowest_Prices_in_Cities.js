function solve(input) {

    let products = [];

    for (let i = 0; i < input.length; i++) {
        let extracted = input[i].split(' | ');

        let town = extracted[0];
        let product = extracted[1];
        let price = Number(extracted[2]);
        let exists = false;
        let current = {
            town,
            product,
            price,
        }
        products.forEach(element => {
            if(element['product'] === product){
                if(price < element['price']){
                    element['product'] = product;
                    element['town'] = town;
                    element['price'] = price;              
                }
                exists = true;
            }
        });
        if(!exists){
            products.push(current);
        }
    }
    products.forEach(x => {
        console.log(`${x['product']} -> ${x['price']} (${x['town']})`);
    })
}

solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000']);