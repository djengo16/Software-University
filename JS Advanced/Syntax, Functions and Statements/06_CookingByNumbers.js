function cook(arr) {
    let number = Number(arr.shift());

    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.80;
                break;
        }
        console.log(number);
    }

}

cook(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);