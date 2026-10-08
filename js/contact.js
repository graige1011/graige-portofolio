const form = document.querySelector("#contact-form");

const nameInput = document.querySelector("#name");
const emailInput = document.querySelector("#email");
const messageInput = document.querySelector("#message");

const nameError = document.querySelector("#name-error");
const emailError = document.querySelector("#email-error");
const messageError = document.querySelector("#message-error");

const successMessage = document.querySelector("#success-message");

const clearMessages = () => {
    nameError.textContent = "";
    emailError.textContent = "";
    messageError.textContent = "";
    successMessage.textContent = "";
};

const validateName = () => {
    if (nameInput.value.trim() === "") {
        nameError.textContent = "Please enter your name.";
        return false;
    }

    return true;
};

const validateEmail = () => {
    const email = emailInput.value.trim();

    if (email === "") {
        emailError.textContent = "Please enter your email address.";
        return false;
    }

    if (!email.includes("@") || !email.includes(".")) {
        emailError.textContent = "Please enter a valid email address.";
        return false;
    }

    return true;
};

const validateMessage = () => {
    if (messageInput.value.trim().length < 10) {
        messageError.textContent =
            "Your message must contain at least 10 characters.";

        return false;
    }

    return true;
};

form.addEventListener("submit", event => {
    event.preventDefault();

    clearMessages();

    const nameIsValid = validateName();
    const emailIsValid = validateEmail();
    const messageIsValid = validateMessage();

    if (nameIsValid && emailIsValid && messageIsValid) {
        successMessage.textContent =
            "Thank you! Your message was entered successfully.";

        form.reset();
    }
});