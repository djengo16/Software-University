function attachEventsListeners() {
  let days = document.getElementById("days");
  let hours = document.getElementById("hours");
  let minutes = document.getElementById("minutes");
  let seconds = document.getElementById("seconds");

  // seconds in day,hour,minute
  let secondsIn = {
    day: 86400,
    hour: 3600,
    minute: 60,
  };

  document.getElementById("daysBtn").addEventListener("click", () => {
    convert(days.value * secondsIn["day"]);
  });
  document.getElementById("hoursBtn").addEventListener("click", () => {
    convert(hours.value * secondsIn["hour"]);
  });
  document.getElementById("minutesBtn").addEventListener("click", () => {
    convert(minutes.value * secondsIn["minute"]);
  });
  document.getElementById("secondsBtn").addEventListener("click", () => {
    convert(seconds.value);
  });

  //convert from seconds to each unit
  function convert(sec) {
    days.value = sec / (24 * 60 * 60);
    hours.value = sec / (60 * 60);
    minutes.value = sec / 60;
    seconds.value = sec;
  }
}
