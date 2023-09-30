import { RouteRecordRaw } from "vue-router";

export const QuestionnaireRoutes: RouteRecordRaw[] = [
  {
    name: "Questionnaire",
    path: "questionnaire",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "QU0001",
    },
    children: [
      {
        name: "QU0001",
        path: "list",
        component: () => import("src/pages/questionnaire/List.vue"),
      },
      {
        name: "QU0002",
        path: "detail/:id?",
        component: () => import("src/pages/questionnaire/Detail.vue"),
        props: true,
      },
    ],
  },
];
