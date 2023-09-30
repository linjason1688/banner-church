import { ViewQueryParams } from "src/data/dto/ViewQueryParams";

import { MyLocalStorageUnit } from "./MyLocalStorageUnit";

export const MyLocalStorage = {
  activeNode: new MyLocalStorageUnit<{ functionId: string; parentFunctionId: string }>("activeNode"),
  queryParams: new MyLocalStorageUnit<ViewQueryParams>("viewQueryParams"),
};
