
const $deleteArea = document.querySelector(".deleteArea");

$deleteArea.addEventListener("click", async e => {
    if(e.target.classList.contains("js-delete")) {
        e.preventDefault();
        let Id = e.target.getAttribute("data-Id");
        console.log(Id);
        await fetch(`/Test/Delete/${Id}`, { method: "POST" });
        window.location.reload();
    }
})