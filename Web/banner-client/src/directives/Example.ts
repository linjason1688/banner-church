import { Directive, DirectiveBinding, VNode } from "@vue/runtime-core";

export const Example: Directive = {
  created: function (el: Element, data: DirectiveBinding<unknown>, vnode: VNode) {
    //
    console.log(el, data, vnode);
  },
  mounted: function (el: Element, data: DirectiveBinding<unknown>, vnode: VNode) {
    //
    console.log(el, data, vnode);
  },
  updated: function (el: Element, data: DirectiveBinding<unknown>, vnode: VNode, preVnode: VNode) {
    //
    console.log(el, data, vnode, preVnode);
  },
};
