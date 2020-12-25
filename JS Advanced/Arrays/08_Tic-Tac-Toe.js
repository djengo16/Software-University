function play(moves) {
    function isThereFreeSpace(field){
        return field.some(row => row.includes(false));
    }

    let field = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    let counter = 0;
    let mark = '';
    while (isThereFreeSpace(field)) {
        let currentMove = moves.shift().split(' ');
        let row = parseInt(currentMove[0]);
        let col = parseInt(currentMove[1]);

        if (counter % 2 == 0) {
            mark = 'X';
        } else {
            mark = 'O';
        }

        while (!doMove(row, col, field, mark)) {
            currentMove = moves.shift().split(' ');
            row = parseInt(currentMove[0]);
            col = parseInt(currentMove[1]);
        }

        if (checkIfWin(field, mark)) {
            console.log(`Player ${mark} wins!`)
            printField(field);
            return; // end of the game
        }

        counter++;
    }
    console.log('The game ended! Nobody wins :(');
    printField(field);
    function doMove(row, col, field, mark) {
        if (field[row][col] === false) {
            field[row][col] = mark;
            return true;
        } else {
            console.log('This place is already taken. Please choose another!');
            return false;
        }
    }

    function printField(field){
        field.forEach(x => {
            console.log(x.join('\t'));
        })
    }

    function checkIfWin(field, mark) {
        if (field[0][0] === mark && field[0][1] === mark && field[0][2] === mark) {
            return true;
        } else if (field[1][0] === mark && field[1][1] === mark && field[1][2] === mark) {
            return true;
        } else if (field[2][0] === mark && field[2][1] === mark && field[2][2] === mark) {
            return true;
        } else if (field[0][0] === mark && field[1][0] === mark && field[2][0] === mark) {
            return true;
        } else if (field[0][1] === mark && field[1][1] === mark && field[2][1] === mark) {
            return true;
        } else if (field[0][2] === mark && field[1][2] === mark && field[2][2] === mark) {
            return true;
        } else if (field[0][0] === mark && field[1][1] === mark && field[2][2] === mark) {
            return true;
        } else if (field[0][2] === mark && field[1][1] === mark && field[2][0] === mark) {
            return true;
        } else {
            return false;
        }
    }
}

play(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
);