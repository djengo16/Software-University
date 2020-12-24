function solve(arr) {
    let resultArray = [];
    for (let index = 0; index < arr.length; index++) {
        arr[index] === 'add'
            ? resultArray.push(index + 1)
            : resultArray.pop()
    }
    if (resultArray.length == 0) {
        console.log('Empty');
    }
    else {
        resultArray.forEach(x => console.log(x));
    }
}

solve(['remove', 
'remove', 
'remove']
);