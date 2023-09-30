import { RouteRecordRaw } from "vue-router";

export const TemplateRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "TemplateEntry",
    path: "template",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "List",
    },
    children: [
      {
        path: "list",
        name: "List",
        component: () => import("src/pages/templates/_List.vue"),
      },
      {
        path: "detail/:id?",
        name: "Detail",
        component: () => import("src/pages/templates/_Detail.vue"),
        props: true,
      },
    ],
  },
];
