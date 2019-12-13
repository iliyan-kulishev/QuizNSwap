/**
 * Add love to the game play page
 */
export default () => {
    const form = document.querySelector('form');

    const notify = message => {
        const el = document.querySelector('[data-notification]');

        if (!el) {
            console.info('Message from game play', message);
        }

        el.innerText = message;
    };

    const login = document.querySelector('[data-login]');
    const wait = document.querySelector('[data-wait]');
    const play = document.querySelector('[data-play]');

    const switchView = view => {
        [login, wait, play].map(v => (v.style.display = 'none'));
        const views = {
            login,
            wait,
            play,
        };
        views[view].style.display = '';
    };
    window.switchView = switchView;

    if (!form) {
        return;
    }

    form.onsubmit = event => {
        event.preventDefault();
        const data = formDataToJSON(event.target);

        fetch(form.action, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
        })
            .then(r => r.json())
            .then(res => {
                notify(res);
                if (res == 'Player added') {
                    switchView(wait);
                }
            })
            .catch(console.error);
    };
};

function establishConnection(id = null) {
    const url = `wss:://${location.href}`;
    const ws = new WebSocket(url);

    ws.addEventListener('close', () => {
        // Re-Open connection
    });
}

/**
 * Generate JSON data structure from form
 * @param {HTMLFormElement} form Form Element
 */
function formDataToJSON(form) {
    return Array.from(form).reduce((object, input) => {
        if (input.nodeName === 'INPUT') {
            object[input.name] = input.value;
        }
        return object;
    }, {});
}
