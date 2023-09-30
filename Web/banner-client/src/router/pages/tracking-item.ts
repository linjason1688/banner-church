import { RouteRecordRaw } from "vue-router";

export const TrackingItemRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "TrackingItemEntry",
    path: "tracking-item",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "TI0101",
    },
    children: [
      {
        path: "list",
        name: "TI0101",
        component: () => import("src/pages/tracking-item/List.vue"),
      },
    ],
  },
];
