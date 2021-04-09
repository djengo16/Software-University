function solve() {
  const baseUrl = "https://judgetests.firebaseio.com";
  const submitBtn = document.querySelector("#submit");
  const locationInput = document.querySelector("#location");
  const currentCondition = document.querySelector("#current");
  const forecastDiv = document.querySelector("#forecast");

  const symbolsCode = {
    Sunny: "&#x2600", // ☀
    "Partly sunny": "&#x26C5", // ⛅
    Overcast: "&#x2601", // ☁
    Rain: "&#x2614", // ☂
    Degrees: "&#176", // °
  };

  submitBtn.addEventListener("click", getData);

  function getData() {
    fetch(`${baseUrl}/locations.json`)
      .then((response) => response.json())
      .then((data) => {
        let { name, code } = data.find(
          (city) => city.name == locationInput.value
        );
          

        let current = fetch(
          `${baseUrl}/forecast/today/${code}.json`
        ).then((response) => response.json());

        let upcoming = fetch(
          `${baseUrl}/forecast/upcoming/${code}.json`
        ).then((res) => res.json());

        Promise.all([current, upcoming])
          .then(([currdata, upcomingData]) => {
            getCurrentWeather(currdata);
            getUpcomingWeather(upcomingData);
          })
          .catch((e) => {
            document.getElementById("content").innerHTML +=
              '<h2 style="text-align: center;">An error occured.</h2>';
          });
      });
  }

  function createElement(type, className, content) {
    let element = document.createElement(type);
    element.className = className;
    if (content) {
      element.innerHTML = content;
    }
    return element;
  }

  function createUpcomingSpan(forecast) {
    let upcomingSpan = createElement("span", "upcoming");

    let symbolSpan = createElement(
      "span",
      "forecast-data",
      symbolsCode[forecast.condition]
    );
    let degreeSpan = createElement(
      "span",
      "forecast-data",
      `${forecast.low}${symbolsCode["Degrees"]}/${forecast.high}${symbolsCode["Degrees"]}`
    );
    let conditionSpan = createElement(
      "span",
      "forecast-data",
      forecast.condition
    );

    upcomingSpan.appendChild(symbolSpan);
    upcomingSpan.appendChild(degreeSpan);
    upcomingSpan.appendChild(conditionSpan);

    return upcomingSpan;
  }

  function getCurrentWeather(data) {
    forecastDiv.setAttribute("style", "display:block");
    let forecastsDiv = document.querySelector(".forecasts");

    if (forecastsDiv != null) {
      currentCondition.removeChild(forecastsDiv);
    }

    forecastsDiv = createElement("div", "forecasts");

    const conditionSymbolSpan = createElement(
      "span",
      "condition symbol",
      symbolsCode[data.forecast.condition]
    );

    const conditionSpan = createElement("span", "condition");

    const locationData = createElement("span", "forecast-data", data.name);

    let degreesContent = `${data.forecast.low}${symbolsCode["Degrees"]}/${data.forecast.high}${symbolsCode["Degrees"]}`;
    const degrees = createElement("span", "forecast-data", degreesContent);

    const weather = createElement(
      "span",
      "forecast-data",
      data.forecast.condition
    );

    conditionSpan.appendChild(locationData);
    conditionSpan.appendChild(degrees);
    conditionSpan.appendChild(weather);

    forecastsDiv.appendChild(conditionSymbolSpan);
    forecastsDiv.appendChild(conditionSpan);

    currentCondition.append(forecastsDiv);
  }

  function getUpcomingWeather(data) {
    let forecastInfo = document.querySelector(".forecast-info");
    const upcomingDiv = document.querySelector("#upcoming");

    if (forecastInfo != null) {
      upcomingDiv.removeChild(forecastInfo);
    }

    forecastInfo = createElement("div", "forecast-info");

    data.forecast.forEach((curr) => {
      forecastInfo.appendChild(createUpcomingSpan(curr));
    });

    upcomingDiv.appendChild(forecastInfo);
  }
}

solve();
