import { Getters } from "vuex-smart-module";

import ModuleState from "./state";

export default class ModuleGetters extends Getters<ModuleState> {
  get count() {
    return this.state.count;
  }
}
