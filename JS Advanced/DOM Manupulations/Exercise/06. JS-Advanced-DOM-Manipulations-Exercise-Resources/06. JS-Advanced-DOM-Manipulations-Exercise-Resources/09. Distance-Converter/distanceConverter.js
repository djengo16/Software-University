function attachEventsListeners() {
  let inMeters = {
    km: 1000,
    m: 1,
    cm: 0.01,
    mm: 0.001,
    mi: 1609.34,
    yrd: 0.9144,
    ft: 0.3048,
    in: 0.0254,
  };

  document.getElementById("convert").addEventListener("click", convert);

  function convert() {
    let from = document.getElementById("inputUnits").value;
    let value = Number(document.getElementById("inputDistance").value);
    let to = document.getElementById("outputUnits").value;

    let meters = value * inMeters[from];
    let result = meters / inMeters[to];

    let output = document.getElementById("outputDistance");
    output.value = result;
  }
}
