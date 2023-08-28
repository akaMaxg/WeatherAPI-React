import React, { useState } from "react";
import InputForm from "./InputForm";
import WeatherCardFavourite from "./WeatherCardFavourite";

function FavouriteCity() {
  const [city, setCity] = useState("");
  const [showWeatherCard, setShowWeatherCard] = useState(false);

  const handleCityChange = (newCity) => {
    setCity(newCity);
    setShowWeatherCard(true);
  };

  return (
    <div>
      <h3>Enter favourite city</h3>
      <InputForm onCityChange={handleCityChange} />
      {showWeatherCard && <WeatherCardFavourite city={city} />}
    </div>
  );
}

export default FavouriteCity;
