import { boot } from "quasar/wrappers";
import * as Directives from "src/directives";

export default boot(({ app }) => {
  app.directive("example", Directives.Example);
  app.directive("p-guard", Directives.PrivilegeGuard);
});
