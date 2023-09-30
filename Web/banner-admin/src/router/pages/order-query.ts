import { RouteRecordRaw } from "vue-router";

export const OrderQueryRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "OrderQueryEntry",
    path: "order-query",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "OQ0101",
    },
    children: [
      {
        path: "list",
        name: "OQ0101",
        component: () => import("src/pages/order-query/List.vue"),
      },
      {
        path: "detail",
        name: "OQ0102",
        component: () => import("src/pages/order-query/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "OQ0103",
        component: () => import("src/pages/order-query/Detail.vue"),
        props: true,
      },
    ],
  },
];
