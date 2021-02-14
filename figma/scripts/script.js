function ModalWindow (id, toggle) {
    if (toggle) {
        document.getElementById(id).classList.remove("window_hidden");
        document.getElementById(id).classList.toggle("window_active");
    } else { 
        document.getElementById(id).classList.remove("window_active"); 
        document.getElementById(id).classList.add("window_hidden");
    }
}

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

// All news
let news = [{name: "Релиз GTA 6!", description: "Релизнули GTA 6! Не обман точно!", date: "12/02/21"},
            {name: "STALKER 2 не выйдет?", description: "STALKER 2 не выйдет, сообщили разработчики, по причи..", date: "23/09/20"},
            {name: "Cyberpunk 2077 не выйдет?", description: "Не актуально", date: "09/12/20"}
];

let image = document.createElement('img');
image.src = getBgUrl(document.getElementById('main_bg'));
image.onload = function () { document.getElementById("loading_block").classList.toggle("is_load", true); };