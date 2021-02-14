// All news
let news = [{name: "Релиз GTA 6!", description: "Релизнули GTA 6! Не обман точно!", date: "12/02/21"},
            {name: "STALKER 2 не выйдет?", description: "STALKER 2 не выйдет, сообщили разработчики, по причи..", date: "23/09/20"},
            {name: "Cyberpunk 2077 не выйдет?", description: "Не актуально", date: "09/12/20"}
];

// Return biggest time in index from list
function DateComparison (list) {
    let days = [];
    let date = [];
    for (let i = 0; i < list.length; i++) {
        date = list[i].date.split("/");
        days.push(parseInt(date[0]) + parseInt(date[1] * 30) + ((parseInt(date[2]) - 10) * 355));
    }

    let biggest_value = days[0];
    let biggest_index = 0;
    for (let i = 1; i < days.length; i++) {
        if (days[i] > biggest_value) {
            biggest_value = days[i];
            biggest_index = i;
        }
    }

    return biggest_index;
}

// Sort
function SelectionSort (list) {
    let copy_list = list.slice();
    let biggest_index;
    let sortedList = [];
    let as =  0;
    for (let i = 0; i < list.length; i++) {
        biggest_index = DateComparison(copy_list);
        sortedList.push(copy_list[biggest_index]);
        copy_list.splice(biggest_index, 1);
    }

    return sortedList;
}

// Sorting list at time
news = SelectionSort(news);