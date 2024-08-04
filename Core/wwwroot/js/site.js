"use strict";
const downloadCVButton = document.querySelector("#cvButton");
if (downloadCVButton) {
    downloadCVButton.addEventListener("click", (e) => downloadResume());
}
function downloadResume() {
    window.location.href = "/Downloads/CV";
}
