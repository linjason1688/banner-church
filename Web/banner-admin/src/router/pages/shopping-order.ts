import { RouteRecordRaw } from "vue-router";

export const ShoppingOrderRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "ShoppingOrderEntry",
    path: "shopping-order",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "SO0100",
    },
    children: [
      {
        path: "list",
        name: "SO0101",
        component: () => import("src/pages/shopping-order/List.vue"),
      },
      {
        path: "detail",
        name: "SO0102",
        component: () => import("src/pages/shopping-order/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "SO0103",
        component: () => import("src/pages/shopping-order/Detail.vue"),
        props: true,
      },
    ],
  },
];
