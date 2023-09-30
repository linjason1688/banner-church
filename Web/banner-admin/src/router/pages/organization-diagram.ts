import { RouteRecordRaw } from "vue-router";

export const OrganizationDiagramRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "OrganizationDiagramEntry",
    path: "organization-diagram",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "OD0101",
    },
    children: [
      {
        path: "",
        name: "OD0101",
        component: () => import("src/pages/organization-diagram/Index.vue"),
      },
      {
        path: "ministry",
        name: "OD0102",
        component: () => import("src/pages/organization-diagram/Ministry.vue"),
      },
      {
        path: "list",
        name: "OD0103",
        component: () => import("src/pages/organization-diagram/List.vue"),
      },
      {
        path: "detail/:id?",
        name: "OD0104",
        component: () => import("src/pages/organization-diagram/Detail.vue"),
      },
      {
        path: "family",
        name: "OD0105",
        component: () => import("src/pages/organization-diagram/Family.vue"),
      },
    ],
  },
];
