import { Notify } from "quasar";
import { boot } from "quasar/wrappers";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    showSuccessNotify: (message: string) => void;
    showWarnNotify: (message: string) => void;
    showInfoNotify: (message: string) => void;
    showErrorNotify: (message: string) => void;
  }
}

// config
Notify.setDefaults({
  timeout: 5000,
  position: "bottom-right",
  badgeColor: "warning",
});

export default boot(({ app }) => {
  const extensions = {
    showSuccessNotify: function (message: string) {
      Notify.create({
        color: "positive",
        message: message,
      });
    },

    showWarnNotify: function (message: string) {
      Notify.create({
        color: "warning",
        message: message,
        textColor: "dark",
      });
    },
    showInfoNotify: function (message: string) {
      Notify.create({
        color: "info",
        message: message,
      });
    },
    showErrorNotify: function (message: string) {
      Notify.create({
        color: "negative",
        message: message,
      });
    },
  };

  Object.assign(app.config.globalProperties, extensions);
});
