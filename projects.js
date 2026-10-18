//array voor alle projecten
const projecten = [
  {
    naam: "hotelsimulator",
    categorie: "java",
    afbeelding: "hotelsim.png",
    beschrijving: "I built a hotelsimulator in java",
    link: "https://github.com/DimiS0/Hotel-simulatie---groep-7-",
  },
  {
    naam: "travel agency menu",
    categorie: "python",
    afbeelding: "pythonkaart.jpg",
    beschrijving: "I built a travel agency menu in python",
    link: "",
  },
  {
    naam: "verkoop website",
    categorie: "HTML",
    afbeelding: "htmlkaart.jpg",
    beschrijving: "basic website met html en php",
    link: "",
  },
];

//html selecteren
const container = document.getElementById("projecten");
const dropdownMenu = document.querySelector(".dropdownmenu");
const dropdownButton = document.querySelector(".dropdownbutton");

let element = null;

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

//knop python
const pythonButton = document.createElement("button");
pythonButton.textContent = "python";
pythonButton.value = "python";
dropdownMenu.appendChild(pythonButton);

//knop HTML
const HTMLButton = document.createElement("button");
HTMLButton.textContent = "HTML";
HTMLButton.value = "HTML";
dropdownMenu.appendChild(HTMLButton);

//functie om projecten te tonen
function toonProjecten() {
  container.innerHTML = "";

  projecten.forEach((project) => {
    let linkHTML = "";
    if (project.link === "") {
      linkHTML = `<p class="button">
          Read More
        </p>`;
    } else {
      linkHTML = `<a href="${project.link}" class="button" target="_blank">
          Read More
        </a>`;
    }
    if (gekozenCategorie === "alle" || project.categorie === gekozenCategorie) {
      container.innerHTML += `
        <div class="card">
          <img src="${project.afbeelding}" alt="${project.naam}">
          <div class="cardcontent">
            <h2>${project.naam}</h2>
            <p>${project.beschrijving}</p>
            ${linkHTML}
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

//wanneer je op python klikt
pythonButton.addEventListener("click", () => {
  gekozenCategorie = pythonButton.value;
  dropdownButton.textContent = pythonButton.textContent + " ▾";
  toonProjecten();
});

HTMLButton.addEventListener("click", () => {
  gekozenCategorie = HTMLButton.value;
  dropdownButton.textContent = HTMLButton.textContent + " ▾";
  toonProjecten();
});

//projecten tonen wanneer de pagina net is geladen
toonProjecten();
