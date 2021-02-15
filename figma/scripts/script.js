// Show or Hide Modal window
function ModalWindow (id, toggle) {
    if (toggle) {
        document.getElementById(id).classList.remove("window_hidden");
        document.getElementById(id).classList.toggle("window_active");
    } else { 
        document.getElementById(id).classList.remove("window_active"); 
        document.getElementById(id).classList.add("window_hidden");
    }
}

// Picture is loaded
function getBgUrl(element) {
    var background = "";
    if (element.currentStyle) {
        background = element.currentStyle.backgroundImage;
    } else if (document.defaultView && document.defaultView.getComputedStyle) { // Firefox
        background = document.defaultView.getComputedStyle(element, "").backgroundImage;
    } else {
        background = element.style.backgroundImage;
    }
    return background.replace(/url\(['"]?(.*?)['"]?\)/i, "$1");
}

let image = document.createElement('img');
image.src = getBgUrl(document.getElementById('main_bg'));
image.onload = function () { document.getElementById("loading_block").classList.toggle("is_load", true); };