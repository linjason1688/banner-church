import { RouteRecordRaw } from "vue-router";

export const ClassRoutes: RouteRecordRaw[] = [
  {
    name: "Class",
    path: "class",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CL0001",
    },
    children: [
      {
        path: "index",
        name: "CL0001",
        component: () => import("pages/class/Index.vue"),
      },
      {
        path: "demo",
        name: "CL0002",
        component: () => import("pages/class/Fullscreen.vue"),
      },
      {
        name: "CL0103",
        path: "detail/:id?",
        component: () => import("src/pages/class/Detail.vue"),
        props: true,
      },
      {
        name: "CL0104",
        path: "search/:keyword?",
        component: () => import("src/pages/class/Search.vue"),
        props: true,
      },
    ],
  },
];
