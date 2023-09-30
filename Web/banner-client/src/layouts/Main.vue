<template>
  <q-layout view="hHh lpr fFf" class="c-background-content">
    <!-- ========== header ========== -->
    <q-header class="c-header-bgcolor" elevated>
      <q-toolbar>
        <q-btn @click="isLeftDrawerShow = !isLeftDrawerShow" icon="menu" dense flat round />

        <q-toolbar-title>
          <q-avatar size="60px">
            <img src="/img/logo.svg" />
          </q-avatar>
          <q-btn class="c-heading-h5" stretch flat label="會員中心" :to="{ path: '/m/member/index' }" />
          <q-btn class="c-heading-h5" stretch flat label="課程選購" :to="{ path: '/m/class/index' }" />
          <q-btn class="c-heading-h5" stretch flat label="課程管理 (線上/實體)" :to="{ path: '/m/class/manage/index' }" />
          <q-btn class="c-heading-h5" stretch flat label="網路學校" :to="{ path: '/m/school/index' }" />
          <q-btn class="c-heading-h5" stretch flat label="事工團" :to="{ path: '/m/working/group/index' }" />
          <q-btn class="c-heading-h5" stretch flat label="問卷填寫" :to="{ path: '/m/questionnaire/index' }" />
        </q-toolbar-title>

        <q-btn rounded class="c-bgcolor-gray-white c-primary-color-500 text-bold q-mx-sm" @click="gotoAdmin()">
          進入後台
        </q-btn>

        <!-- log -->
        <q-btn icon="lightbulb" color="white" flat round>
          <q-menu :offset="[0, 8]" anchor="bottom right" self="top right" auto-close>
            <q-list>
              <template v-for="item in $appMessages" :key="item.id">
                <q-item v-close-popup clickable>
                  <q-item-section @click="copyLog(item)">
                    <pre class="i-force-word-break" :class="item.level === 'error' ? 'msg-error' : 'msg-warning'">{{
                        item.message
                      }}</pre>
                    <br />
                    {{ item.ocurredAt }}
                  </q-item-section>
                </q-item>
                <q-separator />
              </template>
            </q-list>
          </q-menu>
        </q-btn>

        <!-- 使用者資訊 -->
        <q-btn :label="$profile.name" color="white" no-caps flat rounded>
          <q-avatar size="30px" class="order-first q-mr-sm">
            <q-img
              :src="'https://placeimg.com/50/50/people'"
              :placeholder-src="'https://placeimg.com/50/50/tech'"
              spinner-color="primary"
              spinner-size="20px"
              transition="rotate"
            />
          </q-avatar>

          <q-menu :offset="[0, 8]" anchor="bottom right" self="top right" auto-close fit>
            <q-list dense bordered padding>
              <q-item v-ripple>
                <q-item-section>
                  <q-btn @click="childSignUp" label="為12歲以下兒童註冊" class="full-width" flat
                         v-if="isAdult" />
                  <q-btn @click="changePwd" label="修改密碼" class="full-width" flat />
                  <q-btn @click="logoutAsync" label="登出" class="full-width" flat />
                </q-item-section>
              </q-item>
            </q-list>
          </q-menu>
        </q-btn>
      </q-toolbar>
    </q-header>

    <!-- ========== page ========== -->
    <q-page-container>
      <router-view />
    </q-page-container>

    <!-- ========== footer ========== -->
    <q-footer class="bg-grey-9 text-white" bordered reveal style="border-color: #e0dfdf">
      <q-toolbar>
        <q-toolbar-title>
          <div class="row app-footer-panel">
            <div class="col-auto">
              <q-avatar size="100px" style="height:50px;">
                <img src="/img/logo.svg" />
              </q-avatar>
            </div>
            <div class="col row flex-center">
              <div>
                <div class="app-footer-text wrap">總體異象 新婦教會 ˙ 活出命定 世代傳承 ˙ 普世宣教</div>
                <div class="app-footer-text wrap">
                  地址：408 台中市南屯區文心南五路三段160號 | 電話：04 - 2258 - 4446 | 傳真：04 - 2258 -4660
                </div>
              </div>
            </div>
            <div class="col-auto row">
              <div class="flex justify-center q-pa-md q-gutter-sm">
                <q-btn href="mailto: info@wwbch.org" flat round size="sm" padding="none">
                  <img src="../../public/img/footer_mail.svg" alt="mail" />
                </q-btn>
                <q-btn href="https://www.facebook.com/TCBCH" target="_blank" flat round size="sm" padding="none">
                  <img src="../../public/img/facebook.svg" alt="facebook" />
                </q-btn>
                <q-btn
                  href="https://www.instagram.com/bannerch.media/"
                  target="_blank"
                  flat
                  round
                  size="sm"
                  padding="none"
                >
                  <img src="../../public/img/instagram.svg" alt="instagram" />
                </q-btn>
                <q-btn href="https://www.youtube.com/user/bannerch" target="_blank" flat round size="sm" padding="none">
                  <img src="../../public/img/player.svg" alt="player" />
                </q-btn>
                <q-btn href="https://soundcloud.com/bannerchurch" target="_blank" flat round size="sm" padding="none">
                  <img src="../../public/img/cloud.svg" alt="cloud" />
                </q-btn>
                <q-btn href="https://line.me/R/ti/p/%40bannerch" target="_blank" flat round size="sm" padding="none">
                  <img src="../../public/img/line.svg" alt="line" />
                </q-btn>
              </div>
            </div>
          </div>
        </q-toolbar-title>
      </q-toolbar>
      <c-goto-top></c-goto-top>
    </q-footer>
  </q-layout>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ComponentBase } from "src/components/ComponentBase";
