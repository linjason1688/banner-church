import { Apis } from "src/api/Apis";
import { QueryUserRequest } from "src/api/feature";

export const User = {
  emailRule: /^\w+((-\w+)|[(\.\w+)])*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/,
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
    const res = await Apis.feature.user.anonymousQueryUsers({username: val} as QueryUserRequest);
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
    const res1 = await Apis.feature.user.anonymousQueryUsers({email1: val} as QueryUserRequest);
    const res2 = await Apis.feature.user.anonymousQueryUsers({email2: val} as QueryUserRequest);
    return (res1.data.totalCount + res2.data.totalCount) > 0;
  } catch (e) {
    console.error(e);
  }

  return false;
}

/**
 * 以 cellphone 判斷手機號碼是否存在
 * @param val
 */
export async function isCellphoneExisted(val: string) {
  try {
    const res1 = await Apis.feature.user.anonymousQueryUsers({cellPhone1: val} as QueryUserRequest);
    const res2 = await Apis.feature.user.anonymousQueryUsers({cellPhone2: val} as QueryUserRequest);
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

/**
 * 判斷用戶的 idNumber 是否已填寫
 * @param val
 */
 export async function isUserIdNumberDefined(userId: number) {
  const user = (await Apis.feature.user.getUser(userId)).data;
    if (user.idNumber == "" || user.idNumber == undefined) {
      return false;
    }
    return true;
}
