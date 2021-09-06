let elementInteraction = (key, callback) => {
    let element = document.querySelector(key);
    return callback(element);
}