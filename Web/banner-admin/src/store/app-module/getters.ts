import { Getters } from "vuex-smart-module";

import ModuleState from "./state";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

export default class ModuleGetters extends Getters<ModuleState> {
  get count() {
    return this.state.count;
  }

  get isAuthorized() {
    const profile = this.state.userProfile;
    return !!profile && !!profile.account && this.state.initialized;
  }

  get userProfile() {
    return this.state.userProfile;
  }

  get privilegeNode() {
    return this.state.privilege || { nodes: [] };
  }

  /**
   * 註冊流程狀態
   */
  get signUpState() {
    return this.state.signUpState;
  }

  get childSignUpState() {
    return this.state.childSignUpState;
  }

  getSystemConfig(key: string): Array<SystemConfigState> {
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    // @ts-ignore
    return this.state.systemConfigs.get(key);
  }
}
