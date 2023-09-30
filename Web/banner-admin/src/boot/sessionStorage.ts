// this file dont import any quasar plugins
import { SessionStorage } from "quasar";
import { boot } from "quasar/wrappers";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    sessionStorage: SessionStorage;
  }
}

export default boot(({ app }) => {
  const extensions = {
    sessionStorage: SessionStorage,
  };

  Object.assign(app.config.globalProperties, extensions);
});
