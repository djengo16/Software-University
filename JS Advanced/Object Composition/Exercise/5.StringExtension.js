(function solve(){

    String.prototype.ensureStart = function(str){
        if(!this.startsWith(str)){
            return str + this;
        }
        return this.toString();
    }

    String.prototype.ensureEnd = function(str){
        if(!this.endsWith(str)){
            return this + str;
        }
        return this.toString();
    }

    String.prototype.isEmpty = function () {
        return this.toString().localeCompare("") == 0;
    };

    String.prototype.truncate = function(n){
        if(this.length <= n){
            return this.toString();
        }
        if(n <= 3){
            return '.'.repeat(n);
        }
        let spaceIndex = this.substring(0, n - 1).lastIndexOf(' ');
        if(spaceIndex >= 0){
            return this.substring(0, spaceIndex) + '...';
        }else{
            return this.substring(0, n - 3) + '...';
        }
    }

    String.format = function(string, ...params){
        let splitted = string.split(' ');

        splitted = splitted.reduce((acc, x) => {
            if(x.startsWith('{') && params.length != 0){
                x = params.shift();
            }
            acc.push(x);
            return acc;
        },[]);
        return splitted.join(' ');
    }
})()
let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');
