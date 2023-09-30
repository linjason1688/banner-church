import { RouteRecordRaw } from "vue-router";

export const MemberRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "MemberEntry",
    path: "member",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "AM0100",
    },
    children: [
      {
        path: "list",
        name: "AM0101",
        component: () => import("src/pages/member/List.vue"),
      },
      {
        path: "detail",
        name: "AM0102",
        component: () => import("src/pages/member/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "AM0103",
        component: () => import("src/pages/member/Detail.vue"),
        props: true,
      },
    ],
  },
];
