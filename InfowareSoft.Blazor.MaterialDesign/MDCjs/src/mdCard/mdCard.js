import './mdCard.scss';
import { MDCRipple } from '@material/ripple';

export class MDCardPrimaryAction extends MDCRipple {
    constructor(ref) {
        super(ref);
    }
};

export function initPrimaryAction(ref) {
    new MDCardPrimaryAction(ref);
}
