import { Store } from "vuex";
import { Actions } from "vuex-smart-module";

import ModuleGetters from "./getters";
import ModuleMutations from "./mutations";
import ModuleState from "./state";

export default class ModuleActions extends Actions<ModuleState, ModuleGetters, ModuleMutations, ModuleActions> {
  // Declare dependency type
  store: Store<unknown> | undefined;

  // Called after the module is initialized
  $init(store: Store<unknown>): void {
    // Retain store instance for later
    this.store = store;
  }
  incrementAsync(payload: number) {
    return new Promise<void>((rs) => {
      setTimeout(() => {
        this.state.count;
        this.commit("setCount", this.state.count + payload);
        rs();
      }, 1);
    });
  }
}
