function ModalWindow (id, toggle) {
    if (toggle) {
        document.getElementById(id).classList.remove("window_hidden");
        document.getElementById(id).classList.toggle("window_active");
    } else { 
        document.getElementById(id).classList.remove("window_active"); 
        document.getElementById(id).classList.add("window_hidden");
    }
}