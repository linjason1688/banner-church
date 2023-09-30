import { axiosInstance } from "src/api/AxiosInstance";
import {
  AppMetricsApi,
  AuthApi,
  ChildApi,
  CourseApi,
  CourseAppendixApi,
  CourseManagementApi,
  CourseManagementAppendixApi,
  CourseManagementFilterApi,
  CourseManagementFilterCourseApi,
  CourseManagementFilterPastoralApi,
  CourseManagementFilterRespApi,
  CourseManagementFilterUserApi,
  CourseManagementTypeApi,
  CourseOrganizationApi,
  CoursePriceApi,
  CourseTimeScheduleApi,
  CourseTimeScheduleTeacherApi,
  CourseTimeScheduleUserApi,
  DeptApi,
  FileApi,
  MeetingPointApi,
  MembershipApi,
  MessageInformationApi,
  MessageInformationUserApi,
  MinistryApi,
  MinistryDefApi,
  MinistryMeetingApi,
  MinistryMeetingUserApi,
  MinistryRecordApi,
  MinistryRespApi,
  MinistryRespUserApi,
  MinistryScheduleApi,
  OrganizationApi,
  PastoralApi,
  PastoralMeetingApi,
  PastoralMeetingUserApi,
  PrivilegeApi,
  QrCodeApi,
  QuestionnaireApi,
  QuestionnaireDetailApi,
  RoleApi,
  RolePrivilegeMappingApi,
  RoleUserMappingApi,
  ShoppingCartApi,
  ShoppingOrderApi,
  ShoppingOrderDetailApi,
  ShoppingTrackApi,
  SystemConfigApi,
  TeacherApi,
  TestApi,
  UserApi,
  UserCourseApi,
  UserFamilyApi,
  UserPastoralCareApi,
  UserQuestionnaireApi,
  UserSocietyApi,
} from "src/api/feature";
import { AppLogMgrApi, PrivilegeMgrApi, RoleMgrApi, UserMgrApi } from "src/api/management/api";

const basePath = "";

const config = {
  isJsonMime: (mime: string) => mime.indexOf("json") !== -1,
};

export interface IApis {
  management: {
    appLog: AppLogMgrApi;
    privilege: PrivilegeMgrApi;
    role: RoleMgrApi;
    user: UserMgrApi;
  };
  feature: {
    //
    appMetrics: AppMetricsApi;
    auth: AuthApi;
    child: ChildApi;
    course: CourseApi;
    courseAppendix: CourseAppendixApi;
    courseManagement: CourseManagementApi;
    courseManagementAppendix: CourseManagementAppendixApi;
    courseManagementFilter: CourseManagementFilterApi;
    courseManagementFilterCourse: CourseManagementFilterCourseApi;
    courseManagementFilterPastoral: CourseManagementFilterPastoralApi;
    courseManagementFilterResp: CourseManagementFilterRespApi;
    courseManagementFilterUser: CourseManagementFilterUserApi;
    courseManagementType: CourseManagementTypeApi;
    courseOrganization: CourseOrganizationApi;
    coursePrice: CoursePriceApi;
    courseTimeSchedule: CourseTimeScheduleApi;
    courseTimeScheduleTeacher: CourseTimeScheduleTeacherApi;
    courseTimeScheduleUser: CourseTimeScheduleUserApi;
    dept: DeptApi;
    file: FileApi;
    meetingPoint: MeetingPointApi;
    membership: MembershipApi;
    messageInformation: MessageInformationApi;
    messageInformationUser: MessageInformationUserApi;
    ministry: MinistryApi;
    ministryDef: MinistryDefApi;
    ministryMeeting: MinistryMeetingApi;
    ministryMeetingUser: MinistryMeetingUserApi;
    ministryRecord: MinistryRecordApi;
    ministryResp: MinistryRespApi;
    ministryRespUser: MinistryRespUserApi;
    ministrySchedule: MinistryScheduleApi;
    organization: OrganizationApi;
    pastoral: PastoralApi;
    pastoralMeeting: PastoralMeetingApi;
    pastoralMeetingUser: PastoralMeetingUserApi;
    privilege: PrivilegeApi;
    qrCode: QrCodeApi;
    questionnaire: QuestionnaireApi;
    questionnaireDetail: QuestionnaireDetailApi;
    role: RoleApi;
    rolePrivilegeMapping: RolePrivilegeMappingApi;
    roleUserMapping: RoleUserMappingApi;
    shoppingCart: ShoppingCartApi;
    shoppingOrder: ShoppingOrderApi;
    shoppingOrderDetail: ShoppingOrderDetailApi;
    shoppingTrack: ShoppingTrackApi;
    systemConfig: SystemConfigApi;
    teacher: TeacherApi;
    test: TestApi;
    user: UserApi;
    userCourse: UserCourseApi;
    userFamily: UserFamilyApi;
    userPastoralCare: UserPastoralCareApi;
    userQuestionnaire: UserQuestionnaireApi;
    userSociety: UserSocietyApi;
  };
}

