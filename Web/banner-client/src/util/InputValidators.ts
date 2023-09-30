/*
 * The following validators are used in vuetify inputs (rules)
 * The return Type maybe varying between string and boolean
 **/

import _ from "lodash";
import { SelectOption } from "src/data/dto";
import { StringUtility } from "src/util";

/**
 * input 檢查/ select 則檢查 option object value
 * @param val
 * @returns
 */
export function required(val: unknown) {
  if (_.isString(val)) {
    if (StringUtility.isNullOrEmpty(val)) {
      return "必填欄位!";
    }
  } else if (_.isObject(val)) {
    const option = val as SelectOption<unknown>;
    if (!option.value) {
      return "必填欄位,請選擇!";
    }
  }
  return true;
}

/**
 *
 * @param val
 */
export function number(val: string): boolean | string {
  const errMsg = "請輸入「數字」!";
  if (!val || isNaN(Number(val))) {
    return errMsg;
  }

  return true;
}

export function dateTime(val: string): boolean | string {
  const errMsg = "請輸入正確的日期時間格式「yyyy-MM-dd HH:mm:ss」!";
  if (!val) {
    return errMsg;
  }
  const ts = Date.parse(val);

  if (ts < 0 || isNaN(ts)) {
    return errMsg;
  }

  return true;
}

export function timeSpan(val: string): boolean | string {
  const errMsg = "請輸入正確的 時間格式「HH:mm:ss」!";

  const fmtRegex = /\d{2}:\d{2}:\d{2}/;
  if (!fmtRegex.test(val)) {
    return errMsg;
  }

  return true;
}

export function guid(val: string): boolean | string {
  const errMsg = "請輸入正確的 GUID 格式!";

  const fmtRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

  if (!fmtRegex.test(val)) {
    return errMsg;
  }

  return true;
}

export function ipAddress(val: string): boolean | string {
  const errMsg = "請輸入正確的 IP 格式!";

  const fmtRegex =
    /^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$/;

  if (!fmtRegex.test(val)) {
    return errMsg;
  }

  return true;
}
