import { Apis } from "src/api/Apis";
import { CreateShoppingTrackCommand, QueryShoppingTrackRequest } from "src/api/feature";

export async function addShoppingTrack(userId: number, courseId: number) {
  const request = {
    userId: userId,
    courseId: courseId,
  };

  if (!(await isInShoppingTrack(userId, courseId))) {
    await Apis.feature.shoppingTrack.createShoppingTrack(request as CreateShoppingTrackCommand);
  }
}

export async function isInShoppingTrack(userId: number, courseId: number) {
  const request = {
    userId: userId,
    courseId: courseId,
  };
  const found = (await Apis.feature.shoppingTrack.queryShoppingTracks(request as QueryShoppingTrackRequest)).data.totalCount;
  return found !== 0;
}

export async function queryShoppingTracks(userId: number) {
  const request = {
    userId: userId,
  };
  return (await Apis.feature.shoppingTrack.queryShoppingTracks(request as QueryShoppingTrackRequest)).data
}

export async function removeShoppingTrack(trackId: number) {
  return(await Apis.feature.shoppingTrack.removeShoppingTrack(trackId)).data;
}