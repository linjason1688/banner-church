import { Loading } from "quasar";
import { boot } from "quasar/wrappers";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    showLoading: () => void;
    hideLoading: () => void;
  }
}

Loading.setDefaults({
  backgroundColor: "transparent",
  spinnerColor: "primary",
  spinnerSize: 50,
});

const extensions = {
  showLoading: function () {
    Loading.show();
  },

  hideLoading: function () {
    Loading.hide();
  },
};

export const LoadingUtil = extensions;

export default boot(({ app }) => {
  // config

  Object.assign(app.config.globalProperties, extensions);
});
