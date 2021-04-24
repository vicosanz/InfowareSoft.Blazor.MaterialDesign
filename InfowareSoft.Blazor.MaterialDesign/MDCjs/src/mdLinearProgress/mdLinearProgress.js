import { MDCLinearProgress } from '@material/linear-progress';

export function init(ref) {
    ref.instance = new MDCLinearProgress(ref);
}

export function setProgress(ref, value) {
    ref.instance.foundation.setProgress(value);
}

export function setBuffer(ref, value) {
    ref.instance.foundation.setBuffer(value);
}
