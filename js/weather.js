const weatherStatus = document.querySelector("#weather-status");
const weatherResult = document.querySelector("#weather-result");

const loadWeather = async () => {
    weatherStatus.textContent = "Loading weather...";

    try {
        const response = await fetch(
            "https://api.open-meteo.com/v1/forecast?latitude=52.08&longitude=4.31&current=temperature_2m,wind_speed_10m"
        );

        if (!response.ok) {
            throw new Error("Weather could not be loaded.");
        }

        const data = await response.json();

        displayWeather(data);

    } catch (error) {
        weatherStatus.textContent =
            "Sorry, the weather information could not be loaded.";
    }
};

const displayWeather = data => {
    weatherStatus.textContent = "";
    weatherResult.textContent = "";

    const temperature = document.createElement("p");
    temperature.textContent =
        `Temperature: ${data.current.temperature_2m} °C`;

    const wind = document.createElement("p");
    wind.textContent =
        `Wind speed: ${data.current.wind_speed_10m} km/h`;

    weatherResult.appendChild(temperature);
    weatherResult.appendChild(wind);
};

loadWeather();