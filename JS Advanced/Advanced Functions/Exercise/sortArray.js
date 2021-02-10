function solve(arr,sortType){
    let doSort = {
        asc: (arr) => arr.sort((a,b) => a-b),
        desc: (arr) => arr.sort((a,b) => b -a)
    }

    return doSort[sortType](arr);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));