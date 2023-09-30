import { PrivilegeView } from "src/api/feature";

export interface MyPrivilegeNodeView extends PrivilegeView {
  parentNode?: MyPrivilegeNodeView;
  onEditing?: boolean;
  isBrandNew?: boolean;
  // override base property
  nodes: MyPrivilegeNodeView[];
}
