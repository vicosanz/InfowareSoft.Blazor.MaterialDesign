import './mdList.scss';
import { MDCList } from '@material/list';
import { MDCRipple } from '@material/ripple';

export function init(ref) {
    const list = new MDCList(ref);
    ref.instance = list;
    list.listElements.map((listItemEl) => new MDCRipple(listItemEl));
    list.singleSelection = true;
}

export function onActionItem(ref, component) {
    ref.addEventListener('MDCList:action', (e) => {
        var result = e.srcElement.instance.foundation_.getSelectedIndex();
        if ("number" == typeof result) {
            result = [result];
        }
        component.invokeMethodAsync('ActionItemHandler', e.detail.index, result);
    });
}

export function setSelectedIndex(ref, index) {
    ref.instance.foundation_.setSelectedIndex(index);
}

export function setWrapFocus(ref, state) {
    ref.instance.wrapFocus = state;
}

