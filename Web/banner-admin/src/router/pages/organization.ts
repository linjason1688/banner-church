import { RouteRecordRaw } from "vue-router";

export const OrganizationRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "OrganizationEntry",
    path: "organization",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "OG0101",
    },
    children: [
      {
        path: "list",
        name: "OG0101",
        component: () => import("src/pages/organization/List.vue"),
      },
      {
        path: "detail",
        name: "OG0102",
        component: () => import("src/pages/organization/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "OG0103",
        component: () => import("src/pages/organization/Detail.vue"),
        props: true,
      },
    ],
  },
];
