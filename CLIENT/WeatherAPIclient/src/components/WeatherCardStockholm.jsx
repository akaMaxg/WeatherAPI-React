import React, { useState, useEffect } from "react";
import axios from "axios";

//functions
function WeatherCard() {
  const Url = "https://weatherapi-tdd.azurewebsites.net/weather";
  const [Data, setData] = React.useState(null);

  React.useEffect(() => {
    const fetchData = async () => {
      const result = await axios(Url);
      setData(result.data);
    };
    fetchData();
  }, []);
  return (
    <>
      {Data && Data.location && (
        <div>
          <h2>{Data.location?.name}</h2>
          <p>
            {Data.current?.temp_c}°C / {Data.current?.temp_f}°F
          </p>
          <p>Currently {Data.current?.condition.text}</p>
          <p>
            Wind: {Data.current?.wind_kph} kph / {Data.current?.wind_mph} mph
          </p>
          <p>Wind Degree: {Data.current?.wind_degree}</p>
          <p>Humidity: {Data.current?.humidity}</p>
        </div>
      )}
    </>
  );
}

export default WeatherCard;
