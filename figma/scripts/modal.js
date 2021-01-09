var el = document.getElementById("modal_window");
var el1 = document.getElementById("close1");
var el2 = document.getElementById("close2");

function ShowModalWindow () {
    el.classList.remove("hidden", "hide");
    el.classList.toggle("show");
    el1.classList.remove("animation_close1");
    el2.classList.remove("animation_close2");
}

function HideModalWindow () {
    el1.classList.toggle("animation_close1");
    el2.classList.toggle("animation_close2");
    el.classList.remove("show");
    el.classList.toggle("hidden");
    setTimeout(function() {el.classList.toggle("hide");}, 290);
}