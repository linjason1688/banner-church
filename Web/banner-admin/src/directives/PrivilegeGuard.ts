/* eslint-disable @typescript-eslint/no-unused-vars */
import { ComponentBase } from "src/components";
import { MyLogger } from "src/util";

import { Directive, DirectiveBinding, VNode } from "@vue/runtime-core";

export const PrivilegeGuard: Directive = {
  created: function (el: Element, data: DirectiveBinding<string>, vnode: VNode) {
    //
    const instance = data.instance as ComponentBase;
    let hide = true;
    const node = instance.$privilege;
    try {
      if (!node || !node.nodes) {
        return;
      }

      //  我們只確認目前功能底下的子功能，若子功能在別的頁面並非綁在此 node 下，則視無權限，應於該頁面之 node 底下建立新的子功能
      hide = !node.nodes.some((n) => n.functionId === data.value);
    } catch (error) {
      MyLogger.warn("PrivilegeGuard", error);
    } finally {
      // default to hide
      if (hide) {
        el.setAttribute("style", "display:none");
        console.warn(
          `Invalid privilege: ${data.value}, route: ${node.functionId}, available: ${node.nodes
            .map((n) => n.functionId)
            .join(",")}`
        );
      }
    }
  },

  mounted: function (el: Element, data: DirectiveBinding<string>, vnode: VNode) {
    //
  },
  updated: function (el: Element, data: DirectiveBinding<string>, vnode: VNode, preVnode: VNode) {
    //
  },
};
