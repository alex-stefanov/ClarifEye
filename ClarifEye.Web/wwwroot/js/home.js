document.addEventListener("DOMContentLoaded", function () {
    const dropDown = document.querySelector('#vision-mode-selector');
    const fileInput = document.querySelector('#traffic-file-input');
    const form = document.querySelector('.traffic-upload-form');
    const label = document.querySelector('.traffic-file-label');

    let selectedValue = "";

    dropDown.addEventListener('change', function () {
        selectedValue = this.value;
        label.style.display = "block";
    });

    fileInput.addEventListener('change', function () {
        if (!selectedValue) {
            alert("Please select a vision mode before uploading a file.");
            return;
        }
        console.log(selectedValue);
        // Set the action dynamically based on dropdown value
        switch (selectedValue) {
            case "text":
                form.action = "/Detector/TextDetector";
                break;
            case "color":
                form.action = "/Detector/ColorDetector";
                break;
            case "traffic":
                form.action = "/Detector/TrafficLightsDetector";
                break;
            case "scenery":
                form.action = "/Detector/ScenerySynthesizer"
                break;
            default:
                alert("Invalid vision mode selected.");
                return;
        }

        form.submit();
    });
});
