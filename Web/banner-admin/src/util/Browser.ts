import qs from "qs";
import { MyLogger } from "src/util";

export const Browser = {
  getCurrentQueryString: () => {
    const search = window.location.search;
    MyLogger.debug(`search: ${search}`);
    const query = qs.parse(search, { ignoreQueryPrefix: true });

    return query;
  },
};
