import { Apis } from "src/api/Apis";
import { UserProfile } from "src/data/dto";
import { MyLogger } from "src/util";
import { Store } from "vuex";
import { Actions } from "vuex-smart-module";

import ModuleGetters from "./getters";
import ModuleMutations from "./mutations";
import ModuleState from "./state";
import { SystemConfigView } from "src/api/feature";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const mgrApi = Apis.management;
const featApi = Apis.feature;

/**
 * fore t
 */
export default class ModuleActions extends Actions<ModuleState, ModuleGetters, ModuleMutations, ModuleActions> {
  // Declare dependency type
  store: Store<unknown> | undefined;

  // Called after the module is initialized
  $init(store: Store<unknown>): void {
    // Retain store instance for later
    this.store = store;
  }

  /**
   * app init setup
   */
  async setupAsync() {
    const version = await featApi.appMetrics.getAppVersionAsync();
    MyLogger.debug(version.data);

    const res = await featApi.systemConfig.findConfig();
    this.mutations.setSystemConfigState(res.data);
    const configs = new Map<string, Array<SystemConfigView>>();
    for (const e of res.data) {
      if (!configs.has(e.type)) {
        configs.set(e.type, new Array<SystemConfigView>());
      }
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-ignore
      configs.get(e.type).push(e);
    }
    this.mutations.setSystemConfigs(configs);
  }

  async loadUserProfileAsync() {
    // profile
    // const res = await mgrApi.authenticate.fetchProfileAsync();
    // this.mutations.setUserProfile(uRes.data as unknown as UserProfile);
  }

  async prepareUserAsync() {
    // TODO: loading data here
    const myPrivilegesResult = (await featApi.auth.fetchMyPrivilegesAsync()).data;
    const myPrivileges = myPrivilegesResult.filter(myPrivilege => {
      return myPrivilege.parentKey === ""
    });
    
    this.mutations.setPrivilegeList(myPrivileges);
    this.mutations.setInitialized(true);
  }

  async loginAsync(payLoad: UserProfile) {
    return await Promise.resolve(payLoad);
  }

  async logoutAsync() {
    // try {
    //   await mgrApi.authenticate.signOutAsync();
    // } finally {
    //   this.mutations.setUserProfile({} as UserProfile);
    //   this.mutations.setPrivilege({} as MyPrivilegeNodeView);
    // }
  }

  /**
   * return type infer won't work
   * @returns Promise<number>
   */
  incrementCountAsync(): Promise<number> {
    this.mutations.setCount(this.state.count + 1);
    return Promise.resolve(this.state.count);
  }
}
