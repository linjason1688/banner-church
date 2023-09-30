import {SystemConfigView} from "src/api/feature";

export function convertStatusCd(val: string | undefined) {
  if (val == "1") return "啟用";
  return "停用";
}

export function convertDisplayText(systemConfigList: Array<SystemConfigView>, index: string) {
  const found = systemConfigList.find((e) => e.name == index);
  if (found) return found.value;
  return index;
}
