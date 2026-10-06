//array voor alle projecten
const projecten = [
  {
    naam: "hotelsimulator",
    categorie: "java",
    afbeelding: "hotelsim.png",
    beschrijving: "hotelsimulator gebouwd met java",
    link: "https://github.com/DimiS0/Hotel-simulatie---groep-7-",
  },
];

//html selecteren
const container = document.getElementById("projecten");
const dropdownMenu = document.querySelector(".dropdownmenu");
const dropdownButton = document.querySelector(".dropdownbutton");

//standaard keuze
let gekozenCategorie = "alle";

//knop alle projecten
const alleButton = document.createElement("button");
alleButton.textContent = "Alle projecten";
alleButton.value = "alle";
dropdownMenu.appendChild(alleButton);

//knop java
const javaButton = document.createElement("button");
javaButton.textContent = "Java";
javaButton.value = "java";
dropdownMenu.appendChild(javaButton);

//knop web
const webButton = document.createElement("button");
webButton.textContent = "Web";
webButton.value = "web";
dropdownMenu.appendChild(webButton);

//functie om projecten te tonen
function toonProjecten() {
  container.innerHTML = "";

  projecten.forEach((project) => {
    if (gekozenCategorie === "alle" || project.categorie === gekozenCategorie) {
      container.innerHTML += `
        <div class="card">
          <img src="${project.afbeelding}" alt="${project.naam}">
          <div class="cardcontent">
            <h2>${project.naam}</h2>
            <p>${project.beschrijving}</p>
            <a href="${project.link}" class="button" target="_blank">Read More</a>
          </div>
        </div>
      `;
    }
  });
}

//wanneer je op alle projecten klikt
alleButton.addEventListener("click", () => {
  gekozenCategorie = alleButton.value;
  dropdownButton.textContent = alleButton.textContent + " ▾";
  toonProjecten();
});

//wanneer je op java klikt
javaButton.addEventListener("click", () => {
  gekozenCategorie = javaButton.value;
  dropdownButton.textContent = javaButton.textContent + " ▾";
  toonProjecten();
});

//wanneer je op web klikt
webButton.addEventListener("click", () => {
  gekozenCategorie = webButton.value;
  dropdownButton.textContent = webButton.textContent + " ▾";
  toonProjecten();
});

//projecten tonen wanneer de pagina net is geladen
toonProjecten();
