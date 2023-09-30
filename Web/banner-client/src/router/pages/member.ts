import { RouteRecordRaw } from "vue-router";

export const MemberRoutes: RouteRecordRaw[] = [
  {
    name: "Member",
    path: "member",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "BP0004",
    },
    children: [
      {
        path: "index",
        name: "BP0004",
        component: () => import("pages/member/Index.vue"),
      },
      {
        path: "main",
        name: "BP0001",
        component: () => import("pages/member/Main.vue"),
      },
      {
        path: "profile",
        name: "BP0002",
        component: () => import("pages/member/Profile.vue"),
      },
      {
        path: "family",
        name: "BP0003",
        component: () => import("pages/member/Family.vue"),
      },
      {
        path: "payment",
        name: "BP0005",
        component: () => import("pages/member/Payment.vue"),
      },
      {
        path: "other",
        name: "BP0006",
        component: () => import("pages/member/Other.vue"),
      },
      {
        path: "working",
        name: "BP0007",
        component: () => import("pages/member/MinistryMeeting.vue"),
      },
      {
        path: "course",
        name: "BP0008",
        component: () => import("pages/member/CourseHistory.vue"),
      },
      {
        path: "care",
        name: "BP0009",
        component: () => import("pages/member/PastoralCare.vue"),
      },
      {
        path: "group",
        name: "BP0010",
        component: () => import("pages/member/Group.vue"),
      },
    ],
  },
];