export const Apis: IApis = {
  management: {
    appLog: new AppLogMgrApi(config, basePath, axiosInstance),
    privilege: new PrivilegeMgrApi(config, basePath, axiosInstance),
    role: new RoleMgrApi(config, basePath, axiosInstance),
    user: new UserMgrApi(config, basePath, axiosInstance),
  },
  feature: {
    appMetrics: new AppMetricsApi(config, basePath, axiosInstance),
    auth: new AuthApi(config, basePath, axiosInstance),
    child: new ChildApi(config, basePath, axiosInstance),
    course: new CourseApi(config, basePath, axiosInstance),
    courseAppendix: new CourseAppendixApi(config, basePath, axiosInstance),
    courseManagement: new CourseManagementApi(config, basePath, axiosInstance),
    courseManagementAppendix: new CourseManagementAppendixApi(config, basePath, axiosInstance),
    courseManagementFilter: new CourseManagementFilterApi(config, basePath, axiosInstance),
    courseManagementFilterCourse: new CourseManagementFilterCourseApi(config, basePath, axiosInstance),
    courseManagementFilterPastoral: new CourseManagementFilterPastoralApi(config, basePath, axiosInstance),
    courseManagementFilterResp: new CourseManagementFilterRespApi(config, basePath, axiosInstance),
    courseManagementFilterUser: new CourseManagementFilterUserApi(config, basePath, axiosInstance),
    courseManagementType: new CourseManagementTypeApi(config, basePath, axiosInstance),
    courseOrganization: new CourseOrganizationApi(config, basePath, axiosInstance),
    coursePrice: new CoursePriceApi(config, basePath, axiosInstance),
    courseTimeSchedule: new CourseTimeScheduleApi(config, basePath, axiosInstance),
    courseTimeScheduleTeacher: new CourseTimeScheduleTeacherApi(config, basePath, axiosInstance),
    courseTimeScheduleUser: new CourseTimeScheduleUserApi(config, basePath, axiosInstance),
    dept: new DeptApi(config, basePath, axiosInstance),
    file: new FileApi(config, basePath, axiosInstance),
    meetingPoint: new MeetingPointApi(config, basePath, axiosInstance),
    membership: new MembershipApi(config, basePath, axiosInstance),
    messageInformation: new MessageInformationApi(config, basePath, axiosInstance),
    messageInformationUser: new MessageInformationUserApi(config, basePath, axiosInstance),
    ministry: new MinistryApi(config, basePath, axiosInstance),
    ministryDef: new MinistryDefApi(config, basePath, axiosInstance),
    ministryMeeting: new MinistryMeetingApi(config, basePath, axiosInstance),
    ministryMeetingUser: new MinistryMeetingUserApi(config, basePath, axiosInstance),
    ministryRecord: new MinistryRecordApi(config, basePath, axiosInstance),
    ministryResp: new MinistryRespApi(config, basePath, axiosInstance),
    ministryRespUser: new MinistryRespUserApi(config, basePath, axiosInstance),
    ministrySchedule: new MinistryScheduleApi(config, basePath, axiosInstance),
    organization: new OrganizationApi(config, basePath, axiosInstance),
    pastoral: new PastoralApi(config, basePath, axiosInstance),
    pastoralMeeting: new PastoralMeetingApi(config, basePath, axiosInstance),
    pastoralMeetingUser: new PastoralMeetingUserApi(config, basePath, axiosInstance),
    privilege: new PrivilegeApi(config, basePath, axiosInstance),
    qrCode: new QrCodeApi(config, basePath, axiosInstance),
    questionnaire: new QuestionnaireApi(config, basePath, axiosInstance),
    questionnaireDetail: new QuestionnaireDetailApi(config, basePath, axiosInstance),
    role: new RoleApi(config, basePath, axiosInstance),
    rolePrivilegeMapping: new RolePrivilegeMappingApi(config, basePath, axiosInstance),
    roleUserMapping: new RoleUserMappingApi(config, basePath, axiosInstance),
    shoppingCart: new ShoppingCartApi(config, basePath, axiosInstance),
    shoppingOrder: new ShoppingOrderApi(config, basePath, axiosInstance),
    shoppingOrderDetail: new ShoppingOrderDetailApi(config, basePath, axiosInstance),
    shoppingTrack: new ShoppingTrackApi(config, basePath, axiosInstance),
    systemConfig: new SystemConfigApi(config, basePath, axiosInstance),
    teacher: new TeacherApi(config, basePath, axiosInstance),
    test: new TestApi(config, basePath, axiosInstance),
    user: new UserApi(config, basePath, axiosInstance),
    userCourse: new UserCourseApi(config, basePath, axiosInstance),
    userFamily: new UserFamilyApi(config, basePath, axiosInstance),
    userPastoralCare: new UserPastoralCareApi(config, basePath, axiosInstance),
    userQuestionnaire: new UserQuestionnaireApi(config, basePath, axiosInstance),
    userSociety: new UserSocietyApi(config, basePath, axiosInstance),
  },
};
