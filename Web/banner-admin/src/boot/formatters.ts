import { boot } from "quasar/wrappers";
import * as Formatter from "src/util/Formatters";
import { IFormatters } from "src/util/Formatters";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    $fmt: IFormatters;
  }
}

export default boot(({ app }) => {
  app.config.globalProperties.$fmt = Formatter;
});
