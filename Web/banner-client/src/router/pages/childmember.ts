import { RouteRecordRaw } from "vue-router";

export const ChildMemberRoutes: RouteRecordRaw[] = [
  {
    name: "ChildMember",
    path: "child/member",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CM0001",
    },
    children: [
      {
        name: "CM0001",
        path: "index",
        component: () => import("src/pages/child-member/Index.vue"),
      },
      {
        name: "CM0002",
        path: "profile",
        component: () => import("pages/member/Profile.vue"),
      },
      {
        name: "CM0003",
        path: "family",
        component: () => import("pages/member/Family.vue"),
      },
    ],
  },
];
