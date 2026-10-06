const formulier = document.getElementById("contactForm");

formulier.addEventListener("submit", function (event) {
  event.preventDefault();

  const naam = document.getElementById("naam").value.trim();
  const email = document.getElementById("email").value.trim();
  const bericht = document.getElementById("bericht").value.trim();

  const naamFout = document.getElementById("naamFout");
  const emailFout = document.getElementById("emailFout");
  const berichtFout = document.getElementById("berichtFout");

  let geldig = true;

  naamFout.textContent = "";
  emailFout.textContent = "";
  berichtFout.textContent = "";

  if (naam === "") {
    naamFout.textContent = "Vul je naam in.";
    geldig = false;
  }

  if (email === "") {
    emailFout.textContent = "Vul je e-mailadres in.";
    geldig = false;
  }

  if (bericht.length < 10) {
    berichtFout.textContent = "Je bericht moet minimaal 10 tekens bevatten.";
    geldig = false;
  }

  if (geldig) {
    document.getElementById("succes").textContent =
      "Je bericht is succesvol verzonden!";
    document.getElementById("naam").value = "";
    document.getElementById("email").value = "";
    document.getElementById("bericht").value = "";
  }
});
