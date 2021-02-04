let music_list = [{song_name: "Moonlight", author: "xxxTentacon", img_src: "img/songs/moonlight.jpg"},
                  {song_name: "Районы - Кварталы", author: "Звери", img_src: "img/songs/rayoni.jpg"},
                  {song_name: "Батарейка", author: "Жуки", img_src: "img/songs/power.jpg"},
                  {song_name: "Rockstar", author: "Post Malone", img_src: "img/songs/rockstar.jpg"},
                  {song_name: "Группа Крови", author: "Цой", img_src: "img/songs/blood.jpg"},
                  {song_name: "Believer", author: "Imagine Dragons", img_src: "img/songs/believer.jpg"},
                  {song_name: "Непохожие", author: "Quest Pistols", img_src: "img/songs/qps.jpg"},
                  {song_name: "Скр Скр Скр", author: "Фараон", img_src: "img/songs/skr.jpg"},
                  {song_name: "Девочка с каре", author: "Мукка", img_src: "img/songs/kare.jpg"},
                  {song_name: "Вахтерам", author: "Бумбокс", img_src: "img/songs/vaht.jpg"}
]

function ShowModal (change_id, class_name, toggle, music_place) {
    if (toggle) { 
        document.getElementById("music_player__image").style.backgroundImage = `url(${music_list[music_place - 1].img_src})`;
        document.getElementById("song_name").innerText = music_list[music_place - 1].song_name;
        document.getElementById("song_author").innerText = music_list[music_place - 1].author;
    }
    document.getElementById(change_id).classList.toggle(class_name, toggle);
}