import { boot } from "quasar/wrappers";
import { Sleep } from "src/util";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    sleep: (ms: number) => Promise<number>;
  }
}

export default boot(({ app }) => {
  const extensions = {
    sleep: Sleep,
  };

  Object.assign(app.config.globalProperties, extensions);
});
