import { RouteRecordRaw } from "vue-router";

export const CourseMemberRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseMemberEntry",
    path: "course-member",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CM0101",
    },
    children: [
      {
        path: "list",
        name: "CM0101",
        component: () => import("pages/course-member/List.vue"),
      },
      {
        path: "detail",
        name: "CM0102",
        component: () => import("src/pages/course-member/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CM0103",
        component: () => import("src/pages/course-member/Detail.vue"),
        props: true,
      },
    ],
  },
];
