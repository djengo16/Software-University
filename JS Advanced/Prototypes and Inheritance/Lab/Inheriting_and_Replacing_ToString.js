function toStringExtension() {
    class Person {
        constructor(name, email){
            this.name = name;
            this.email = email;
        }

        toString = function(){
            return `Person (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person{
        constructor(name, email, subject){
            super(name,email)
            this.subject = subject;
        }

        toString = function(){
            return `Teacher (name: ${this.name}, email: ${this.email}, subject: ${this.subject})`;
        }
    }

    class Student extends Person{
        constructor(name, email, course){
            super(name, email)
            this.course = course;
        }

        toString = function(){
            return `Student (name: ${this.name}, email: ${this.email}, course: ${this.course})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}
let classes = toStringExtension();
let Person = classes.Person;
let Teacher = classes.Teacher;
let Student = classes.Student;

let t = new Teacher("Gosho",'gosh@gosh.com',"Graphics");
expect(t.toString()).to.equal('Teacher (name: Gosho, email: gosh@gosh.com, subject: Graphics)');