import { MessageLevel, MyPrivilegeNodeView, UserProfile } from "src/data/dto";
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
  setPrivilegeList(privilegeList: PrivilegeView[]) {
    this.state.privilegeList = privilegeList;
    function createTree(arr: MyPrivilegeNodeView[] = [], hashMap: { [key: string]: MyPrivilegeNodeView } = {}, maxIter = 99999): MyPrivilegeNodeView {
      const rows = arr.slice().sort((a, b) => Number(b.parentFunctionId) - Number(a.parentFunctionId));
      const root = rows.pop() || {} as MyPrivilegeNodeView;
      hashMap[root.id] = root;
      while (maxIter--) {
        const row = rows.pop();
        if (!row) break;
        if (row.id in hashMap) continue;
        if (row?.parentFunctionId in hashMap) {
          hashMap[row.id] = row;
          row.parentNode = hashMap[row?.parentFunctionId];
          hashMap[row?.parentFunctionId].nodes.push(row);
        } else rows.unshift(row);
      }
      for (const row of rows) root.nodes.push(row);
      return root;
    }
    this.state.privilege = createTree(privilegeList.map(x => ({ ...x, nodes: [] })), this.state.privilegeHashMap);
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

  setIsCourseList(payLoad: boolean) {
    this.state.isCourseList = payLoad;
  }

  setCourseId(payLoad: number) {
    this.state.courseId = payLoad;
  }

  addShoppingCartItem(e: { courseId: number }) {
    if (!this.state.shoppingCardState.courseList.some(c => e.courseId === c)) {
      this.state.shoppingCardState.courseList.push(e.courseId);
    }
  }
  removeShoppingCartItem(courseId: number) {
    const xx = this.state.shoppingCardState.courseList.filter(e => e != courseId);
    console.log(xx);
    this.state.shoppingCardState.courseList = this.state.shoppingCardState.courseList.filter(e => e != courseId)
  }

  addTrackingItem(e: number) {
    if (!this.state.shoppingCardState.trackingList.some(c => c === e)) {
      this.state.shoppingCardState.trackingList.push(e);
    }
  }
}
