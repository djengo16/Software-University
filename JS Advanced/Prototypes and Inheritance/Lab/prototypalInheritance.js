let cat = {
    name: 'Sindy',
    age: 2,
    eat(){
       return `${this.name} is eating!`
    }
}

let cat2 = {
    name: 'Dixie'
};


Object.setPrototypeOf(cat2, cat);
let cat3 = Object.assign(cat2);
console.log(cat2.age);
cat2.age = 5;
console.log(cat2.eat());
console.log(cat.age);
console.log(cat2.age);