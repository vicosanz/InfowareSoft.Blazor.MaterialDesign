import * as styles from './mdList.scss';
import { MDCList } from '@material/list';
import { MDCRipple } from '@material/ripple';

export function init(ref) {
    const list = new MDCList(ref);
    ref.instance = list;
    list.listElements.map((listItemEl) => new MDCRipple(listItemEl));
}
