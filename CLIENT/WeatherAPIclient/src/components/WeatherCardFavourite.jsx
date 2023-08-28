import React, { useState, useEffect } from "react";
import axios from "axios";

//functions
function WeatherCardFavourite(props) {
  const url = "https://localhost:7123/weather/" + props.city;
  const [data, setData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        console.log("API URL:", url);
        const result = await axios(url);
        setData(result.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, []);

  return (
    <>
      {data && data.location && (
        <div>
          <h2>{data.location?.name}</h2>
          <p>
            {data.current?.temp_c}°C / {data.current?.temp_f}°F
          </p>
          <p>Currently {data.current?.condition.text}</p>
          <p>
            Wind: {data.current?.wind_kph} kph / {data.current?.wind_mph} mph
          </p>
          <p>Wind Degree: {data.current?.wind_degree}</p>
          <p>Humidity: {data.current?.humidity}</p>
        </div>
      )}
    </>
  );
}

export default WeatherCardFavourite;
