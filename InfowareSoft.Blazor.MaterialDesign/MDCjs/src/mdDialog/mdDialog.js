import * as styles from './mdDialog.scss';
import { MDCDialog } from '@material/dialog';

export function init(ref) {
    ref.instance = new MDCDialog(ref);
};

export function onEventsListener(ref, component) {
    ref.addEventListener('MDCDialog:closed', () => {
        component.invokeMethodAsync('ClosedHandler');
    });
    ref.addEventListener('MDCDialog:opened', () => {
        component.invokeMethodAsync('OpenedHandler');
    });
}

export function isOpen(ref, open) {
    if (open) {
        ref.instance.open();
    }
    else {
        ref.instance.close();
    }
}

export function setCanBeClosed(ref, canClose) {
    if (canClose) {
        ref.instance.escapeKeyAction = "close";
        ref.instance.scrimClickAction = "close";
    } else {
        ref.instance.escapeKeyAction = "";
        ref.instance.scrimClickAction = "";
    }
}