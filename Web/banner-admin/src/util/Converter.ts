export function convertStatusCd(val: string | undefined) {
  if (val == "1") return "啟用";
  return "停用";
}

