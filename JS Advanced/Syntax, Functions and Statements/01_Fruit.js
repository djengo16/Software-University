function calculate(fruit, weightInGrams, priceForKg){
let kilograms = weightInGrams / 1000;
let totalPrice = kilograms * priceForKg;

console.log(`I need $${totalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`);
}

calculate('apple', 1563, 2.35)
