import { RouteRecordRaw } from "vue-router";

export const UserRoutes: RouteRecordRaw[] = [
  {
    name: "UserEntry",
    path: "user",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "US0100",
    },
    children: [
      {
        path: "list",
        name: "US0100",
        component: () => import("src/pages/user/List.vue"),
      },
      {
        path: "detail",
        name: "US0101",
        component: () => import("src/pages/user/Detail.vue"),
      },
      {
        path: "detail/:id",
        name: "US0102",
        component: () => import("src/pages/user/Detail.vue"),
        props: true,
      },
    ],
  },
];
