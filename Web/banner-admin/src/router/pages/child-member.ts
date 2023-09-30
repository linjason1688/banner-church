import { RouteRecordRaw } from "vue-router";

export const ChildMemberRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "Entry",
    path: "child-member",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CH0100",
    },
    children: [
      {
        path: "list",
        name: "CH0101",
        component: () => import("src/pages/child-member/List.vue"),
      },
      {
        path: "detail",
        name: "CH0102",
        component: () => import("src/pages/child-member/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CH0103",
        component: () => import("src/pages/child-member/Detail.vue"),
        props: true,
      },
    ],
  },
];
