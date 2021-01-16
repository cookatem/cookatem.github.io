var modal_window = document.getElementById("modal_window");
var close_line1 = document.getElementById("close1");
var close_line2 = document.getElementById("close2");

function ShowModalWindow () {
    modal_window.classList.remove("hidden", "hide");
    modal_window.classList.toggle("show");
    close_line1.classList.remove("animation_close1");
    close_line2.classList.remove("animation_close2");
}

function HideModalWindow () {
    close_line1.classList.toggle("animation_close1");
    close_line2.classList.toggle("animation_close2");
    modal_window.classList.remove("show");
    modal_window.classList.toggle("hidden");
    setTimeout(function() {modal_window.classList.toggle("hide");}, 290);
}