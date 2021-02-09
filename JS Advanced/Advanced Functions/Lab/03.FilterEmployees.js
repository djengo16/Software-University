function solve(employees,criteria){
    employees = JSON.parse(employees);
    let splittedCriteria = criteria.split('-');

    if(splittedCriteria.length !== 1){
      let property = splittedCriteria[0];
      let match = splittedCriteria[1];
        let filterFunc = (object) => {
            return object[property] === match;
        }
        employees = employees.filter(filterFunc);
    }
    let position = 0;
    let output = employees
    .map((x) => `${position++}. ${x['first_name']} ${x['last_name']} - ${x['email']}`);
    
    output.forEach(x => console.log(x));
}

solve(`[{
  "id": "1",
  "first_name": "Ardine",
  "last_name": "Bassam",
  "email": "abassam0@cnn.com",
  "gender": "Female"
}, {
  "id": "2",
  "first_name": "Kizzee",
  "last_name": "Jost",
  "email": "kjost1@forbes.com",
  "gender": "Female"
},  
{
  "id": "3",
  "first_name": "Evanne",
  "last_name": "Maldin",
  "email": "emaldin2@hostgator.com",
  "gender": "Male"
}]`, 
'all'

);
