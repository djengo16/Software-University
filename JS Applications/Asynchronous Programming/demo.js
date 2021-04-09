// let promise = new Promise((resolve, reject) => {
//     console.log('Prepare wedding!!!');

//     setTimeout(function(){
//         resolve('Just Married!')
//     }, 2000);

//     console.log('test');
// })

// promise.then(function(res){
//     console.log(res)
// })

fetch(`https://swapi.dev/api/people/1`)
.then(res => console.log(res));