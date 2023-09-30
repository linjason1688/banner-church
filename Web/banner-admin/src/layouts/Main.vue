<template>
  <q-layout view="lHh Lpr fFf">
    <!-- ========== header ========== -->
    <q-header class="text-white bg-white" unelevated>
      <div class="flex q-py-sm">
        <!-- <small class="text-grey q-mx-md self-end">{{ apiVersion }} / {{ appVersion }}</small> -->
        <q-space />
        <q-btn class="q-mx-md" color="indigo" @click="gotoApp()">進入前台</q-btn>
        <q-btn icon="lightbulb" color="grey" flat round>
          <q-menu :offset="[0, 8]" anchor="bottom right" self="top right" auto-close>
            <template v-for="item in $appMessages" :key="item.id">
              <q-item v-close-popup clickable>
                <q-item-section @click="copyLog(item)">
                  <pre class="i-force-word-break"
                    :class="item.level === 'error' ? 'msg-error' : 'msg-warning'">{{ item.message }}</pre>
                  {{ item.ocurredAt }}
                </q-item-section>
              </q-item>
              <q-separator />
            </template>
          </q-menu>
        </q-btn>
        <!-- 使用者資訊 -->
        <q-btn :label="$profile.name" color="black" no-caps flat rounded>
          <q-avatar size="30px" class="order-first q-mr-sm">
            <q-img :src="'https://placeimg.com/50/50/people'" :placeholder-src="'https://placeimg.com/50/50/tech'"
              spinner-color="primary" spinner-size="20px" transition="rotate" />
          </q-avatar>
          <q-menu :offset="[0, 8]" anchor="bottom right" self="top right" auto-close fit>
            <q-list dense bordered padding>
              <q-item v-ripple>
                <q-item-section>
                  <q-btn @click="logoutAsync" label="登出" class="full-width" flat />
                </q-item-section>
              </q-item>
            </q-list>
          </q-menu>
        </q-btn>
      </div>
      <q-separator />
    </q-header>

    <!-- ========== menu ========== -->
    <q-drawer class="flex no-wrap" :model-value="true" :width="320" :breakpoint="0">
      <div class="text-white bg-cyan-9">
        <div class="text-center q-my-md">
          <img src="/img/logo-icon.svg" />
        </div>
        <q-tabs v-model="tab" vertical style="height:auto">
          <q-tab v-for="item in $privilegeList" :key="item.name" :name="item.name" :label="item.name"
            :icon="'img:/img/' + (item.icon || 'lesson') + '.svg'">
          </q-tab>
        </q-tabs>
      </div>
      <div class="bg-grey-2" style="padding-top:58px; width: 250px">
        <EssentialLink v-for="item in expansionPanels" :key="item.title" v-bind="item" />
      </div>
    </q-drawer>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ComponentBase } from "src/components/ComponentBase";
import { copyToClipboard } from "quasar";
import { env } from "src/env.config";
import GotoTop from "src/components/elementary/GotoTop.vue";
import { AppMessage } from "src/data/dto";
import { isProxy, toRaw } from "vue";
import EssentialLink from "components/EssentialLink.vue";

