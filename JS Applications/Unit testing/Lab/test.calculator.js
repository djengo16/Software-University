const calc =  require('./calculator')

let result = calc.sum(5,6);

if(result === 11){
    console.log('Test passed!');
}else{
    console.log('Test not passed!');
}