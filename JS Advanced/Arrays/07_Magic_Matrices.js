function solve(arr) {
    let sum = arr[0].reduce((a, x) => { return a + x }, 0);
    let isMagic = true;
    arr.forEach((current, rowindex) => {
        let currentRowSum = current.reduce((a, x) => { return a + x }, 0);
        let currentColSum = arr.reduce((a, x) => { return a + x[rowindex]; }, 0)
        if (currentRowSum != sum || currentColSum != sum) {
            isMagic = false;
        }
    });
    console.log(isMagic);
}

solve([[1, 0, 0],
[0, 1, 0],
[0, 1, 0]]
);
