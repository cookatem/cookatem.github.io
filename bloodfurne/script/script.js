const slideBackground = (element) => {
    let count = 2, stopId = setInterval(() => {
        element.style.backgroundImage = `url(images/header/bloodborne${count}.jpg)`;
        if (count === 3) count = 1; else count++;
    }, 8000);
}

let position = 0;
const slideElement = (slider, changePosition) => {
    position = changePosition(position);
    if (position === slider.children.length) position = 0;
    else if (position < 0) position = slider.children.length - 1;
    slider.style.transform = `translateX(-${position * 100 + .1}%)`;
}

const giveSearchResults = (input, resultArray) => {
    for (let index = 0; index < resultArray.length; index++) {
        let title = resultArray[index].children[0].innerText.toLowerCase();
        if (!title.includes(input.value.toLowerCase().trim())) resultArray[index].style.display = "none";
        else resultArray[index].style.display = "block";
    }
}

window.onload = function () {
    slideBackground(document.getElementsByClassName("slider")[0]);
    const paths = ["cleric-beast", "gascoigne", "blood-starved", "amelia"];
    for (let index = 0; index < document.getElementsByClassName("slider-container__trackline").length; index++) {
        let element = document.getElementsByClassName("slider-container__trackline")[index];
        for (let childIndex = 0; childIndex < element.children.length; childIndex++) {
            element.children[childIndex].style.backgroundImage = `url(images/bosses/${paths[index]}/${childIndex + 1}.jpg)`;
        }
    }

    let lastChange = "", inputholder = document.getElementById("search"), stopId = setInterval(() => {
        if (inputholder.value !== lastChange) {
            lastChange = inputholder.value;
            giveSearchResults(inputholder, document.getElementsByClassName("main-content__block"));
        }
    }, 300);
}