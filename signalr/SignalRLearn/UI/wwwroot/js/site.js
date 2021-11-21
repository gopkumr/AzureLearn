const form = document.querySelector(".top-banner form");
const input = document.querySelector(".top-banner input");
const msg = document.querySelector(".top-banner .msg");
const list = document.querySelector(".ajax-section .cities");
var filteredArray = [];

form.addEventListener("submit", e => {
    e.preventDefault();
    let inputVal = input.value;

    //check if there's already a city
    const listItems = list.querySelectorAll(".ajax-section .city");
    const listItemsArray = Array.from(listItems);

    if (listItemsArray.length > 0) {
        filteredArray = listItemsArray.filter(el => {
            let content = "";
            //athens,gr
            if (inputVal.includes(",")) {
                //athens,grrrrrr->invalid country code, so we keep only the first part of inputVal
                if (inputVal.split(",")[1].length > 2) {
                    inputVal = inputVal.split(",")[0];
                    content = el
                        .querySelector(".city-name span")
                        .textContent.toLowerCase();
                } else {
                    content = el.querySelector(".city-name").dataset.name.toLowerCase();
                }
            } else {
                //athens
                content = el.querySelector(".city-name span").textContent.toLowerCase();
            }
            return content == inputVal.toLowerCase();
        });
    }

    //ajax here
    const url = `http://localhost:7071/api/GetWeather/` + inputVal.toLowerCase();

    fetch(url)
        .then(response => response.json())
        .then(data => {
            const { name, weather } = data;
            const icon = `http://openweathermap.org/img/wn/${weather.icon}@2x.png`;
            if (filteredArray.length > 0) {
                filteredArray[0].querySelector(".city-temp span").textContent = Math.round(weather.temp)
            }
            else {
                const li = document.createElement("li");
                li.classList.add("city");
                const markup = `
                    <h2 class="city-name" data-name="${name.city},${name.country}">
                      <span>${name.city}</span>
                      <sup>${name.country}</sup>
                    </h2>
                    <div class="city-temp"><span>${Math.round(weather.temp)}</span><sup>°C</sup></div>
                    <figure>
                      <img class="city-icon" src="${icon}" alt="${weather.description
                                }">
                      <figcaption>${weather.description}</figcaption>
                    </figure>
                  `;
                li.innerHTML = markup;
                list.appendChild(li);
            }
        })
        .catch(() => {
            msg.textContent = "Please search for a valid city 😩";
        });

    msg.textContent = "";
    form.reset();
    input.focus();
});