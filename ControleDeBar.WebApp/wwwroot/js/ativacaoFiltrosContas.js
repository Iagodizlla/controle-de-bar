document.addEventListener("DOMContentLoaded", function () {Add commentMore actions
    const params = new URLSearchParams(window.location.search);
    const status = params.get("status");

    const botoesFiltro = document.querySelectorAll('.btn-filtro');

    for (const btn of botoesFiltro) {
        const href = btn.getAttribute('href') || "";

        // Destaca "Todas as contas" se não houver filtro
        if (
            (status === null && !href.includes("status=")) ||
            (status === "abertas" && href.includes("status=abertas")) ||
            (status === "fechadas" && href.includes("status=fechadas"))
        ) {
            btn.classList.remove('btn-outline-primary');
            btn.classList.add('btn-primary');
        } else {
            btn.classList.remove('btn-primary');
            btn.classList.add('btn-outline-primary');
        }
    }
});