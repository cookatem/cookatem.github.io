const changeElement = (elementId, func) => {
    let element = document.getElementById(elementId);
    func(element);
}