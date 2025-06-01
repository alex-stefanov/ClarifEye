document.addEventListener('DOMContentLoaded', function(){
    const inputValue = document.querySelector('#color-id').value;

    const roseColorEl = document.querySelector('#rose-color .paint-splash');

    if (inputValue == 0){
        roseColorEl.style.backgroundColor = "black";
    } else if (inputValue == 1) {
        roseColorEl.style.backgroundColor = "blue";
    } else if (inputValue == 2) {
        roseColorEl.style.backgroundColor = "brown";
    } else if (inputValue == 3) {
        roseColorEl.style.backgroundColor = "green";
    } else if (inputValue == 4) {
        roseColorEl.style.backgroundColor = "gray";
    } else if (inputValue == 5) {
        roseColorEl.style.backgroundColor = "orange";
    } else if (inputValue == 6) {
        roseColorEl.style.backgroundColor = "pink";
    } else if (inputValue == 7) {
        roseColorEl.style.backgroundColor = "purple";
    } else if (inputValue == 8) {
        roseColorEl.style.backgroundColor = "red";
    } else if (inputValue == 9) {
        roseColorEl.style.backgroundColor = "silver";
    } else if (inputValue == 10) {
        roseColorEl.style.backgroundColor = "white";
    } else if (inputValue == 11) {
        roseColorEl.style.backgroundColor = "yellow";
    }
});
