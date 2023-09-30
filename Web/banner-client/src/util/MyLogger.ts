/* eslint-disable */
import logger from "loglevel";
import loggerPrefixPlugin from "loglevel-plugin-prefix";

// 以後 by env 設定處理
logger.setLevel("DEBUG");

loggerPrefixPlugin.reg(logger);
loggerPrefixPlugin.apply(logger, {
  format(level, name, timestamp) {
    return `[${timestamp}] ${level} ${name}:`;
  },
});

export const MyLogger = logger;
