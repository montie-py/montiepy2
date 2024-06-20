const createBlogEntryButton = document.querySelector("#addBlogEntry") as HTMLInputElement

if (createBlogEntryButton) {
    createBlogEntryButton.addEventListener("click", (e:Event) => jumpToNewBlogEntryPage(createBlogEntryButton));
}

function jumpToNewBlogEntryPage(createBlogEntryButton:HTMLInputElement) {
    window.location.href = <string>createBlogEntryButton.getAttribute("attr-url");
}
