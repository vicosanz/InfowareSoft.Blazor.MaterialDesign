import { MDCDrawer } from '@material/drawer';

export function init(ref) {
    ref.instance = MDCDrawer.attachTo(ref);
};
