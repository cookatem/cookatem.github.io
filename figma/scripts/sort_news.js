

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