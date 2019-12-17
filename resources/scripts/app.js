import '../styles/index.scss';
import addAutoResize from '../scripts/pages/dashboard';
import passwordToggler from './toggle-password';
import game from './pages/game.js';

document.addEventListener(
    'DOMContentLoaded',
    () => {
        console.info(`Resources loaded!`);
        addAutoResize();
        passwordToggler();
        game();
    },
    {
        passive: true,
        once: true,
    }
);
