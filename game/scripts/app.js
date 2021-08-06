window.onload = function () {
    let player = document.getElementById("player");
    let locations = ["bottom", "middle", "top"], position = 1;

    // Player's Control
    addEventListener("keypress", (event) => {
        let current_position;
        locations.forEach((element) => { if ([...player.classList].includes(element)) current_position = element; });
        if (["w", "ц"].includes(event.key)) {
            if (current_position !== locations[2]) {
                player.classList.remove(current_position);
                player.classList.add(locations[locations.indexOf(current_position) + 1]);
            };
        } else if (["s", "ы"].includes(event.key)) {
            if (current_position !== locations[0]) {
                player.classList.remove(current_position);
                player.classList.add(locations[locations.indexOf(current_position) - 1]);
            }
        }
    });

    // Game
    
}