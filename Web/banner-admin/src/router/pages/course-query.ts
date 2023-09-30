import { RouteRecordRaw } from "vue-router";

export const CourseQueryRoutes: RouteRecordRaw[] = [
  // ========== 登入後頁面 =========
  {
    name: "CourseQueryEntry",
    path: "course-query",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CQ0101",
    },
    children: [
      {
        path: "list",
        name: "CQ0101",
        component: () => import("src/pages/course-query/List.vue"),
      },
      {
        path: "detail",
        name: "CQ0102",
        component: () => import("src/pages/course-query/Detail.vue"),
        props: true,
      },
      {
        path: "detail/:id?",
        name: "CQ0103",
        component: () => import("src/pages/course-query/Detail.vue"),
        props: true,
      },
    ],
  },
];
