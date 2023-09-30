import { route } from "quasar/wrappers";
import { LoadingUtil } from "src/boot/loading";
import { appModule } from "src/store/app-module";
import { MyLocalStorage } from "src/util";
import { createMemoryHistory, createRouter, createWebHashHistory, createWebHistory } from "vue-router";
import { Store } from "vuex";

import { StateInterface } from "../store";
import routes from "./routes";

/*
 * If not building with SSR mode, you can
 * directly export the Router instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Router instance.
 */

export default route<StateInterface>(function ({ store }) {
  const createHistory = process.env.SERVER
    ? createMemoryHistory
    : process.env.VUE_ROUTER_MODE === "history"
    ? createWebHistory
    : createWebHashHistory;

  const Router = createRouter({
    scrollBehavior: () => ({ left: 0, top: 0 }),
    routes,

    // Leave this as is and make changes in quasar.conf.js instead!
    // quasar.conf.js -> build -> vueRouterMode
    // quasar.conf.js -> build -> publicPath
    history: createHistory(process.env.MODE === "ssr" ? void 0 : process.env.VUE_ROUTER_BASE),
  });

  //  loading effect
  Router.beforeEach((to, from, next) => {
    // inject store
    //  to.meta["$STORE$"] = store;
    LoadingUtil.showLoading();

    const authorizedRoute = to.matched.some((m) => m.name === "authorized");

    // home 為 authorizedRoute 底下的特例
    if (!authorizedRoute || to.name?.toString().includes("Home")) {
      next();

      MyLocalStorage.activeNode.setItem({
        functionId: "",
        parentFunctionId: "",
      });

      return;
    }

    const appStore = appModule.context(store);
    if (authorizedRoute && !appStore.getters.isAuthorized) {
      next({
        name: "Login",
        params: {
          path: to.fullPath,
        },
      });
    }

    // inject from global router
    // eslint-disable-next-line
    const node = getPrivilegeNode(store, to);

    // TODO: 檢查是否有權限存取

    next();
  });

  Router.afterEach(() => {
    // document.title = guard.meta["title"] as string;
    LoadingUtil.hideLoading();
  });

  function getPrivilegeNode(store: Store<unknown>, to: { name: unknown }) {
    const appStore = appModule.context(store);
    const map = appStore.state.privilegeHashMap;

    const functionId = ((to.name as string) || "___$VOID$____").toString();
    // const functionId = ("test" || "___$VOID$____").toString();
    const node = map[functionId];

    return node;
  }

  return Router;
});
