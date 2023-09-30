import { RouteRecordRaw } from "vue-router";

export const ClassManageRoutes: RouteRecordRaw[] = [
  {
    name: "ClassManage",
    path: "class/manage",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CM0001",
    },
    children: [
      {
        name: "CM0001",
        path: "index",
        component: () => import("src/pages/class-manage/Index.vue"),
      },
    ],
  },
];
