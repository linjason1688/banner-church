import { Apis } from "src/api/Apis";
import {
  CreateShoppingCartCommand,
  FetchAllShoppingCartRequest,
  QueryShoppingCartRequest,
} from "src/api/feature";

export async function addShoppingCart(userId: number, courseId: number) {
  const request = {
    userId: userId,
    courseId: courseId,
  }

  if (!(await isInShoppingCart(userId, courseId))) {
    await Apis.feature.shoppingCart.createShoppingCart(request as CreateShoppingCartCommand)
  }
}

export async function isInShoppingCart(userId: number, courseId: number) {
  const request = {
    userId: userId,
    courseId: courseId,
  }
  const found = (await Apis.feature.shoppingCart.queryShoppingCarts(request as QueryShoppingCartRequest)).data.totalCount;
  return found !== 0;
}

export async function queryShoppingCart(userId: number) {
  const request = {
    userId: userId,
  }
  return (await Apis.feature.shoppingCart.queryShoppingCarts(request as QueryShoppingCartRequest)).data;
}

export async function fetchShoppingCart(userId: number) {
  const request = {
    userId: userId,
  }
  return (await Apis.feature.shoppingCart.fetchShoppingCarts(request as FetchAllShoppingCartRequest)).data;
}

export async function removeShoppingCart(courseId: number) {
  await Apis.feature.shoppingCart.removeShoppingCart(courseId);
}
