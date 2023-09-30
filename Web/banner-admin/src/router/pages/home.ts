import { RouteRecordRaw } from "vue-router";

export const HomeRoutes: RouteRecordRaw[] = [
  {
    name: "HomeEntry",
    path: "",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "Home",
    },
    children: [
      {
        path: "home",
        name: "Home",
        component: () => import("src/pages/Home.vue"),
      },
    ],
  },
];
