import { RouteRecordRaw } from "vue-router";

export const ChildMember1Routes: RouteRecordRaw[] = [
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
        component: () => import("pages/child-member/List.vue"),
      },
    ],
  },
];
