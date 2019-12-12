import '../styles/index.scss';
import addAutoResize from '../scripts/pages/dashboard';

document.addEventListener(
    'DOMContentLoaded',
    () => {
        console.info(`I am ready to serve you!`);
        addAutoResize();
    }, {
        passive: true,
        once: true,
    }
);
