function solve(arr){
    let n = parseInt(arr.pop());

    arr.forEach((element, index) =>{
        if(index % n == 0){
            console.log(element)
        }
    })
}

solve(['dsa',
'asd', 
'test', 
'tset', 
'2']
);