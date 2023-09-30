/* eslint-disable */
import "reflect-metadata";

import { LoadingUtil } from "src/boot/loading";
import { Sleep } from "src/util";

const AsyncFunction = (async () => {}).constructor;

export function WithLoading(delayMs = 0) {
  // wrapper decorator with params
  return function (target: any, propertyKey: string, descriptor: PropertyDescriptor) {
    const method = descriptor.value as Function;

    const isAsync = method instanceof AsyncFunction;

    // console.log("loading", target, propertyKey, descriptor);
    descriptor.value = async function () {
      LoadingUtil.showLoading();

      const now = new Date().getTime();

      if (delayMs > 0) {
        await Sleep(delayMs);
      }

      try {
        if (isAsync) {
          return await method.apply(this, arguments);
        }
        return method.apply(this, arguments);
      } finally {
        const timeElapsed = new Date().getTime() - now;

        if (timeElapsed < 200) {
          await Sleep(200);
        }

        LoadingUtil.hideLoading();
      }
    };
  };
}
// export function propertyDecorator(target: any, propertyKey: string, parameterIndex: number) {
//   console.log("Parameter Decorator", arguments);
// }
