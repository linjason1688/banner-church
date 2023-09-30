import { RouteRecordRaw } from "vue-router";

export const CourseRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseEntry",
    path: "course",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CO0100",
    },
    children: [
      {
        path: "list",
        name: "CO0101",
        component: () => import("src/pages/course/List.vue"),
      },
      {
        path: "detail",
        name: "CO0102",
        component: () => import("src/pages/course/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CO0103",
        component: () => import("src/pages/course/Detail.vue"),
        props: true,
      },
    ],
  },
];
