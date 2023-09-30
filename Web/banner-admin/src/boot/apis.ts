import { boot } from "quasar/wrappers";
import { Apis, IApis } from "src/api/Apis";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    apis: IApis;
  }
}

export default boot(({ app }) => {
  app.config.globalProperties.apis = Apis;
});
