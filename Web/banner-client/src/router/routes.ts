import { HomeRoutes } from "src/router/pages/home";
import { MemberRoutes } from "src/router/pages/member";
import { RoleRoutes } from "src/router/pages/role";
import { RouteRecordRaw } from "vue-router";

import { AppLogRoutes } from "./pages/appLog";
import { TemplateRoutes } from "./pages/template";
import { ChildMemberRoutes } from "src/router/pages/childmember";
import { ClassRoutes } from "src/router/pages/class";
import { WorkingGroupRoutes } from "src/router/pages/workinggroup";
import { SchoolRoutes } from "src/router/pages/school";
import { QuestionnaireRoutes } from "src/router/pages/questionnaire";
import { ClassManageRoutes } from "src/router/pages/classmanage";
import { ShoppingCartRoutes } from "src/router/pages/shopping-cart";
import { CourseMemberRoutes } from "src/router/pages/course-member";
import { TrackingItemRoutes } from "src/router/pages/tracking-item";

const authRoutes = [
  //
  ...TemplateRoutes,
  ...HomeRoutes,
  ...AppLogRoutes,
  ...RoleRoutes,
  ...MemberRoutes,
  ...ChildMemberRoutes,
  ...ClassRoutes,
  ...WorkingGroupRoutes,
  ...SchoolRoutes,
  ...QuestionnaireRoutes,
  ...ClassManageRoutes,
  ...ShoppingCartRoutes,
  ...CourseMemberRoutes,
  ...TrackingItemRoutes,
];

const routes: RouteRecordRaw[] = [
  {
    path: "/login",
    name: "Login",
    component: () => import("src/pages/Login.vue"),
  },
  {
    path: "/demo",
    name: "Demo",
    component: () => import("src/pages/signup/Privacy.vue"),
  },
  {
    path: "/child",
    name: "Child",
    redirect: { path: "/child/profile" },
    children: [
      {
        path: "profile",
        name: "ChildProfile",
        component: () => import("src/pages/child/Profile.vue"),
      },
      {
        path: "information",
        name: "ChildInformation",
        component: () => import("src/pages/child/Information.vue"),
      },
      {
        path: "done",
        name: "ChildDone",
        component: () => import("src/pages/child/Done.vue"),
      },
    ],
  },
  {
    path: "/signup",
    name: "Signup",
    redirect: { name: "profile" },
    children: [
      {
        path: "profile",
        name: "Profile",
        component: () => import("src/pages/signup/Profile.vue"),
      },
      {
        path: "verification",
        name: "Verification",
        component: () => import("src/pages/signup/Verification.vue"),
      },
      {
        path: "information",
        name: "Information",
        component: () => import("src/pages/signup/Information.vue"),
      },
      {
        path: "group",
        name: "Group",
        component: () => import("src/pages/signup/Group.vue"),
      },
      {
        path: "done",
        name: "Done",
        component: () => import("src/pages/signup/Done.vue"),
      },
    ],
  },
  {
    path: "/resetpwd",
    name: "ResetPwd",
    component: () => import("src/pages/reset-pwd/ResetPwd.vue"),
  },
  {
    path: "/changepwd",
    name: "ChangePwd",
    component: () => import("src/pages/change-pwd/ChangePwd.vue"),
  },
  {
    path: "/findaccount",
    name: "FindAccount",
    component: () => import("src/pages/find-account/FindAccount.vue"),
  },
  {
    path: "/tt",
    name: "tt",
    component: () => import("src/pages/templates/_Detail.vue"),
  },
  {
    path: "",
    name: "Root",
    redirect: { name: "Home" },
  },
  {
    // ========== 登入後頁面 =========
    name: "authorized",
    path: "/m/",
    component: () => import("pages/Index.vue"),
    children: authRoutes,
  },

  {
    path: "/error",
    name: "Error",
    component: () => import("pages/Error.vue"),
  },
  {
    name: "Unauthorized",
    path: "/unauthorized",
    component: () => import("pages/Unauthorized.vue"),
  },
  // Always leave this as last one,
  // but you can also remove it
  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/NotFound.vue"),
  },
  {
    path: "/wip",
    name: "Wip",
    component: () => import("pages/Wip.vue"),
  },
];

//

export default routes;
