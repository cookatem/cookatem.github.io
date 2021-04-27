const changeElement = (elementIds, func) => {
    elementIds.forEach(elementId => {
        let element = document.getElementById(elementId);
        func(element);
    });
}