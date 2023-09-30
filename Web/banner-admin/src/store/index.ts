//  https://github.com/ktsn/vuex-smart-module

import { InjectionKey } from "vue";

import { store } from "quasar/wrappers";
import { appModule, AppModuleState } from "src/store/app-module";
import { exampleModule, ExampleModuleState } from "src/store/example-module";
import { createLogger, Store as VuexStore, useStore as vuexUseStore } from "vuex";
import { createStore, hotUpdate, Module } from "vuex-smart-module";

// https://github.com/ktsn/vuex-smart-module

// usage in components
// import { exampleModule } from "src/store/example-module";
//  const store = exampleModule.context(this.$store);

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Store instance.
 */

export interface StateInterface {
  // Define your own store structure, using submodules if needed
  // example: ExampleStateInterface;
  // Declared as unknown to avoid linting issue. Best to strongly type as per the line above.
  example: ExampleModuleState;
  app: AppModuleState;
}

// provide typings for `this.$store`
declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    $store: VuexStore<StateInterface>;
  }
}

// provide typings for `useStore` helper
export const storeKey: InjectionKey<VuexStore<StateInterface>> = Symbol("vuex-key");

export default store(function (/* { ssrContext } */) {
  const isDev = !!process.env.DEBUGGING;

  const rootModule = new Module({
    namespaced: true,
    modules: {
      example: exampleModule,
      app: appModule,
    },
  });

  const Store = createStore(rootModule, {
    // enable strict mode (adds overhead!)
    // for dev mode and --debug builds only
    strict: isDev,
    plugins: isDev //
      ? [createLogger({})]
      : [],
  });

  // hot reload support
  if (module.hot) {
    // accept actions and mutations as hot modules
    module.hot.accept(
      [
        //
        "./example-module",
        // add your modules here
        "./app-module",
      ],
      () => {
        // require the updated modules

        const newRootModule = new Module({
          namespaced: true,
          modules: {
            example: exampleModule,
          },
        });

        // swap in the new root module by using `hotUpdate` provided from vuex-smart-module.
        hotUpdate(Store, newRootModule);
      }
    );
  }

  return Store;
});

export function useStore() {
  return vuexUseStore(storeKey);
}
