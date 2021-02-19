// class Person {
//     canFly = false;
//   constructor(name) {
//     this.name = name;
//   }

//   speak() {
//     console.log(`Hello! My name is ${this.name}.`);
//   }
// }

// class Programmer extends Person{
//     constructor(name){
//         super(name)
//     }
//     static quote(){
//       console.log('Eat -> code -> sleep <-> repeat.')
//     }

//     coding(){
//         console.log(`Hello world!My name is ${this.name}.`);
//     }
// }

// let firstPerson = new Person("Adam");
// firstPerson.speak();

// let programmer = new Programmer('Ivan');

// Programmer.quote();

//NEW 

function Person(firstName, lastName){
  this.firstName = firstName;
  this.lastName = lastName;
}

Person.prototype.speak = function (){
  console.log(`Hello my name is ${this.firstName} ${this.lastName}.`);
}

function createNew(constructor, ...args){
  //Create object
  let obj = {};

  //set prototypes
  Object.setPrototypeOf(obj, constructor.prototype);

  //Call constructor with context
  constructor.apply(obj, args);

  //return obj
  return obj;
}

let person = createNew(Person, 'George','Ivanov');
person.speak();