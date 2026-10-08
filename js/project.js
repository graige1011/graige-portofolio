const projects = [
    {
        title: "TourGuide App",
        category: "Tourism",
        description: "An app that helps tourists discover attractions and activities."
    },
    {
        title: "Baseball Stats App",
        category: "Baseball",
        description: "A simple application for viewing baseball players and statistics."
    },
    {
        title: "PC Builder Helper",
        category: "Computers",
        description: "A website that helps beginners understand computer components."
    }
];

const projectContainer = document.querySelector("#projects");
const filterButtons = document.querySelectorAll(".filters button");

const renderProjects = projectList => {
    projectContainer.textContent = "";

    projectList.forEach(project => {
        const article = document.createElement("article");
        article.classList.add("project-card");

        const title = document.createElement("h3");
        title.textContent = project.title;

        const category = document.createElement("p");
        category.textContent = `Category: ${project.category}`;

        const description = document.createElement("p");
        description.textContent = project.description;

        article.appendChild(title);
        article.appendChild(category);
        article.appendChild(description);

        projectContainer.appendChild(article);
    });
};

const filterProjects = category => {
    if (category === "All") {
        renderProjects(projects);
        return;
    }

    const filteredProjects = projects.filter(
        project => project.category === category
    );

    renderProjects(filteredProjects);
};

filterButtons.forEach(button => {
    button.addEventListener("click", () => {
        filterProjects(button.dataset.category);
    });
});

renderProjects(projects);