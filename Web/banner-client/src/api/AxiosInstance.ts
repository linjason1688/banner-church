/* tslint:disable */
/* eslint-disable */

import axios from "axios";
import { ApiBadRequestError, ApiError } from "src/data/errors";
import { FileUtility, MyLogger } from "src/util";

import { env } from "src/env.config";

const JwtHeaderName = "authorization";
const ClientActionTimeHeaderName = "x-client-action-time";

let underRequesting = false;
let reqCount = 0;

const instance = axios.create({
  baseURL: env.apiUrl,
  timeout: 1000 * 60 * 3, // 3 mins as the same as server
  maxContentLength: 1024 * 50,
  // accept all status codes
  validateStatus: (status) => true,
  responseType: "json",
});

// ** request interceptors  NOTE: interceptors executed in the reverse registry order
instance.interceptors.request.use((config) => {
  // this is to achieve request queue
  return new Promise((rs, rj) => {
    const interval = setInterval(() => {
      if (!underRequesting) {
        clearInterval(interval);
        underRequesting = true;
        reqCount++;

        config.headers[ClientActionTimeHeaderName] = new Date().getTime().toString();

        rs(config);
      }
    }, 10);
  });
});

// request log
instance.interceptors.request.use((config) => {
  return config;
});

// ** end request interceptors

// ** response interceptors

instance.interceptors.response.use((res) => {
  MyLogger.debug(`res-count: ${reqCount}`);

  underRequesting = false;

  return res;
});

// response log
instance.interceptors.response.use((res) => {
  const config = res.config;
  const actionTime = Number(config.headers[ClientActionTimeHeaderName] || 0);

  const timeElapsed = new Date().getTime() - actionTime;

  MyLogger.info(`axios- time elapsed: ${timeElapsed} ms for ${config.url}`, {
    url: config.url,
    reqHeaders: config.headers,
    requestBody: config.data,
    status: res.status,
    resHeaders: res.headers,
    resBody: res.data,
  });

  return res;
});

instance.interceptors.response.use((res) => {
  const data = res.data;
  if (res.status >= 500) {
    if (data && data.message) {
      throw new ApiError("500", data.message, data);
    }

    throw new ApiError("500", "伺服器連線錯誤!", data);
  }

  if (res.config.responseType === "blob" && res.status >= 400) {
    throw new ApiBadRequestError("400", "檔案下載失敗");
  }

  if (res.status === 401) {
    window.location.href = "Login";
    throw new ApiBadRequestError(data.code, data.message, data);
  }

  if (res.status >= 400 && res.status < 500) {
    throw new ApiBadRequestError(data.code, data.message, data);
  }

  // 處理檔案下載
  if (res.config.responseType === "blob") {
    const filename = res.headers.filename;
    if (filename) {
      FileUtility.downloadFile(filename, res.data);
      return;
    }
  }

  return data;
});

// ** end response interceptors

export const axiosInstance = instance;
