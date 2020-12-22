function calculateTime(steps, stepLength, speed){
let distance = steps * stepLength;
let restTime = Math.floor(distance / 500) * 60;
let speedForMeterInSec = speed / 3.6;
let totalTimeInSeconds = distance / speedForMeterInSec + restTime;

let hours = Math.floor(totalTimeInSeconds / 3600);
let minutes = Math.floor(totalTimeInSeconds / 60);
let seconds = Math.ceil(totalTimeInSeconds % 60);
if(seconds < 10){
    console.log(`0${hours}:0${minutes}:0${seconds}`);
}else if (minutes < 10){
    console.log(`0${hours}:0${minutes}:${seconds}`);
}else if (hours < 10){
    console.log(`0${hours}:${minutes}:${seconds}`);
}else {
    console.log(`${hours}:${minutes}:${seconds}`);
}
}

calculateTime(10, 0.70, 5.5);