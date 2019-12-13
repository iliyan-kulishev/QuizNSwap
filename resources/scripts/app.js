import '../styles/index.scss';
import addAutoResize from '../scripts/pages/dashboard';
import passwordToggler from './toggle-password'

document.addEventListener(
    'DOMContentLoaded',
    () => {
        console.info(`I am ready to serve you!`);
        addAutoResize();
        passwordToggler();

    }, {
        passive: true,
        once: true,
    }
);
