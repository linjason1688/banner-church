import { RouteRecordRaw } from "vue-router";

export const SchoolRoutes: RouteRecordRaw[] = [
  {
    name: "School",
    path: "school",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "SC0001",
    },
    children: [
      {
        name: "SC0001",
        path: "index",
        component: () => import("src/pages/school/Index.vue"),
      },
    ],
  },
];
