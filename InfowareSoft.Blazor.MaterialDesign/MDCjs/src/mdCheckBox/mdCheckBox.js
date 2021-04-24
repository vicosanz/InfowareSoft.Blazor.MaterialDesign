import { init as InitFormField } from '../mdFormField/mdFormField'
import { MDCCheckbox } from '@material/checkbox';

export function init(ref, formFieldRef, indeterminate) {
    this.checkbox = new MDCCheckbox(ref);
    if (formFieldRef !== null) {
        this.formField = InitFormField(formFieldRef);
        this.formField.input = this.checkbox;
        this.checkbox.indeterminate = indeterminate;
    }
}
