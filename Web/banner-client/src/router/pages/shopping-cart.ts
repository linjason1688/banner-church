import { RouteRecordRaw } from "vue-router";

export const ShoppingCartRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "ShoppingCartEntry",
    path: "shopping-cart",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "SC0101",
    },
    children: [
      {
        path: "index",
        name: "SC0101",
        component: () => import("pages/shopping-cart/Index.vue"),
      },
      {
        path: "demo",
        name: "SC0102",
        component: () => import("pages/shopping-cart/Fullscreen.vue"),
        props: true,
      },
      {
        name: "SC0103",
        path: "detail/:id?",
        component: () => import("src/pages/shopping-cart/Detail.vue"),
        props: true,
      },
      {
        name: "SC0104",
        path: "check",
        component: () => import("src/pages/shopping-cart/Check.vue"),
        props: true,
      },
    ],
  },
];
