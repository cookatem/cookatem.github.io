let songs_info = [{img_src: "img/songs/moonlight.webp", song_src: "music/moonlight.mp3"},
                  {img_src: "img/songs/rayoni.webp", song_src: "music/rayoni.mp3"},
                  {img_src: "img/songs/power.webp", song_src: "music/batareyka.mp3"},
                  {img_src: "img/songs/rockstar.webp", song_src: "music/rockstar.mp3"},
                  {img_src: "img/songs/blood.webp", song_src: "music/gruppa-krovi.mp3"},
                  {img_src: "img/songs/believer.webp", song_src: "music/believer.mp3"},
                  {img_src: "img/songs/qps.webp", song_src: "music/nepohojie.mp3"},
                  {img_src: "img/songs/skr.webp", song_src: "music/skr.mp3"},
                  {img_src: "img/songs/kare.webp", song_src: "music/devochka.mp3"},
                  {img_src: "img/songs/vaht.webp", song_src: "music/vahteram.mp3"}
]

let audio = new Audio;
let width = 0;
let last_place = 0;

// Rewind Song
let x = 0;
let max_width = 0;
document.getElementById("music_line").addEventListener("click", function (event) {
    var target = this.getBoundingClientRect();
    x = event.pageX - target.left;
    max_width = document.getElementById("music_line").offsetWidth;
    audio.currentTime = audio.duration * (x / max_width);
});

// Continue
function ContinueSong () {
    audio.play();
    audio.currentTime = last_place;
    document.getElementById("music_stop").classList.toggle("active_button", false);
    document.getElementById("music_continue").classList.toggle("active_button");
}

// Stop
function StopSong () {
    audio.pause();
    document.getElementById("music_continue").classList.toggle("active_button", false);
    document.getElementById("music_stop").classList.toggle("active_button");
}

// Player
function Player (music_place) {

    if (audio.src.slice(audio.src.indexOf("music")) != songs_info[music_place - 1].song_src) {
        // Change song
        document.getElementById("music_player__image").classList.toggle("loading", true);
        audio.pause();
        document.getElementById("playing_line").style.width = "0%";
        document.getElementById("playing_line_ball").style.left = `calc(0% - .3rem)`;
        audio = new Audio(songs_info[music_place - 1].song_src);
        audio.autoplay = true;
    }

    audio.addEventListener("canplaythrough", function () {
        document.getElementById("music_player__image").classList.remove("loading");
    });

    if (document.getElementById("music_stop").classList.contains("active_button")) audio.pause();
    else document.getElementById("music_continue").classList.toggle("active_button", true);

    // Playing Line Animation
    let stop_playing_line = setInterval(function () {
        if (width === 100) clearInterval(stop_playing_line);
        width = audio.currentTime / audio.duration * 100;
        last_place = audio.currentTime;
        document.getElementById("playing_line").style.width = width.toString(10) + "%";
        document.getElementById("playing_line_ball").style.left = `calc(${width}% - .3rem)`;
    }, 1000);
}

// Show Information on Modal Window
function ChangeInfo (music_place) {
    document.getElementById("music_player__image").style.backgroundImage = `url(${songs_info[music_place - 1].img_src})`;
    names_of_songs = document.getElementsByClassName("block_information__music_title");
    authors_of_songs = document.getElementsByClassName("block_information__music_author");
    document.getElementById("song_name").innerText = names_of_songs[music_place - 1].innerText;
    document.getElementById("song_author").innerText = authors_of_songs[music_place - 1].innerText;
    for (let i = 0; i < names_of_songs.length; i++) names_of_songs[i].style.color = "#ffffff";
    names_of_songs[music_place - 1].style.color = "#B9B6AC";
}

function ShowModal (change_id, class_name, toggle, music_place) {
    if (toggle) { ChangeInfo(music_place); Player(music_place); }
    document.getElementById(change_id).classList.toggle(class_name, toggle);
}