@Options({
  meta() {
    return {
      title: "",
    };
  },
  components: {
    "c-goto-top": GotoTop,
    EssentialLink,
  },
})
export default class MainLayout extends ComponentBase {
  // ========== props ==========
  tab = "牧養管理";
  get expansionPanels() {
    switch (this.tab) {
      case "牧養管理": return [
        {
          sticky: true,
          title: "牧養管理",
          children: [{
            title: "成人會友資料管理",
            link: { path: "/m/member/list" },
          }],
        },
        {
          title: "牧養組織管理與設定",
          children: [{
            title: "牧養職分設定-新增/編輯",
            link: { path: "/m/ministry-resp" },
          }],
        },
        {
          title: "牧養組織階層管理",
          children: [{
            title: "牧養組織階層管理-新增/編輯",
            link: { path: "/m/organization" },
          }],
        },
        {
          title: "兒童會友資料管理",
          children: [{
            title: "兒童會友資料管理-編輯",
            link: { path: "/m/child-member/list" },
          }, {
            title: "兒童會友資料管理-匯出",
            link: { path: "/m/child-member/list" },
          }],
        },
      ];
      case "課程": return [
        {
          title: "課程資料庫",
          sticky: true,
          children: [{
            title: "課程分類管理",
            link: { path: "/m/course-management-type/list" },
          }, {
            title: "永久課程管理",
            children: [{
              title: "建立課程資訊",
              link: { path: "/m/course-management/list" },
              children: [],
            }, {
              title: "設定課程擋修與上課對象",
              link: { path: "/m/course-filter/list" },
              children: [],
            }],
          }, {
            title: "永久課程報表",
            children: [{
              title: "永久課程清單",
              link: { path: "/m/course-export/list" },
              children: [],
            }, {
              title: "課程歷屆開課明細與次數統計",
              link: { path: "/wip" },
              children: [],
            }],
          }],
        },
        {
          title: "課程電商管理",
          children: [{
            title: "開課上架管理",
            children: [{
              title: "開課管理",
              link: { path: "/m/course/list" },
              children: [],
            }, {
              title: "課程優惠設定",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "FAQ設定",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "客服聯絡資訊設定與重大事故申請表件上傳",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "電子收據協會 / 堂點設定作業",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "電子收據內容設定作業",
              link: { path: "/wip" },
              children: [],
            }],
          }, {
            title: "課程報名管理",
            children: [{
              title: "課程報名管理",
              link: { path: "/m/course-signup/list" },
              children: [],
            }, {
              title: "後台報名管理",
              link: { path: "/wip" },
              children: [],
            }],
          }, {
            title: "櫃台收費",
            children: [{
              title: "訂單查詢",
              link: { path: "/m/order-query/list" },
              children: [],
            }, {
              title: "訂單收費報表",
              link: { path: "/wip" },
              children: [],
            }],
          }, {
            title: "訂單管理",
            children: [{
              title: "訂單總覽 (課程)",
              link: { path: "/m/shopping-order/list" },
              children: [],
            }, {
              title: "對帳管理 (財務)",
              link: { path: "/m/order/list" },
              children: [],
            }],
          }, {
            title: "退費管理 (課程)",
            children: [{
              title: "設定 / 指定同工處理退費 (課程)",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "申請退費訂單查詢與匯出 (課程)",
              link: { path: "/wip" },
              children: [],
            }, {
              title: "申請退費訂單查詢與匯出 (財務)",
              link: { path: "/wip" },
              children: [],
            }],
          }, {
            title: "課程報表",
            link: { path: "/wip" },
          }, {
            title: "課程資訊總覽",
            link: { path: "/wip" },
          }],
        },
        {
          title: "課程管理 (實體 / 線上)",
          link: "https://forum.quasar.dev",
          children: [{
            title: "課程管理",
            link: "/wip",
            children: [{
              title: "課程資訊",
              link: { path: "/m/course-query/list" },
            }, {
              title: "課程作業區",
              link: "/wip",
              children: [],
            }, {
              title: "出勤紀錄",
              link: "/wip",
              children: [],
            }, {
              title: "結業狀態",
              link: "/wip",
              children: [],
            }, {
              title: "結業証明書參數設定",
              link: "/wip",
              children: [],
            }],
          }, {
            title: "學員移轉",
            link: "/wip",
            children: [],
          }, {
            title: "課程統計表",
            link: "/wip",
            children: [],
          }],
        },
        {
          title: "網路學校管理",
          link: "https://forum.quasar.dev",
          children: [{
            title: "課程管理",
            link: "/wip",
            children: [{
              title: "課程資訊",
              link: { path: "/m/course-query/list" },
              children: [],
            }, {
              title: "結業狀態",
              link: "/wip",
              children: [],
            }, {
              title: "結業証明書參數設定",
              link: "/wip",
              children: [],
            }],
          }, {
            title: "學員移轉",
            link: "/wip",
            children: [],
          }, {
            title: "課程統計表",
            link: "/wip",
            children: [],
          }],
        },
      ];
      case "LINE": return [
        {
          sticky: true,
          title: "QRCODE匯出作業（報到QRCode生成）",
          children: [{
            title: "兒童個人報到專用",
            link: { path: "/wip" },
          }, {
            title: "小組報到",
            link: { path: "/wip" },
          }, {
            title: "主日報到",
            link: { path: "/wip" },
          }, {
            title: "領袖之夜報到",
            link: { path: "/wip" },
          }, {
            title: "課程報到 QR Code",
            link: { path: "/wip" },
          }, {
            title: "事工團報到",
            link: { path: "/wip" },
          }, {
            title: "問卷填寫",
            link: { path: "/wip" },
          }],
        },
      ];
      case "事工團管理": return [
        {
          sticky: true,
          title: "事工團類別設定管理",
          children: [{
            title: "事工團類別設定管理-新增/編輯",
            link: { path: "/m/ministry/def/list" },
          }],
        },
        {
          title: "事工團基本資料管理",
          children: [{
            title: "事工團基本資料管理-新增/編輯",
            link: { path: "/m/ministry/list" },
          }],
        },
      ]
      case "問卷管理": return [
        {
          sticky: true,
          title: "問卷設定",
          children: [{
            title: "問卷設定-新增/編輯(題目)",
            link: { path: "/m/questionnaire/list" },
          }, {
            title: "問卷設定-新增/編輯(對象)",
            link: { path: "/m/questionnaire/list" },
          }],
        },
      ]
      case "系統管理": return [
        {
          title: "帳號管理",
          sticky: true,
          children: [{
            title: "帳號管理-編輯",
            link: { path: "/m/user" },
          }],
        },
        {
          title: "角色權限設定",
          children: [{
            title: "角色設定-新增/編輯",
            link: { path: "/m/role" },
          }, {
            title: "角色權限設定-新增/編輯",
            link: { path: "/m/role/privilege" },
          }],
        },
        {
          title: "家庭樹管理",
          link: { path: "/m/organization-diagram/family" },
          children: [],
        },
        {
          title: "牧養組織與職分管理",
          link: { path: "/m/organization-diagram/ministry" },
        },
        {
          title: "牧養組織與職分列表",
          link: { path: "/m/organization-diagram/list" },
        },
        {
          title: "聚會點組織管理",
          link: { path: "/m/organization-diagram" },
        },
      ];
    }
  }
  apiVersion: string = "";
  get appVersion() {
    if ("production" === env.env) {
      return env.version;
    }
    return `${env.version} (${env.env})`;
  }

  get state() {
    return this.$appStore.state;
  }

  get $privilegeList() {
    return ["牧養管理", "課程", "LINE", "事工團管理", "問卷管理", "系統管理"].map(name => ({ name }));
    const { privilegeList = [] } = this.$appStore.state;
    if (isProxy(privilegeList)) {
      const rawData = toRaw(privilegeList);
      return rawData;
    }

    return privilegeList;
  }

  get $profile() {
    return this.$appStore.state.userProfile;
  }
  get $appMessages() {
    return this.$store.state.app.appMessages;
  }
  async mounted() {
    void this.$router.push("/m/member/list");
    const res = await this.apis.feature.appMetrics.getAppVersionAsync();
    this.apiVersion = res.data;
    this.tab = this.$privilegeList[0].name;
  }
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
    await this.$appStore.actions.logoutAsync();
    void this.$router.push("/Login");
  }
  gotoApp() {
    window.location.replace("https://banner-app.jetsion.com/Login");
  }
}
</script>