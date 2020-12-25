function solve(inputArr) {
    let matrix = [];
    inputArr.forEach(x => {
        let currentRow = x.split(' ');
        matrix.push(currentRow.map(Number));
    });

    let firstDiagonalSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        firstDiagonalSum += matrix[i][i];
    }
    let secondDiagonalSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        secondDiagonalSum += matrix[i][matrix.length - i - 1]
    }

    if (firstDiagonalSum != secondDiagonalSum) {
        print(matrix);
        return;
    }else {
        for (let i = 0; i < matrix.length; i++) {
            for(let y = 0;y < matrix.length; y ++){
                if(i != y && i != matrix.length - y - 1)
                matrix[i][y] = firstDiagonalSum;
            }
        }
        print(matrix);
    }

    function print(matrix) {
        matrix.forEach(x => {
            console.log(x.join(' '));
        })
    }

}

solve( 
['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']    
);