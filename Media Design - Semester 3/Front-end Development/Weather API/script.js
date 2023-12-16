let cityName = null;

// Call the function to get the current city when the page loads
getCurrentCity();

// Function to get the current city based on geolocation
function getCurrentCity() {
  if ("geolocation" in navigator) {
    // Get the user's geolocation
    navigator.geolocation.getCurrentPosition(function (position) {
      const latitude = position.coords.latitude;
      const longitude = position.coords.longitude;

      // Use the geolocation coordinates to fetch the city information
      fetch(
        `https://nominatim.openstreetmap.org/reverse?format=json&lat=${latitude}&lon=${longitude}`
      )
        .then((response) => response.json())
        .then((data) => {
          cityName = data.address.city;

          // Update the displayed city and country
          const currentCityElement = document.getElementById("cityName");
          const country = data.address.country;
          currentCityElement.textContent = `${cityName}, ${country}`;

          // Fetch weather data and update the background
          fetchWeatherData(cityName);
        })
        .catch((error) => {
          console.error("Error fetching location data:", error);
        });
    });
  } else {
    console.error("Geolocation is not available in your browser.");
  }
}

// Function to change the background based on weather conditions

function changeBackground(weather) {
  const container = document.getElementById("container");
  const tagNameToRemove = "video";
  const childElements = container.getElementsByTagName(tagNameToRemove);

  // Remove existing video elements
  for (let i = childElements.length - 1; i >= 0; i--) {
    const childElement = childElements[i];
    container.removeChild(childElement);
  }

  // Create a new video element
  const videoElement = document.createElement("video");
  videoElement.setAttribute("autoplay", true);
  videoElement.setAttribute("loop", true);
  videoElement.setAttribute("muted", true);
  videoElement.style.filter = "brightness(60%)";

  const sourceElement = document.createElement("source");

  // Determine the video source based on weather conditions

  switch (true) {
    case weather.includes("Clouds"):
      sourceElement.setAttribute("src", "/Weather API/Videos/cloudy.mp4");
      break;
    case weather.includes("Clear"):
      console.log(weather);
      sourceElement.setAttribute("src", "/Weather API/Videos/clearSky.mp4");
      break;
    case weather.includes("Rain"):
      sourceElement.setAttribute("src", "/Weather API/Videos/Rain.mp4");
      break;
    case weather.includes("Snow"):
      sourceElement.setAttribute("src", "/Weather API/Videos/snowing.mp4");
      break;
    case weather.includes("Thunderstorm"):
      sourceElement.setAttribute("src", "/Weather API/Videos/Thunderstorm.mp4");
      break;
  }

  sourceElement.setAttribute("type", "video/mp4");
  videoElement.appendChild(sourceElement);
  container.style.background = "none";
  container.appendChild(videoElement);
}

// Function to fetch weather data for the specified city

function fetchWeatherData(cityName) {
  const apiKey = "51a2bb139dd17115875db04cc203c141";
  const cityNameElement = document.getElementById("cityName");
  const temperatureElement = document.getElementById("temperature");
  const feelsLikeElement = document.getElementById("feels-like");
  const humidityElement = document.getElementById("humidity");
  const weatherDescriptionElement =
    document.getElementById("weatherDescription");
  const weatherIconElement = document.getElementById("weatherIcon");
  const windSpeedElement = document.getElementById("windSpeed");

  // Fetch weather data from an API

  fetch(
    `https://api.openweathermap.org/data/2.5/weather?q=${cityName}&appid=${apiKey}`
  )
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      if (data.cod === 200) {
        const cityName = data.name;
        const temperature = `${Math.round(data.main.temp - 273.15)}°C`;
        const feels_like = `${Math.round(data.main.feels_like - 273.15)}°C`;
        const humidityLevel = `${data.main.humidity} %`;
        const weatherDescription = data.weather[0].description;
        const weatherMain = data.weather[0].main;
        const windSpeed = data.wind.speed;
        const weatherIcon = `https://openweathermap.org/img/wn/${data.weather[0].icon}.png`;

        // Update displayed weather information

        cityNameElement.textContent = cityName;
        temperatureElement.textContent = `Temperature: ${temperature}`;
        feelsLikeElement.textContent = `Feels like: ${feels_like}`;
        humidityElement.textContent = `Humidity: ${humidityLevel}`;
        weatherDescriptionElement.textContent = `Weather: ${weatherDescription}`;
        windSpeedElement.textContent = `Speed: ${windSpeed} m/s`;
        weatherIconElement.src = weatherIcon;

        // Update the background based on weather conditions

        changeBackground(weatherMain);
      } else {
        cityNameElement.textContent = "City not found";
        temperatureElement.textContent = "";
        weatherDescriptionElement.textContent = "";
      }
    })
    .catch((error) => console.error("Error fetching data:", error));
}

// Add an event listener to change the city on button click

const changeCityButton = document.getElementById("changeCityBtn");
changeCityButton.addEventListener("click", function () {
  const newCityInput = document.getElementById("newCity");
  const newCity = newCityInput.value;
  fetchWeatherData(newCity);
});
