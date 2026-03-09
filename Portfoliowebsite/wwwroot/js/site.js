function setupValidation() {
    const form = document.getElementById('contactForm');
    const hp = document.getElementById('website');
    const status = document.getElementById('liveStatus'); 

    if (!form || !hp) {
        return;
    }

    form.addEventListener('submit', (e) => { //testtest
        if (hp.value) {
            e.preventDefault();

            if (status) {
                status.textContent = 'Formulierverzending geblokkeerd.';
            }
        }
    });
}

window.addEventListener('DOMContentLoaded', setupValidation);