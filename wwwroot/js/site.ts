
const downloadCVButton = document.querySelector("#cvButton");
if (downloadCVButton) {
    downloadCVButton.addEventListener("click", (e:Event) => downloadResume());
}

function downloadResume() {
    window.location.href = "/Downloads/CV";
}