import { copyToClipboard } from "quasar";
import { env } from "src/env.config";
import Menu from "src/components/Menu.vue";
import GotoTop from "src/components/elementary/GotoTop.vue";
import { AppMessage } from "src/data/dto";
// import { Prop } from "vue-property-decorator";
import { findNearestColor } from "src/util/ColorPalette";
declare global { interface Window { findNearestColor: (a:string) => void; } } window.findNearestColor = findNearestColor;

@Options({
  meta() {
    return {
      title: "",
    };
  },

  components: {
    "c-menu": Menu,
    "c-goto-top": GotoTop,
  },
})
export default class MainLayout extends ComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  // versionNo = process.env.VERSION;

  isLeftDrawerShow = false;

  apiVersion: string = "";

  isAdult = false;

  get appVersion() {
    if ("production" === env.env) {
      return env.version;
    }

    return `${env.version} (${env.env})`;
  }

  get $profile() {
    return this.$appStore.state.userProfile;
  }

  get $appMessages() {
    return this.$store.state.app.appMessages;
  }

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========

  created() {
    //
  }

  async mounted() {
    //
    const res = await this.apis.feature.appMetrics.getAppVersionAsync();

    this.apiVersion = res.data;

    this.isAdult = await this.checkAudit();
  }

  getAge(birthday: string) {
    //出生时间 毫秒
    let birthDayTime = new Date(birthday).getTime();
    //当前时间 毫秒
    let nowTime = new Date().getTime();
    //一年毫秒数(365 * 86400000 = 31536000000)
    return Math.ceil((nowTime - birthDayTime) / 31536000000);
  }

  async checkAudit() {
    let user = await this.apis.feature.user.getUser(this.$appStore.getters.userProfile.id);
    if (user.data.birthday) {
      return this.getAge(user.data.birthday) > 12
    }
    return false;
  }

  // ========== methods ==========
  async copyLog(item: AppMessage) {
    let info = item.message;
    if (this.appVersion) {
      info = `${info}\n client: ${this.appVersion}`;
    }

    if (this.apiVersion) {
      info = `${info}\n api: ${this.apiVersion}`;
    }

    const identity = this.$appStore.state.userProfile;

    if (identity.id) {
      // TODO:
      // info = `${info}\n resport by: ${identity.account} (${identity.deptId})`;
    }

    await copyToClipboard(info);

    this.showSuccessNotify("複製成功");
  }

  async logoutAsync() {
    //
    await this.$appStore.actions.logoutAsync();
    void this.$router.push("/Login");
  }

  childSignUp() {
    void this.$router.push("/child/profile");
  }

  gotoAdmin() {
    window.location.replace("https://gamma.jetsion.com/Login");
  }

  changePwd() {
    void this.$router.push("/changepwd");
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped>
::v-deep.q-tree {
  .q-tree__node-header {
    flex-direction: row-reverse;
  }
}

.msg-warning {
  color: $blue-10;
}

.msg-error {
  color: $red-10;
}

.app-footer-text {
  padding-bottom: 4px;
  padding-top: 4px;

  /* Content/Body */

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 14px;
  line-height: 140%;
  /* identical to box height, or 20px */

  font-feature-settings: "tnum" on, "lnum" on;

  /* Gray/White */
  color: #ffffff;
}

.app-footer-panel {
  padding-top: 12px;
  padding-bottom: 12px;
}
</style>
