export interface CourseTimeSchedules$ {
  classDay: string;
  classTimeE: string;
  classTimeS: string;
  place: string;
  scheduleNo: string;
}

export function formatClassDate (e: CourseTimeSchedules$) {
  return `${e.classDay} ${e.classTimeS}-${e.classTimeE}`
}
