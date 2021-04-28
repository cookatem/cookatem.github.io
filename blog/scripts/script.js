const getElement = (elementIds, func) => {
    elementIds.forEach(elementId => {
        let element = document.getElementById(elementId);
        func?.(element);
    });
}

let position = 0;
const trackSlider = (func) => {
    const classArray = document.getElementsByClassName("slider-container__trackline_item");
    position = func(position);
    if (position === -1) { position = classArray.length - 1; }
    else if (position === classArray.length) { position = 0; }
    getElement(["slider_trackline"], element => element.style.transform = `translateX(-${position * classArray[0].offsetWidth}px)`)
}

window.onload = () => {
    let classArray = document.getElementsByClassName("slider-container__trackline_item");
    for (let num = 1; num <= classArray.length; num++) {
        let element = classArray[num - 1];
        element.style.backgroundImage = `url("images/slider-images/${num}.jpg")`
    }

    let isHover, stopSlideKey = setInterval(() => {
        getElement(["slider"], element => {
            element.addEventListener("mousemove", () => isHover = true);
            element.addEventListener("mouseleave", () => isHover = false);
        })
        if (!isHover) trackSlider(position => ++position);
    }, 10000);
}
