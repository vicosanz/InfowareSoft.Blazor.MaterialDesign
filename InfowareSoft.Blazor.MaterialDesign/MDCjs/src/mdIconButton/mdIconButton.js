import { MDCRipple } from '@material/ripple';

export class MDIconButton extends MDCRipple {
    constructor(ref) {
        super(ref);
        this.unbounded = true;
    }
}

export function init(ref) {
    var button = new MDIconButton(ref);
}
