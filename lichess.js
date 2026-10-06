fetch("https://lichess.org/api/user/chrono070")
  .then((response) => {
    if (!response.ok) {
      throw new Error("API werkt niet");
    }

    return response.json();
  })
  .then((data) => {
    document.getElementById("lichessData").textContent =
      "Gebruikersnaam: " + data.username;

    document.getElementById("blitzRating").textContent =
      "Blitz rating: " + data.perfs.blitz.rating;

    document.getElementById("rapidRating").textContent =
      "Rapid rating: " + data.perfs.rapid.rating;
  })
  .catch((error) => {
    document.getElementById("lichessData").textContent =
      "De Lichess-gegevens konden niet worden geladen.";
  });
