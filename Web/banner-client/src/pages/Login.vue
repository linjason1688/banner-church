<template>
  <q-layout>
    <q-page-container>
      <q-page>
        <div style="background: #0c3178">
          <div class="column row-md window-height no-wrap">
            <div class="col column no-wrap">
              <img class="col-2 col-md-auto q-ma-md self-start" src="/img/logo.svg" alt="Logo" />
              <img class="col-6 q-ma-md" src="/img/main.svg" alt="Main" />
            </div>
            <div class="col-auto col-md flex flex-center q-pa-md" style="background: white">
              <q-form @submit="loginAsync" class="q-gutter-y-md">
                <div class="column items-center">
                  <div class="col app-login">登入</div>
                </div>
                <div class="column items-center">
                  <div class="app-tabs">
                    <div class="col-6 app-tab-item" @click="xform.isNewMember = true">
                      <div :class="newMemberClass">會員</div>
                    </div>
                    <div class="col-6 app-tab-item" @click="xform.isNewMember = false">
                      <div :class="oldMemberClass"></div>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="app-login-form-fields">
                    <img src="/img/username.svg" alt="Username" />
                    <div>帳號</div>
                  </div>
                  <div class="full-width">
                    <c-input type="text" v-model="form.account"
                             placeholder="帳號、身分證字號、手機、Email"
                             :rules="[(val) => !!val || '請輸入帳號、身分證字號、手機、Email']"
                    />
                  </div>
                </div>
                <div class="row">
                  <div class="app-login-form-fields">
                    <img src="/img/password.svg" alt="Password" />
                    <div>密碼</div>
                  </div>
                  <div class="full-width">
                    <c-input v-if="showPassword" type="input" v-model="form.password"
                             placeholder="請輸入密碼"
                             :rules="[(val) => !!val || '請輸入密碼']">
                      <template v-slot:append>
                        <q-avatar @click="toggleShow()">
                          <img class="eye" src="/img/eye.svg">
                        </q-avatar>
                      </template>
                    </c-input>
                    <c-input v-else type="password" v-model="form.password"
                             placeholder="請輸入密碼"
                             :rules="[(val) => !!val || '請輸入密碼']">
                      <template v-slot:append>
                        <q-avatar @click="toggleShow()">
                          <img class="eye" src="/img/eye-slash.svg">
                        </q-avatar>
                      </template>
                    </c-input>
                  </div>
                </div>
                <div class="row">
                  <div class="app-login-form-fields">
                    <img src="/img/code.svg" alt="Code" />
                    <div>驗證碼</div>
                  </div>
                  <div class="full-width">
                    <div class="row">
                      <c-input type="text" v-model="form.verificationCode"
                               placeholder="請輸入右方驗證碼"
                               style="width: 50%"
                               :rules="[(val) => !!val || '請輸入驗證碼']">
                      </c-input>
                      <img class="q-pa-md" :src="`${xform.image}`"
                           @click="switchCode()" />
                      <div class="q-pt-lg q-pb-md">點擊換一張</div>
                    </div>
                  </div>
                </div>
                <div class="column items-center">
                  <div class="col">
                    <input
                      class="app-login-signin-btn q-btn--actionable"
                      type="submit"
                      value="登入"
                      :disable="!$valid || disable"
                      :loading="disable"
                    />
                  </div>
                </div>
                <div class="column items-center">
                  <div class="row">
                    <div class="col app-forget-anything q-btn--actionable">
                      <c-btn flat label="忘記密碼" :to="{ path: '/resetpwd' }"></c-btn>
                    </div>
                    <div class="col app-forget-anything">|</div>
                    <div class="col app-forget-anything q-btn--actionable">
                      <c-btn flat label="忘記帳號" :to="{ path: '/findaccount' }"></c-btn>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col strike"><span>還不是會員嗎？</span></div>
                </div>
                <div class="column items-center">
                  <div class="row">
                    <input
                      class="app-login-signup-btn q-btn--actionable"
                      type="button"
                      value="註冊"
                      @click="gotoSignUp()"
                    />
                  </div>
                </div>
                <div class="column items-center">
                  <div class="row">
                    <div class="app-login-warning-text">*未滿 12 歲兒童,須由家長使用會員帳號登入後,另行註冊。</div>
                  </div>
                </div>
              </q-form>
            </div>
          </div>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ComponentBase } from "src/components/ComponentBase";
import { UserProfile } from "src/data/dto";
import Colon from "components/elementary/Colon.vue";
import { axiosInstance } from "src/api/AxiosInstance";

@Options({
  meta() {
    return {
      title: "登入",
    };
  },

  components: { Colon },
})
export default class LoginPage extends ComponentBase {
  disable = false;

  showPassword = false;

  xform = {
    isNewMember: true,
    image: "",
  };

  form = {
    account: "",
    password: "",
    verificationCode: "",
    verificationToken: "test-token",
  };

  get $valid(): boolean {
    const { account, password } = this.form;

    return !!account && !!password;
  }

  get newMemberClass() {
    return this.xform.isNewMember ? "app-tab" : "app-tab-inverse q-btn--actionable";
  }

  get oldMemberClass() {
    return this.xform.isNewMember ? "app-tab-inverse q-btn--actionable" : "app-tab";
  }

  async mounted() {
    await this.hideLoadingAsync();
    await this.switchCode();
  }

