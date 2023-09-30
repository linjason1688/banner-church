import { RouteRecordRaw } from "vue-router";

export const CourseManagementTypeRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseManagementTypeEntry",
    path: "course-management-type",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CT0100",
    },
    children: [
      {
        path: "list",
        name: "CT0101",
        component: () => import("src/pages/course-management-type/List.vue"),
      },
      {
        path: "detail",
        name: "CT0102",
        component: () => import("src/pages/course-management-type/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CT0103",
        component: () => import("src/pages/course-management-type/Detail.vue"),
        props: true,
      },
    ],
  },
];
