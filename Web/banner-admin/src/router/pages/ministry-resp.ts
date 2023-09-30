import { RouteRecordRaw } from "vue-router";

export const MinistryRespRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "MinistryRespEntry",
    path: "ministry-resp",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "MR0101",
    },
    children: [
      {
        path: "list",
        name: "MR0101",
        component: () => import("src/pages/ministry-resp/List.vue"),
      },
      {
        path: "detail",
        name: "MR0102",
        component: () => import("src/pages/ministry-resp/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "MR0103",
        component: () => import("src/pages/ministry-resp/Detail.vue"),
        props: true,
      },
    ],
  },
];
