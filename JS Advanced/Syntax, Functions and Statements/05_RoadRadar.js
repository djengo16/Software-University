function findSpeed(arr) {
    let speed = arr[0];
    let area = arr[1];
    let output = '';
    switch (area) {
        case 'residential':
            speed <= 20 ? output = '' : output = getSpeedLimit(20, speed);
            break;
        case 'city':
            speed <= 50 ? output = '' : output = getSpeedLimit(50, speed);
            break;
        case 'interstate':
            speed <= 90 ? output = '' : output = getSpeedLimit(90, speed);
            break;
        case 'motorway':
            speed <= 130 ? output = '' : output = getSpeedLimit(130, speed);
            break;
    }

    function getSpeedLimit(limit, speed) {
        let diference = speed - limit;
        if (diference <= 20) {
            return 'speeding';
        } else if (diference <= 40) {
            return 'excessive speeding';
        } else {
            return 'reckless driving'
        }
    }
    console.log(output);
}

findSpeed([90, 'city']);