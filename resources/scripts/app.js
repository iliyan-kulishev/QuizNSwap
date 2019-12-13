import '../styles/index.scss';
import game from './pages/game.js';

document.addEventListener(
    'DOMContentLoaded',
    () => {
        console.info(`I am ready to serve you!`);

        game();
    },
    {
        passive: true,
        once: true,
    }
);
