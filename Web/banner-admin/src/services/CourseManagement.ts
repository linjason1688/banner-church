export function convertCourseManagementStatus(val: string | undefined) {
  if (val == "0") return "實體";
  if (val == "1") return "線上";
  if (val == "2") return "網路學校";
  return "停用";
}
