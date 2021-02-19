function extendClass(classToExtend) {
    classToExtend.prototype.species = 'Human';
   classToExtend.prototype.toSpeciesString =  function () {
      return `I am a ${this.species}. ${this.toString()}`;
    }
};

class Person {
  constructor(name, email) {
    this.name = name;
    this.email = email;
  }
  toString() {
    let className = this.constructor.name;
    return `${className} (name: ${this.name}, email: ${this.email})`;
  }
}

class Teacher extends Person {
  constructor(name, email, subject) {
    super(name, email);
    this.subject = subject;
  }
  toString() {
    let baseStr = super.toString().slice(0, -1);
    return baseStr + `, subject: ${this.subject})`;
  }
}

class Student extends Person {
  constructor(name, email, course) {
    super(name, email);
    this.course = course;
  }
  toString() {
    let baseStr = super.toString().slice(0, -1);
    return baseStr + `, course: ${this.course})`;
  }
}
extendClass(Person);
let s = new Student("Gosho", "gesha@hit.bg", 1);
//console.log(s.species);
console.log(s.toSpeciesString());
