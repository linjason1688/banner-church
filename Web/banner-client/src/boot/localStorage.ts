// this file dont import any quasar plugins
import { LocalStorage } from "quasar";
import { boot } from "quasar/wrappers";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    localStorage: LocalStorage;
  }
}

export default boot(({ app }) => {
  const extensions = {
    localStorage: LocalStorage,
  };

  Object.assign(app.config.globalProperties, extensions);
});
