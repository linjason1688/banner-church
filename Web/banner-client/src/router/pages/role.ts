import { RouteRecordRaw } from "vue-router";

export const RoleRoutes: RouteRecordRaw[] = [
  {
    name: "RoleEntry",
    path: "role",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CR0100",
    },
    children: [
      {
        path: "list",
        name: "CR0100",
        component: () => import("src/pages/role/List.vue"),
      },
      {
        path: "detail",
        name: "CR0101",
        component: () => import("src/pages/role/Detail.vue"),
      },
      {
        path: "detail/:id",
        name: "CR0102",
        component: () => import("src/pages/role/Detail.vue"),
        props: true,
      },
      {
        path: "privilege",
        name: "CR0104",
        component: () => import("src/pages/role/RolePrivilege.vue"),
        props: true,
      },
    ],
  },
];
