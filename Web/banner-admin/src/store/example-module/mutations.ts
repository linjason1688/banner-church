import { Mutations } from "vuex-smart-module";

import ModuleState from "./state";

export default class ModuleMutations extends Mutations<ModuleState> {
  setCount(val: number) {
    this.state.count = val;
  }
}
