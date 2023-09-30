import { RouteRecordRaw } from "vue-router";

export const MinistryDefRoutes: RouteRecordRaw[] = [
  {
    name: "MinistryDef",
    path: "ministry/def",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "MD0001",
    },
    children: [
      {
        name: "MD0001",
        path: "list",
        component: () => import("pages/ministry-def/List.vue"),
      },
      {
        name: "MD0002",
        path: "detail",
        component: () => import("pages/ministry-def/Detail.vue"),
      },
      {
        name: "MD0003",
        path: "detail/:id",
        component: () => import("pages/ministry-def/Detail.vue"),
        props: true,
      },
    ],
  },
];
