import { isString } from "lodash";
import { ApiEnum } from "src/data/constants/ApiEnums";
import { MyPrivilegeNodeView, PagedRequest } from "src/data/dto";
import { appModule } from "src/store/app-module";
import { InputValidators } from "src/util";
import { Vue } from "vue-class-component";

type AnyAsyncAction<T> = () => Promise<T>;
// eslint-disable-next-line @typescript-eslint/no-explicit-any
type AsyncRequestAction<T> = (request?: any) => Promise<T>;

export class ComponentBase extends Vue {
  // ========== data ==========

  // ========== computed ==========
  get $isDesktop(): boolean {
    return this.$q.screen.gt.sm;
  }

  get $isMobile(): boolean {
    return !this.$isDesktop;
  }

  get $appStore() {
    return appModule.context(this.$store);
  }

  get $apiEnums() {
    return ApiEnum;
  }

  get $validators() {
    return InputValidators;
  }

  /**
   * 目前 functionId node
   */
  get $privilege() {
    return this.$route.meta["$node"] as MyPrivilegeNodeView;
  }

  // ========== watch ==========

  // ========== methods ==========

  /**
   * auto save request params
   * use previous saved request params if passed request argument if null or undefined
   * @param action
   * @param request
   * @returns
   */
  async usePreviousRequestParamsAsync<T>(action: AsyncRequestAction<T>, request?: PagedRequest | unknown) {
    const rk = this.$route.path;
    const itemKey = `$.queryRequestParams.${rk}`;

    if (!request) {
      const val = this.localStorage.getItem(itemKey) || "{}";

      if (isString(val)) {
        request = JSON.parse(val);
      } else {
        request = val;
      }
    }

    const json = JSON.stringify(request || {});

    this.localStorage.set(itemKey, json);

    return await action(request);
  }

  async hideLoadingAsync() {
    await this.sleep(500);

    this.hideLoading();
  }

  windowOpen(url: string, currentWindow?: boolean) {
    const target = currentWindow ? "_self" : "_blank";

    window.open(url, target);
  }

  scrollTo(top: number, isSmooth = false) {
    const behavior = isSmooth ? "smooth" : "auto";

    window.scroll({
      top,
      behavior,
    });
  }

  deepClone<T>(val: unknown): T {
    return JSON.parse(JSON.stringify(val)) as T;
  }

  /**
   * 自動開啟 & 結束 loading
   * @param action
   */
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  async executeAsync<T>(action: AnyAsyncAction<T>, isGlobal: boolean = true, delayMs = 0): Promise<T> {
    this.showLoading();

    const now = new Date().getTime();

    if (delayMs > 0) {
      await this.sleep(delayMs);
    }

    try {
      return await action();
    } finally {
      const timeElapsed = new Date().getTime() - now;

      if (timeElapsed < 200) {
        await this.sleep(200);
      }

      this.hideLoading();
    }
  }

  // ========== listening ==========

  // ========== emit ==========
}
