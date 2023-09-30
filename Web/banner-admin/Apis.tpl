import { axiosInstance } from "src/api/AxiosInstance";
import {
  $.featApis
} from "src/api/feature";
import {
  $.mgrApis
} from "src/api/management/api";

const basePath = "";

const config = {
  isJsonMime: (mime: string) => mime.indexOf("json") !== -1,
};

export interface IApis {
  management: {
    $.mgrApiTypes
  };
  feature: {
    //
    $.featApiTypes
  };
}

export const Apis: IApis = {
  management: {
    $.mgrApiDeclaration
  },
  feature: {
    $.featApiDeclaration
  },
};
