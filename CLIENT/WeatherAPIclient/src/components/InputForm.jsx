import React, { useState } from "react";

function InputForm({ onCityChange }) {
  const [cityInput, setCityInput] = useState("");

  const handleFormSubmit = (event) => {
    event.preventDefault();
    onCityChange(cityInput);
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <input
        type="text"
        value={cityInput}
        onChange={(event) => setCityInput(event.target.value)}
      />
      <button type="submit">Submit</button>
    </form>
  );
}

export default InputForm;
