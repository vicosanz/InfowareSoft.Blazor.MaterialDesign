import './mdLinearProgress.scss';
import { MDCLinearProgress } from '@material/linear-progress';

export function init(ref) {
    ref.instance = new MDCLinearProgress(ref);
}

export function setProgress(ref, value) {
    ref.instance.foundation_.setProgress(value);
}

export function setBuffer(ref, value) {
    ref.instance.foundation_.setBuffer(value);
}
