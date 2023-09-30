import { createComposable, Module } from "vuex-smart-module";

import ModuleActions from "./actions";
import ModuleGetters from "./getters";
import ModuleMutations from "./mutations";
import ModuleState from "./state";

export interface ExampleModule {
  state: ModuleState;
  getters: ModuleGetters;
  mutations: ModuleMutations;
  actions: ModuleActions;
}

export { ModuleState as ExampleModuleState };

export const exampleModule = new Module({
  state: ModuleState,
  getters: ModuleGetters,
  mutations: ModuleMutations,
  actions: ModuleActions,
});

// for composition api
export const useExampleStore = createComposable(exampleModule);
