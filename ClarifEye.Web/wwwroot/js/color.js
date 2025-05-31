document.addEventListener("DOMContentLoaded", function(){
    let id = document.querySelector('#color-id').value;
    const el = document.querySelector('.paint-splash');
    if (id == 0) el.style.backgroundColor = "black";
    else if (id == 1) el.style.backgroundColor = "blue";
    else if (id == 2) el.style.backgroundColor = "brown";
    else if (id == 3) el.style.backgroundColor = "green";
    else if (id == 4) el.style.backgroundColor = "gray";
    else if (id == 5) el.style.backgroundColor = "orange";
    else if (id == 6) el.style.backgroundColor = "pink";
    else if (id == 7) el.style.backgroundColor = "purple";
    else if (id == 8) el.style.backgroundColor = "red";
    else if (id == 9) el.style.backgroundColor = "silver";
    else if (id == 10) el.style.backgroundColor = "white";
    else if (id == 11) el.style.backgroundColor = "yellow";
    console.log(id);
});