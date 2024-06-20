"use strict";
const createBlogEntryButton = document.querySelector("#addBlogEntry");
if (createBlogEntryButton) {
    createBlogEntryButton.addEventListener("click", (e) => jumpToNewBlogEntryPage(createBlogEntryButton));
}
function jumpToNewBlogEntryPage(createBlogEntryButton) {
    window.location.href = createBlogEntryButton.getAttribute("attr-url");
}
