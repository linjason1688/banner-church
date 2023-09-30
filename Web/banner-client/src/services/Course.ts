import { Apis } from "src/api/Apis";

export async function getCourse(courseId: number) {
  return (await Apis.feature.course.getCourse(courseId)).data;
}

export function convertWeekDay(id: string) {
  if (id === "1") return "星期一";
  if (id === "2") return "星期二";
  if (id === "3") return "星期三";
  if (id === "4") return "星期四";
  if (id === "5") return "星期五";
  if (id === "6") return "星期六";
  if (id === "7") return "星期日";
  return id
}
