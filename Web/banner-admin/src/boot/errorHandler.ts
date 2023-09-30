import { boot } from "quasar/wrappers";
import { LoadingUtil } from "src/boot/loading";
import { MessageLevel } from "src/data/dto";
import { BusinessError } from "src/data/errors";
import { MyLogger } from "src/util";

import { ComponentPublicInstance } from "@vue/runtime-core";

interface IVueError extends Error {
  config: unknown;
  code: unknown;
  request?: XMLHttpRequest;
  response?: {
    config: unknown;
    status: number;
  };
}

export default boot(({ app }) => {
  app.config.errorHandler = (err: unknown, instance: ComponentPublicInstance | null, info: string) => {
    MyLogger.error(err, instance, info);
    const ex = err as IVueError;

    try {
      if (ex instanceof BusinessError) {
        instance?.$store.commit("app/addAppMessage", { message: ex.message, level: MessageLevel.warning });
        instance?.showWarnNotify(ex.message);
      } else {
        instance?.$store.commit("app/addAppMessage", { message: ex.message, level: MessageLevel.error });
        instance?.showErrorNotify(ex.message);
      }
    } finally {
      LoadingUtil.hideLoading();
    }
  };
});
