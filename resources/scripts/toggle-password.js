export default function () {
    document.querySelector(".password-show").addEventListener("click", (e) => {
        const password = document.querySelector("[data-password]");
        if (password.type === "password") {
            password.type = "text";
            e.target.innerText = "HIDE";
        } else {
            password.type = "password";
            e.target.innerText = "SHOW";
        }
    })
    console.log("smile");
}
