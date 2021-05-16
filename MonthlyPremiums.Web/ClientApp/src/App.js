import React, { Fragment, useState, useEffect } from 'react';
import Header from "./components/header";
import { PremiumCalculator } from "./components/PremiumCalculator";

import './custom.css'

const App = () => {
  const [occupations, setOccupations] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getOccupationsWithRatings();
  }, []);

  async function getOccupationsWithRatings() {
    const response = await fetch("https://localhost:44304/api/Occupation");
    const result = await response.json();
    setOccupations(result);
    setLoading(false);
  }

  return (
    <Fragment>
      {loading
        ?
        <p><em>Loading...</em></p>
        :
        <div>
          <Header />
          <PremiumCalculator occupations={occupations} />
        </div>
      }
    </Fragment>
  );
}

export default App;