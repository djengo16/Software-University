function stopwatch() {
  let startButton = document.getElementById("startBtn");
  let stopButton = document.getElementById("stopBtn");
  startButton.addEventListener("click", count);
  stopButton.addEventListener("click", clear);
  let timerString = document.getElementById("time");
  let timer;

  let seconds = 0;
  let minutes = 0;

  function count() {
    let counter = 0;
    startButton.disabled = true;
    stopButton.disabled = false;
    timerString.textContent = "00:00";
    timer = setInterval(() => {
      counter++;
      seconds = counter % 60;
      minutes = Math.floor(counter / 60);
      if (seconds < 10) {
        seconds = `0${seconds}`;
      }
      if (minutes === 0) {
        minutes = "00";
      } else if (minutes < 9) {
        minutes = `0${minutes}`;
      }
      timerString.textContent = `${minutes}:${seconds}`;
    }, 1000);
  }
  function clear() {
    startButton.disabled = false;
    stopButton.disabled = true;
    seconds = 0;
    minutes = 0;
    clearInterval(timer);
  }
}
