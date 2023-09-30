import { Apis } from "src/api/Apis";
import { QueryUserRequest } from "src/api/feature";

export const User = {
  emailRule: /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/,
};

export function joinChurchGroupRule(val: string) {
  if (val) {
    return true;
  }
  return "請選擇入組意願";
}

/**
 * 以 username 判斷用戶是否存在
 * @param val
 */
export async function isUsernameExisted(val: string) {
  try {
    const res = await Apis.feature.user.queryUsers({name: val} as QueryUserRequest);
    return res.data.totalCount > 0;
  } catch (e) {
    console.error(e);
  }

  return false;
}

/**
 * 以 email 判斷用戶是否存在
 * @param val
 */
export async function isEmailExisted(val: string) {
  try {
    const res1 = await Apis.feature.user.queryUsers({email1: val} as QueryUserRequest);
    const res2 = await Apis.feature.user.queryUsers({email2: val} as QueryUserRequest);
    return (res1.data.totalCount + res2.data.totalCount) > 0;
  } catch (e) {
    console.error(e);
  }

  return false;
}

/**
 * 以 idNumber 判斷用戶是否存在
 * @param val
 */
export async function isIdNumberExisted(val: string) {
  try {
    const res = await Apis.feature.user.queryUsers({idNumber: val} as QueryUserRequest);
    return res.data.totalCount > 0;
  } catch (e) {
    console.error(e);
  }

  return false;
}
