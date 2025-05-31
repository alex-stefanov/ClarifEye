document.addEventListener("DOMContentLoaded", function () {
    const span = document.querySelector('.speaker-icon');
    span.addEventListener('click', function () {
        const text = document.querySelector('#text').value;
        console.log(text)
        const audio = document.getElementById('ttsPlayer');
        const encodedText = encodeURIComponent(text);
        const url = `/textdetector/speak/${encodedText}?voice=nova`;

        audio.src = url;
        audio.play();
    });

    const translateBtn = document.getElementById('translateBtn');
    translateBtn.addEventListener('click', function () {
        const text = document.getElementById('text').value;
        const language = document.getElementById('languageSelect').value;
        const encodedText = encodeURIComponent(text);

        window.location.href = `/textdetector/translate?text=${encodedText}&language=${language}`;
    });
});