import { useState } from "react";
import APIHealthcheck from "./components/APIHealthCheck";
import WeatherCard from "./components/WeatherCardStockholm";
import FavouriteCity from "./components/FavouriteCity";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <h1>Vite + React</h1>
      <div className="card"></div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
      <div>
        <APIHealthcheck />
        <WeatherCard />
        <FavouriteCity />
      </div>
    </>
  );
}

export default App;
