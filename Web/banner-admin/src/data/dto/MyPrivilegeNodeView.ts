// TODO: should adjust with api dto

interface PrivilegeNode {
  //
  name: string;
  functionId: string;
  parentFunctionId: string;
}

export interface MyPrivilegeNodeView extends PrivilegeNode {
  parentNode?: MyPrivilegeNodeView;
  onEditing?: boolean;
  isBrandNew?: boolean;
  // override base property
  nodes: MyPrivilegeNodeView[];
}
