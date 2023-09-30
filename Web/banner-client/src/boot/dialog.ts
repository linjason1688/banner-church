/**
 * dont import more than one quasar plugin
 * no idea why why quasar cant import Notify & Dialog in the same file... it causes compilation error
 */

import { Dialog } from "quasar";
import { boot } from "quasar/wrappers";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    showConfirmDialogAsync: (title: string, message: string, ok?: string, cancel?: string) => Promise<boolean>;
  }
}

export default boot(({ app }) => {
  const extensions = {
    showConfirmDialogAsync: function (title: string, message: string, ok?: string, cancel?: string): Promise<boolean> {
      return new Promise((rs) => {
        Dialog.create({
          title,
          message,
          focus: "none",
          persistent: true,
          ok: {
            label: ok || "確定",
            color: "primary",
            flat: true,
            rounded: true,
          },
          cancel: {
            label: cancel || "取消",
            color: "grey-6",
            flat: true,
            rounded: true,
          },
        })
          .onOk(() => {
            return rs(true);
          })
          .onCancel(() => {
            return rs(false);
          });
      });
    },
  };

  Object.assign(app.config.globalProperties, extensions);
});
