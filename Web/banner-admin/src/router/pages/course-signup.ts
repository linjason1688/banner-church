import { RouteRecordRaw } from "vue-router";

export const CourseSignupRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseSignupEntry",
    path: "course-signup",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CS0100",
    },
    children: [
      {
        path: "list",
        name: "CS0101",
        component: () => import("src/pages/course-signup/List.vue"),
      },
    ],
  },
];
