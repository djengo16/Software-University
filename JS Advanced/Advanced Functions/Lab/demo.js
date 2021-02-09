//First class function
let add = (a,b) => a+b;
let substract = (a,b) => a-b;

function operate(operation,a,b){
    return operation(a,b);
}

console.log(operate(add,10,15));
console.log('test');

//Higher order functions
const sayHello = function(){
    return function(){
        console.log('Hello!');
    }
}

const myFunc = sayHello();
myFunc();

//Predicates
let isValid = function(name){
    if(name != ''){
        return true;
    }
    return false;
}

console.log(isValid('Ivan'));

//Built-in higher order funcs
let names = ['Ivan Petrov','Georgi Stefanov','Petq Georgieva',''];
let filteredNames = names.filter(isValid);
console.log(filteredNames);

//Pure functions
let sqrt = n => n * n;
console.log(sqrt(5));
//Impure funcs
let impure = (name) => name + ' ' + Date();
console.log(impure('Ivan'));

//Referential transparency
function sub(a,b) { return a - b};
function mult(a,b) { return a * b};
let x = sub(2, mult(3,3));
console.log(x);

//Currying
let sum3 = (a) => {
    return (b) => {
        return (c) => {
            return a+b+c;
        }
    }
}
let sum3b = sum3(1);
let sum3c = sum3b(2);
let result = sum3c(3);
console.log(result);

console.log(sum3(1)(2)(3));

//Partial application
let pow = (y,x) => x ** y;
let sqr = pow.bind(null,2);
console.log(sqr(2));

//Immediately invoked func expression
let value = (() => 2 + 2 + 2)();
console.log(value);

//Closure
let outerFunc = function(){
    let name = 'Test';
    //keeps the needed(still used) variables from closure
    return function innerFunc(){
        console.log(name);
    }
}

let returnerInnerFunc = outerFunc();
console.log(returnerInnerFunc());