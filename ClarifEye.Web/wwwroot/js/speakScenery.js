document.addEventListener("DOMContentLoaded", function () {
    const span = document.querySelector('.speaker-icon');
    span.addEventListener('click', function () {
        const text = document.querySelector('#text').value;
        console.log(text)
        const audio = document.getElementById('ttsPlayer');
        const encodedText = encodeURIComponent(text);
        const url = `/scenerysynthesizer/speak/${encodedText}?voice=nova`;

        audio.src = url;
        audio.play();
    });
