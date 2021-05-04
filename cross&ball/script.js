const HTMLMap = (HTMLArray, callback) => {
    let newArray = [];
    for (let index = 0; index < HTMLArray.length; index++) {
        let newArrayElement = callback(HTMLArray[index], index);
        if (typeof newArrayElement !== "undefined") newArray.push(newArrayElement);
    }

    return newArray;
};

const getGameStatus = (arrayOfGameElements) => {
    let activeElements = [HTMLMap(arrayOfGameElements, (element, index) => { if (element.classList.contains("cross-active")) return index; }), 
                          HTMLMap(arrayOfGameElements, (element, index) => { if (element.classList.contains("circle-active")) return index; })],
        waysToWin = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]],
        gameStatus = [false, false];

    for (let index = 0; index < activeElements.length; index++) {
        for (let wayToWin of waysToWin) {
            if (wayToWin.some(num => !activeElements[index].includes(num))) continue;
            else if (wayToWin.every(num => activeElements[index].includes(num))) gameStatus[index] = true;
        }
    }

    return gameStatus;
};

const clearGameArea = (gameElements) => {
    [...gameElements].forEach(element => { element.classList.remove("cross-active"); element.classList.remove("circle-active"); });
}

window.onload = () => {
    let gameElements = document.getElementsByClassName("game-area__element"), character = "cross";
    for (let gameElement of gameElements) {
        gameElement.addEventListener("click", () => {
            if (!(gameElement.classList.contains("cross-active") || gameElement.classList.contains("circle-active"))) {
                gameElement.classList.toggle(`${character}-active`);
                switch (character) {
                    case "cross":
                        character = "circle"; break;
                    case "circle":
                        character = "cross"; break;
                }
                
                document.getElementById("character-motion").innerText = `${character[0].toUpperCase() + character.slice(1)}'s motion`;
                let status = getGameStatus(gameElements);
                for (let index = 0; index < status.length; index++) {
                    if (status[index] && index === 0) {
                        clearGameArea(gameElements);
                        document.getElementById("cross-count").innerText++;
                    } else if (status[index] && index === 1) {
                        clearGameArea(gameElements);
                        document.getElementById("circle-count").innerText++;
                    }
                }

                if ([...gameElements].every(element => element.classList.contains("cross-active") || element.classList.contains("circle-active"))) {
                    clearGameArea(gameElements);
                }
            }
        });
    }
}