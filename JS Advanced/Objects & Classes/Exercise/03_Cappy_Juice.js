function solve(input){
let juices = {};
let bottled = {};
for (const current of input) {
    let [fruit,quantity] = current.split(' => ')
    if(fruit in juices){
        juices[fruit] += Number(quantity)
    } else{
        juices[fruit] = Number(quantity)
    }

    if(juices[fruit] >=1000){
        if(fruit in bottled){
            bottled[fruit] += Number(quantity)
        } else{
            bottled[fruit] = juices[fruit]
        }
    }
}

Object.keys(bottled).forEach(key => {
    console.log(`${key} => ${Math.floor(bottled[key] / 1000)}`)
});
}
solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);