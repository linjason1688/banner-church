import { PrivilegeView, SystemConfigView } from "src/api/feature";
import {
  AppMessage,
  MyPrivilegeNodeView,
  UserProfile,
} from "src/data/dto";
import { ChildSignUpState } from "src/data/dto/ChildSignUpState";
import { ShoppingCartState } from "src/data/dto/ShoppingCartState";
import { SignUpState } from "src/data/dto/SignUpState";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

export default class ModuleState {
  count: number = 0;
  initialized: boolean = false;
  userProfile: UserProfile = { id: 1, account: "" } as UserProfile;
  privilege?: MyPrivilegeNodeView;
  privilegeHashMap: { [key: string]: MyPrivilegeNodeView } = {};
  privilegeList: PrivilegeView[] = [];
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

  isCourseList: boolean = true;

  courseId: number = 0;

  shoppingCardState: ShoppingCartState = { courseList: [], trackingList: [] } as ShoppingCartState;
}
