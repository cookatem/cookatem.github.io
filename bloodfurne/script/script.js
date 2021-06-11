const slideBackground = (element) => {
    let count = 2, stopId = setInterval(() => {
        element.style.backgroundImage = `url(images/header/bloodborne${count}.jpg)`;
        if (count === 4) count = 1; else count++;
    }, 8000);
}

let position = 0;
const slideElement = (slider, changePosition) => {
    position = changePosition(position);
    if (position === slider.children.length) position = 0;
    else if (position < 0) position = slider.children.length - 1;
    slider.style.transform = `translateX(-${position * 100 + .1}%)`;
}

window.onload = function () {
    slideBackground(document.getElementsByClassName("slider")[0]);
    const paths = ["cleric-beast", "gascoigne", "blood-starved"];
    for (let index = 0; index < document.getElementsByClassName("slider-container__trackline").length; index++) {
        let element = document.getElementsByClassName("slider-container__trackline")[index];
        for (let childIndex = 0; childIndex < element.children.length; childIndex++) {
            element.children[childIndex].style.backgroundImage = `url(images/bosses/${paths[index]}/${childIndex + 1}.jpg)`;
        }
    }
}