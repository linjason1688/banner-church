import { RouteRecordRaw } from "vue-router";

export const MinistryRoutes: RouteRecordRaw[] = [
  {
    name: "MinistryEntry",
    path: "ministry",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "MI0100",
    },
    children: [
      {
        path: "list",
        name: "MI0101",
        component: () => import("src/pages/ministry/List.vue"),
      },
      {
        path: "detail",
        name: "MI0102",
        component: () => import("src/pages/ministry/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "MI0103",
        component: () => import("src/pages/ministry/Detail.vue"),
        props: true,
      },
    ],
  },
];
