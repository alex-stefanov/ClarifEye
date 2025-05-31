document.addEventListener("DOMContentLoaded", function(){
    const dropDown = document.querySelector('#vision-mode-selector');
    dropDown.addEventListener('change', function(){
        const value = dropDown.value;
        const labEl = document.querySelector('.traffic-file-label');
        const inputEl = document.querySelector('#traffic-file-input');

        console.log(labEl);
        console.log(inputEl);
        labEl.style.display = "block";
    });


});