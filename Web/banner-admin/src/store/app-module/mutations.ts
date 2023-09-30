import { MessageLevel, UserProfile } from "src/data/dto";
import { MyDateTime } from "src/util";
import { Mutations } from "vuex-smart-module";

import ModuleState from "./state";
import { SignUpState } from "src/data/dto/SignUpState";
import { ChildSignUpCommand, PrivilegeView, SystemConfigView } from "src/api/feature";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

export default class ModuleMutations extends Mutations<ModuleState> {
  setCount(val: number) {
    this.state.count = val;
  }

  /**
   *
   * @param state
   * @param payLoad
   */
  setInitialized(payLoad: boolean) {
    this.state.initialized = payLoad;
  }

  /**
   *
   * @param state
   * @param payLoad
   */
  setUserProfile(payLoad: UserProfile) {
    this.state.userProfile = payLoad;
  }

  /**
   *
   * @param payLoad
   */
  addAppMessage(payLoad: { message: string; level: MessageLevel }) {
    this.state.appMessages.push({
      id: new Date().getTime(),
      message: payLoad.message,
      ocurredAt: new MyDateTime(new Date()).toFullDateTime(),
      level: payLoad.level,
    });
  }

  /**
   * 註冊流程狀態
   * @param signUpState
   */
  setSignUpState(signUpState: SignUpState) {
    this.state.signUpState = signUpState;
  }

  setChildSignUpState(childSignUpState: ChildSignUpCommand) {
    this.state.childSignUpState = childSignUpState;
  }

  setSystemConfigState(systemConfigState: Array<SystemConfigState>) {
    this.state.systemConfigState = systemConfigState;
  }

  setSystemConfigs(systemConfigs: Map<string, Array<SystemConfigView>>) {
    this.state.systemConfigs = systemConfigs;
  }
  setPrivilegeList(privilegeList: PrivilegeView[]){
    this.state.privilegeList = privilegeList;
  }
}
