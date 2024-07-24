const createBlogEntryButton = document.querySelector("#addBlogEntry") as HTMLInputElement
const createReviewEntryButton = document.querySelector("#addReviewEntry") as HTMLInputElement

if (createBlogEntryButton) {
    createBlogEntryButton.addEventListener("click", (e:Event) => jumpToNewEntryPage(createBlogEntryButton));
}

if (createReviewEntryButton) {
    createReviewEntryButton.addEventListener("click", (e:Event) => jumpToNewEntryPage(createReviewEntryButton));
}

function jumpToNewEntryPage(createBlogEntryButton:HTMLInputElement) {
    window.location.href = <string>createBlogEntryButton.getAttribute("attr-url");
}
