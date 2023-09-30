import { RouteRecordRaw } from "vue-router";

export const AppLogRoutes: RouteRecordRaw[] = [
  {
    name: "AppLogEntry",
    path: "app-log",
    component: () => import("layouts/Main.vue"),
    redirect: {
      name: "CL0001",
    },
    children: [
      {
        path: "api-log",
        name: "CL0001",
        component: () => import("src/pages/appLog/ApiLog.vue"),
      },
      {
        path: "exception-log",
        name: "CL0002",
        component: () => import("src/pages/appLog/ExceptionLog.vue"),
      },
    ],
  },
];
