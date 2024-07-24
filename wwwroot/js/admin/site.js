"use strict";
const createBlogEntryButton = document.querySelector("#addBlogEntry");
const createReviewEntryButton = document.querySelector("#addReviewEntry");
if (createBlogEntryButton) {
    createBlogEntryButton.addEventListener("click", (e) => jumpToNewEntryPage(createBlogEntryButton));
}
if (createReviewEntryButton) {
    createReviewEntryButton.addEventListener("click", (e) => jumpToNewEntryPage(createReviewEntryButton));
}
function jumpToNewEntryPage(createBlogEntryButton) {
    window.location.href = createBlogEntryButton.getAttribute("attr-url");
}
