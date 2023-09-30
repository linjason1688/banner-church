import { PrivilegeView, SystemConfigView } from "src/api/feature";
import {
  AppMessage,
  HashMap,
  UserProfile
} from "src/data/dto";
import { ChildSignUpState } from "src/data/dto/ChildSignUpState";
import { SignUpState } from "src/data/dto/SignUpState";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

export default class ModuleState {
  count = 0;
  dev = true;
  initialized = false;
  userProfile: UserProfile = {
    account: "mock",
  } as UserProfile;
  privilege?: PrivilegeView;
  privilegeHashMap: HashMap<PrivilegeView> = {};
  privilegeList: Array<PrivilegeView> = [];
  appMessages: Array<AppMessage> = [];
  /**
   * 註冊流程狀態
   */
  signUpState: SignUpState = {} as SignUpState;
  /**
   * 12歲以下註冊流程狀態
   */
  childSignUpState: ChildSignUpState = {} as ChildSignUpState;

  systemConfigState: Array<SystemConfigState> = [] as Array<SystemConfigState>;

  systemConfigs: Map<string, Array<SystemConfigView>> = new Map<string, Array<SystemConfigView>>();
}
