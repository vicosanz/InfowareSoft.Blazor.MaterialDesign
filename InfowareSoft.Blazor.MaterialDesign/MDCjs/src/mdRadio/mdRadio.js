import * as styles from './mdRadio.scss';
import { init as InitFormField } from '../mdFormField/mdFormField'
import { MDCRadio } from '@material/radio';

export function init(ref, formFieldRef) {
    this.radio = new MDCRadio(ref);
    if (formFieldRef !== null) {
        this.formField = InitFormField(formFieldRef);
        this.formField.input = this.radio;
    }
}
