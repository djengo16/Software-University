let person = {
    firstName: 'Ivan',
    age: 23,
    grades: [5,4,3,2],
    school: {
        name: 'SOU-51',
        address: 'Address',
        faculty: {
            name: 'Math',
            students: 500,
        }
    },

    reportGradesArrow: () => {
        //contains the global scope and the context can't access grades
        console.log(this.grades.join(', '));
    },
       //gets the context of person
    reportGradesFuncExpression: function (){
        console.log(this.grades.join(', '));
    },

    toString: function(){
        return `My name is ${this.firstName} and study at ${this.school.name}, ${this.school.faculty.name} faculty.`
    }
}
person.reportGradesFuncExpression();
// person.reportGradesArrow();
console.log(person.toString());

//Object destructoring

let {firstName : name, age} = person;
console.log(name + ' ' + age);

//Aggregation
let students = [
    {name: "Pesho", score: 3},
    {name: "Gosho", score: 2},
    {name: "Pesho", score: 3},
    {name: "Gosho", score: 5},
    {name: "Pesho", score: 4},
]

function aggregate(acc, student){
        let curr = acc.find(x => x.name === student.name);

        if(curr){
            curr.score += student.score;
        }else{
        acc.push(student);
        }
    return acc;
}

let result = students.reduce(aggregate,[]);
console.log(result);

//Concat
let props = [
    {age:22},
    {name:'Ivan', heigth: 190},
    {eyeColor: 'blue'}
]
console.log(...props);
let person = props.reduce((acc, x) => ({...acc, ...x}),{});