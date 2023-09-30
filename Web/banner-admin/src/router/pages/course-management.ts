import { RouteRecordRaw } from "vue-router";

export const CourseManagementRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseManagementEntry",
    path: "course-management",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CM0100",
    },
    children: [
      {
        path: "list",
        name: "CM0101",
        component: () => import("src/pages/course-management/List.vue"),
      },
      {
        path: "detail",
        name: "CM0102",
        component: () => import("src/pages/course-management/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CM0103",
        component: () => import("src/pages/course-management/Detail.vue"),
        props: true,
      },
    ],
  },
];
