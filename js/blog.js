const buttons = document.querySelectorAll(".read-more");

buttons.forEach(button => {
    button.addEventListener("click", () => {
        const article = button.closest(".blog-post");
        const extraText = article.querySelector(".blog-extra");

        extraText.classList.toggle("hidden");

        if (extraText.classList.contains("hidden")) {
            button.textContent = "Read more";
        } else {
            button.textContent = "Show less";
        }
    });
});