import { RouteRecordRaw } from "vue-router";

export const WorkingGroupRoutes: RouteRecordRaw[] = [
  {
    name: "WorkingGroup",
    path: "working/group",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "WG0001",
    },
    children: [
      {
        name: "WG0001",
        path: "index",
        component: () => import("src/pages/working-group/Index.vue"),
      },
    ],
  },
];
