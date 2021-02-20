(function extend(){
    Array.prototype.last = function() {
        return this[this.length -1];
    }
    Array.prototype.skip = function(n) {
        let newArr = [];

        for(let i = n; i < this.length; i++){

            newArr.push(this[i]);
        }

        return newArr;
    }

    Array.prototype.take = function(n) {
        let newArr = [];

        for(let i = 0; i < n; i++){

            newArr.push(this[i]);
        }

        return newArr;
    }

    Array.prototype.sum = function() {
        return this.reduce((x, acc) => {
            acc += x;
            return acc;
        },0);
    }

    Array.prototype.average = function() {
        return this.reduce((x, acc) => {
            acc += x;
            return acc;
        },0) / this.length;
    }
})();


let arr = [1,2,3,4,5,6,7,8,9,10];

let sum = arr.sum();
let newArr = arr.take(3);
let last = arr.last();