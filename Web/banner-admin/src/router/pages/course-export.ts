import { RouteRecordRaw } from "vue-router";

export const CourseExportRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseExportEntry",
    path: "course-export",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CE0101",
    },
    children: [
      {
        path: "list",
        name: "CE0101",
        component: () => import("src/pages/course-export/List.vue"),
      },
      {
        path: "detail",
        name: "CE0102",
        component: () => import("src/pages/course-export/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CE0103",
        component: () => import("src/pages/course-export/Detail.vue"),
        props: true,
      },
    ],
  },
];
