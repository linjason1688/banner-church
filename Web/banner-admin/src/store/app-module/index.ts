import { createComposable, Module } from "vuex-smart-module";

import ModuleActions from "./actions";
import ModuleGetters from "./getters";
import ModuleMutations from "./mutations";
import ModuleState from "./state";

export interface AppModule {
  state: ModuleState;
  getters: ModuleGetters;
  mutations: ModuleMutations;
  actions: ModuleActions;
}

export { ModuleState as AppModuleState };

export const appModule = new Module({
  state: ModuleState,
  getters: ModuleGetters,
  mutations: ModuleMutations,
  actions: ModuleActions,
});

// for composition api
export const useExampleStore = createComposable(appModule);
