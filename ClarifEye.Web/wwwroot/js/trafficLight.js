document.addEventListener('DOMContentLoaded', function() {
    let id = document.getElementById('trafficLightValue').value;
    
    let light = "";
    if (id == 0){
        light = document.querySelector('.red');
        light.style.backgroundColor = "red";
    } else if (id == 1){
        light = document.querySelector('.green');
        light.style.backgroundColor = "#90EE90";
    } else if (id == 2){
        light = document.querySelector('.yellow');
        light.style.backgroundColor = "yellow";
    }
});