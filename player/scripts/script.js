var songs = {
    "1": ["Moonlight", "xxxTentacion", "music/moonlight.mp3", "2:15"],
    "2": ["Районы - Кварталы", "Звери", "music/raioni.mp3", "3:24"],
    "3": ["Батарейка", "Жуки", "music/batareia.mp3", "3:47"],
    "4": ["Rockstar", "Post Malone", "music/rockstar.mp3", "3:38"]
}

var place_id = 4; //Song
var click = 0, now_seconds = 0, now_minutes = 0, line_length = 0;

function Song(arr) {
    return [place_id, arr[place_id]];
}

var header_info = Song(songs);
document.getElementById("place").innerHTML = header_info[0] + ". ";
document.getElementById("author").innerHTML = header_info[1][1];
document.getElementById("name_of_song").innerHTML = header_info[1][0];
document.title = header_info[1][0] + " - BitPodBit";

var audio = new Audio();
audio.src = header_info[1][2];
document.getElementById("end").innerHTML = header_info[1][3];
var last_place = 0;
function PlaySong() {
    click++;
    if (click % 2 == 0) { //Stop
        document.getElementById("play").className = "play fa fa-pause";
        last_place = audio.currentTime;
        audio.pause();
        clearInterval(stop_id);
    } else { //Play
        document.getElementById("play").className = "play fa fa-play";
        audio.currentTime = last_place;
        audio.play();
        var stop_id = setInterval(function () {
            line_length = (audio.currentTime / audio.duration) * 100;
            document.documentElement.style.setProperty("--line_playing_length", line_length + "%");
            now_seconds = Math.floor(audio.currentTime);
            now_minutes = Math.floor(now_seconds / 60);
            document.getElementById("now-seconds").innerHTML = now_seconds - 60 * now_minutes;
            document.getElementById("now-minutes").innerHTML = now_minutes;
            if (now_seconds - 60 * now_minutes <= 9) {
                document.getElementById("now-seconds").innerHTML = "0" + (now_seconds - 60 * now_minutes).toString(10);
            }

        }, 100);
    }
}



var now_length = 0, distance = 0, length_x = 0, max_length = 0;

var line_obj = document.querySelector("#player-line");
$("#player-line").click(function (event) {
    length_x = event.pageX - line_obj.offsetLeft;
    now_length = $("#playing-line").width();
    max_length = $(".max-line").width();
    distance = length_x - now_length;
    time = audio.currentTime + distance * (audio.duration / max_length);
    audio.currentTime = time;
})

function playAgain () {
    audio.currentTime = 0;
}