import { RouteRecordRaw } from "vue-router";

export const CourseManagementFilterRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseManagementFilterEntry",
    path: "course-filter",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CF0101",
    },
    children: [
      {
        path: "list",
        name: "CF0101",
        component: () => import("src/pages/course-filter/List.vue"),
      },
      {
        path: "detail",
        name: "CF0102",
        component: () => import("src/pages/course-filter/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CF0103",
        component: () => import("src/pages/course-filter/Detail.vue"),
        props: true,
      },
    ],
  },
];
