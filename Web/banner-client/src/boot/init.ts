import { boot } from "quasar/wrappers";
import { LoadingUtil } from "src/boot/loading";
import { appModule } from "src/store/app-module";
import { MyLogger } from "src/util";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    sleep: (ms: number) => Promise<number>;
  }
}

export default boot(async ({ store }) => {
  // 於此初始化所需資料，並嘗試讀取 user profile

  try {
    LoadingUtil.showLoading();
    const appStore = appModule.context(store);
    // public data
    await appStore.actions.setupAsync();

    // authorized
    await appStore.actions.loadUserProfileAsync();
  } catch (ex) {
    MyLogger.error("boot init:", ex);
  } finally {
    LoadingUtil.hideLoading();
  }
});
