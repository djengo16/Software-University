function calculate(operation, firstValue, secondValue){
    let result = operation(firstValue, secondValue);
    console.log(result);
}

let divide = (a,b) => a / b;
let multiple = (a, b) => a * b;

calculate(divide, 8, 4);
calculate(multiple, 5, 4);