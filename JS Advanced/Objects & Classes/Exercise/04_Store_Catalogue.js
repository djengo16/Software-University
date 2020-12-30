function solve(input) {
    let catalogue = [];
    input.forEach(line => {
        let [product, price] = line.split(' : ');
        catalogue.push({ product, price });
    });

    catalogue.sort((a, b) => a.product.localeCompare(b.product));

    let group = '';
    catalogue.forEach(current => {
        let productName = current['product'];
        let productPrice = current['price'];
        let currentGroup = productName[0];

        if (group !== currentGroup) {
            group = currentGroup;
            console.log(group);
        }
        console.log(`  ${productName}: ${productPrice}`)
    })
}

solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);