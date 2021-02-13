// All news
let news = [{name: "Релиз GTA 6!", description: "Релизнули GTA 6! Не обман точно!", date: "12/02/21"},
            {name: "STALKER 2 не выйдет?", description: "STALKER 2 не выйдет, сообщили разработчики, по причи..", date: "23/09/20"},
            {name: "Cyberpunk 2077 не выйдет?", description: "Не актуально", date: "09/12/20"}
]

function RemoveElementfromString (string, array_of_elements) {
    for (let i = 0; i < array_of_elements.length; i++) string = string.replace(array_of_elements[i], "");
    return string;
}

// Function return array with index of includes themes in list
function IncludesOf (list, string) {
    let words_array;
    let searching_themes = [];
    for (let i = 0; i < list.length; i++) {
        words_array = RemoveElementfromString(list[i].name, ["!", "?", "#", "/", "@", "*", "%"]).toLowerCase().split(" ");
        for (let j = 0; j < words_array.length; j++) {
            if (string.toLowerCase().includes(words_array[j])) {
                searching_themes.push(i);
                break;
            }
        }
    }

    return searching_themes;
}

window.onload = function () {

    // Add finding theme to HTML
    document.getElementById("submit_search").onclick = function () {
        document.getElementById("search_results").innerHTML = "";
        let seach_value = document.getElementById("search_block").value;
        let search_includes_info = IncludesOf(news, seach_value);
        if (search_includes_info.length) {
            for (let i = 0; i < search_includes_info.length; i++) {
                document.getElementById("search_results").innerHTML += 
                `<div class = "block_results__result">
                    <h3 class = "block_results__result_title">${news[search_includes_info[i]].name}</h3>
                    <p class = "block_results__result_description">${news[search_includes_info[i]].description}</p>
                </div>`
            }
        } else { document.getElementById("search_results").innerHTML = "По вашему запросу ничего не найдено"; console.log("1"); }
    }

}