  async loginAsync() {
    this.disable = true;
    try {
      const store = this.$appStore;
      const signin = { ...this.form };
      const res = await this.apis.feature.user.signin(signin);
      const user = res.data.user;
      const profile = Object.assign({ ...user }, {
        id: user.id,
        name: user.name,
        account: user.account || user.name,
        jwt: res.data.jwt,
      });
      // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
      axiosInstance.defaults.headers["authorization"] = profile.jwt;
      console.log(profile, user);

      await store.actions.prepareUserAsync();
      await store.actions.loginAsync(profile as unknown as UserProfile)
    } catch (error) {
      void this.switchCode();
      throw error;
    } finally {
      this.disable = false;
    }

    if (!this.xform.isNewMember) {
      await this.$router.push("/signup/profile");
      return;
    }

    const path = this.$route.params["path"] as string;
    if (path) {
      await this.$router.push({
        path: path,
      });
      return;
    }

    await this.$router.push({
      path: "m/member/index",
    });
  }

  gotoSignUp() {
    void this.$appStore.actions.logoutAsync();
    void this.$router.push("/signup/profile");
  }

  async getVerificationCode() {
    const code = await this.apis.feature.user.getVerificationCode();
    return code.data;
  }

  toggleShow() {
    this.showPassword = !this.showPassword;
  }

  async switchCode() {
    let code = await this.getVerificationCode();
    this.xform.image = code.image;
    this.form.verificationToken = code.token;
    await this.apis.feature.user.getVerificationCode();
  }

}
</script>

<style lang="scss" scoped>
@import "../css/quasar.variables.scss";
@import "../css/app.scss";

.q-card {
  width: 100%;
}

.app-login {
  width: 48px;
  height: 32px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 24px;
  line-height: 32px;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #282828;
}

.app-tabs {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
  padding: 0px;
  height: 45px;
}

.app-imag-inline {
  display: inline-block;
  text-align: center;
}

.app-login-form {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  padding: 0px;
  gap: 4px;
  width: 470px;
  max-width: 470px;
}

.app-login-form-fields {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0px;
  gap: 12px;
  height: 20px;
  flex: none;
  order: 0;
  align-self: stretch;
  flex-grow: 0;
}

.app-login-form-inputs {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0px;
  gap: 12px;

  height: 20px;

  flex: none;
  order: 0;
  align-self: stretch;
  flex-grow: 0;
}

.app-login-form-input {
  width: 95%;
  height: 20px;

  /* Content/Body */

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 14px;
  line-height: 140%;
  /* identical to box height, or 20px */

  font-feature-settings: "tnum" on, "lnum" on;

  /* TextColor/38% */

  color: rgba(40, 40, 40, 0.38);

  /* Inside auto layout */

  flex: none;
  order: 0;
  flex-grow: 1;
}

.app-login-signin-btn {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 10px 16px;
  gap: 8px;

  width: 291px;
  height: 46px;
  /* Primary/500 */

  background: #0c3176;
  border-radius: 100px;
  color: #ffffff;
}

.app-forget-btns {
  margin-top: 24px;
}

.app-forget-anything {
  height: 22px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  line-height: 140%;
  /* or 22px */

  text-decoration-line: underline;
  font-feature-settings: "tnum" on, "lnum" on;

  /* Primary/500 */

  color: #0c3176;

  /* Inside auto layout */

  flex: none;
  order: 1;
  flex-grow: 0;
}

.app-forget-account {
  height: 22px;

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  line-height: 140%;
  /* or 22px */

  text-decoration-line: underline;
  font-feature-settings: "tnum" on, "lnum" on;

  /* Primary/500 */

  color: #0c3176;

  /* Inside auto layout */

  flex: none;
  order: 1;
  flex-grow: 0;
}

.app-login-signup-btn {
  box-sizing: border-box;

  /* Auto layout */

  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 10px 16px;
  gap: 8px;

  width: 291px;
  height: 46px;

  /* Gray/White */

  background: #ffffff;
  /* Primary/500 */

  border: 2px solid #0c3176;
  border-radius: 100px;

  /* Inside auto layout */

  flex: none;
  order: 0;
  flex-grow: 0;
  color: #0c3176;
}

.app-login-warning-text {
  width: 387px;
  height: 20px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 16px;
  line-height: 125%;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #008BAB;
  white-space: pre;
}

.app-login-not-member {
  width: 178px;
  height: 0;
  border: 1px solid rgba(40, 40, 40, 0.38);
  flex: none;
  order: 0;
  flex-grow: 1;
}

.app-login-not-member-text {
  width: 98px;
  height: 20px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 14px;
  line-height: 140%;
  font-feature-settings: "tnum" on, "lnum" on;
  color: rgba(40, 40, 40, 0.38);
  flex: none;
  order: 1;
  flex-grow: 0;
}

.strike {
  display: block;
  text-align: center;
  overflow: hidden;
  white-space: nowrap;
}

.strike > span {
  position: relative;
  display: inline-block;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 14px;
  line-height: 140%;
  /* identical to box height, or 20px */
  font-feature-settings: "tnum" on, "lnum" on;
  /* TextColor/38% */
  color: rgba(40, 40, 40, 0.38);
}

.strike > span:before,
.strike > span:after {
  content: "";
  position: absolute;
  top: 50%;
  width: 9999px;
  height: 0;
  border: 1px solid rgba(40, 40, 40, 0.38);
}

.strike > span:before {
  right: 100%;
  margin-right: 8px;
}

.strike > span:after {
  left: 100%;
  margin-left: 8px;
}

.eye {
  width: 20px !important;
  height: 20px !important;
}

.app-verification-code {
  width: 99px !important;
  height: 43px !important;
}
</style>
