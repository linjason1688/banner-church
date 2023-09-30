<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="用戶資訊" step="3">
          <template #caption>
            <div class="col column items-center">
              <div class="col app-wizard-success-text">驗證成功！請填寫其他資料</div>
            </div>
          </template>
          <template #default>
            <q-form @submit="gotoNext" class="q-gutter-y-md" @validation-error="onValidationError">
              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">社群帳號</div>
                </div>
                <div class="app-wizard-information-content">
                  <c-field stack-label label="社群帳號" required :rules="[societyRule]">
                    <p class="q-ma-none c-content-body">Line</p>
                    <c-input v-model="form.lineId"></c-input>
                    <p class="q-ma-none c-content-body">Instagram</p>
                    <c-input v-model="form.instagramId"></c-input>
                    <p class="q-ma-none c-content-body">WeChat</p>
                    <c-input v-model="form.weChatId"></c-input>
                    <p class="q-ma-none c-content-body">其他</p>
                    <c-input placeholder="若沒有社群帳號請填寫：無" v-model="form.otherSocialId"></c-input>
                  </c-field>
                </div>
              </div>

              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">其他資訊</div>
                </div>
                <div class="app-wizard-information-content">
                  <c-field stack-label label="身分證字號 (或居留證 / 護照號碼)">
                    <c-input placeholder="請輸入身分證字號或居留證 / 護照號碼" v-model="form.idNumber"></c-input>
                  </c-field>
                  <c-field stack-label label="電話 (市話)">
                    <c-input placeholder="輸入電話" v-model="form.phone"></c-input>
                  </c-field>
                </div>
              </div>

              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">居住地址</div>
                </div>
                <div class="app-wizard-information-content">
                  <div class="row">
                    <div class="col-12 col-md-6">
                      <c-field stack-label label="國家">
                        <c-select v-model="form.liveCountry" emit-value map-options :options="countryCodeList"
                          option-value="name" option-label="value" />
                      </c-field>
                    </div>
                  </div>
                  <div v-if="xform.domestic">
                    <div class="row">
                      <div class="col-12 col-md-6">
                        <c-field stack-label label="城市">
                          <c-select v-model="form.liveCity" emit-value map-options :options="cityCodeList"
                            option-value="name" option-label="value" role="signup">
                          </c-select>
                        </c-field>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-12 col-md-6">
                        <c-field stack-label label="地區">
                          <c-select v-model="form.liveZipArea" emit-value map-options :options="areaCodeList"
                            option-value="name" option-label="value" role="signup" />
                        </c-field>
                      </div>
                      <div class="col-12 col-md-6">
                        <c-field stack-label label="郵遞區號">
                          <c-input placeholder="" v-model="form.liveZipCode"></c-input>
                        </c-field>
                      </div>
                      <div class="col-12">
                        <c-field stack-label label="詳細住址">
                          <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                        </c-field>
                      </div>
                    </div>
                  </div>
                  <div v-else class="row">
                    <div class="col-12">
                      <c-field stack-label label="住址1">
                        <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                      </c-field>
                    </div>

                    <div class="col-12">
                      <c-field stack-label label="住址2">
                        <c-input placeholder="輸入地址" v-model="form.liveAddress2"></c-input>
                      </c-field>
                    </div>
                    <div class="col-12 col-md-6">
                      <c-field stack-label label="郵遞區號">
                        <c-input placeholder="" v-model="form.liveZipCode"></c-input>
                      </c-field>
                    </div>
                  </div>
                </div>
              </div>

              <div class="app-wizard-information-table">
                <div class="column items-center">
                  <div class="flex items-center justify-center app-wizard-information-caption">信仰資料</div>
                </div>
                <div class="app-wizard-information-content">
                  <c-form-group-baptized class="q-mx-md" v-model:baptizedType.sync="form.baptizedType"
                    v-model:baptizeday.sync="form.baptizeday" v-model:churchType.sync="form.churchType"
                    v-model:churchName.sync="form.churchName" v-model:anotherChurchName.sync="form.anotherChurchName"
                    v-model:baptizer.sync="form.baptizer"
                    v-model:otherComment.sync="form.otherComment"></c-form-group-baptized>

                  <c-privacyText v-model:toggleShow.sync="privacy"></c-privacyText>
                  <c-field stack-label label="旌旗主日聚會點" required>
                    <c-select v-model="form.meetingPointId" emit-value map-options :options="meetingPointList"
                      option-value="id" option-label="name" role="signup" />
                  </c-field>
                  <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
                    <div class="q-pa-xl text-center">
                      <q-field v-model="form.isTerm" :rules="[(val) => !!val || '請同意線上奉獻規範與個資使用說明']" borderless dense>
                        <template v-slot:control>
                          <q-checkbox v-model="form.isTerm" />
                          <div class="inline-block">我已詳細閱讀並同意</div>
                          <div class="inline-block app-link text-bold cursor-pointer" @click="showPrivacy()">
                            線上奉獻規範與個資使用說明
                          </div>
                        </template>
                      </q-field>
                    </div>
                    <div>
                      <q-btn label="上一步" class="app-verification-wizard-btn" @click="gotoBack()" />
                      <q-btn label="下一步" class="app-verification-wizard-next-btn" type="submit"></q-btn>
                    </div>
                  </div>
                </div>
              </div>
            </q-form>
          </template>
        </c-wizard>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Watch } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Wizard from "pages/signup/Wizard.vue";
import { SystemConfig } from "src/util";
import { FetchAllMeetingPointRequest, MeetingPointApi, MeetingPointApiInterface, MeetingPointBase, MeetingPointView, MeetingPointViewListApiResponse, OrganizationBase, OrganizationViewListApiResponse, SystemConfigView } from "src/api/feature";
import { ref } from "vue";
import PrivacyText from "pages/signup/PrivacyText.vue";
import { TaiwanCountryCode } from "src/data/constants";
import FormOrganization2 from "components/business/FormOrganization2.vue";
import { scroll } from "quasar";

const { getScrollTarget, setVerticalScrollPosition } = scroll;

@Options({
  components: {
    "c-wizard": Wizard,
    "c-privacyText": PrivacyText,
    "c-form-organization": FormOrganization2,
  },
})
export default class Information extends ComponentBase {
  taiwanCountryCode = TaiwanCountryCode;
  meetingPointList: Array<MeetingPointView> = [];
  churchList = [
    {
      label: "台中",
      value: "0",
    },
    {
      label: "台北",
      value: "1",
    },
  ];
  cityCodeList: Array<SystemConfigView> = [];
  areaCodeList: Array<SystemConfigView> = [];
  countryCodeList: Array<SystemConfigView> = [];

  xform = {
    togglePrivacy: ref(false),
    domestic: true,
  };

  privacy = false;

  form = {
    lineId: "",
    weChatId: "",
    instagramId: "",
    otherSocialId: "",
    idNumber: "",
    phone: "",
    liveCountry: "",
    liveCity: "",
    liveZipArea: "",
    liveZipCode: "",
    liveAddress: "",
    liveAddress2: "",
    isTerm: false,

    //信仰狀態及受洗資料
    baptizedType: "",
    baptizeday: "",
    churchType: "",
    churchName: "",
    anotherChurchName: "",
    baptizer: "",
    otherComment: "",
    meetingPointId: "",
  };

  @Watch("form.liveCountry", { immediate: true, deep: true })
  onLiveCountryChanged(val: string) {
    this.xform.domestic = val === this.taiwanCountryCode;
  }

  @Watch("form.liveCity", { immediate: true, deep: true })
  onLiveCityChanged(val: string) {
    this.areaCodeList = this.$appStore.getters.getSystemConfig(`${SystemConfig.Zip}${val}`);
  }

  @Watch("form.liveZipArea", { immediate: true, deep: true })
  onLiveZipAreaChanged(val: string) {
    this.form.liveZipCode = val;
  }

  @Watch("form.anotherChurchName", { immediate: true, deep: true })
  onAnotherChurchNameChanged(val: string) {
    console.log(val);
    if (val) {
      this.form.churchType = "1";
    }
    //
  }

  @Watch("form.churchName", { immediate: true, deep: true })
  onChurchNameChanged(val: string) {
    console.log(val);
    //
    if (val) {
      this.form.churchType = "0";
    }
  }

  async mounted() {
    this.meetingPointList = (await this.apis.feature.meetingPoint.fetchMeetingPoints2()).data;
    this.form = Object.assign(this.form, this.$appStore.getters.signUpState);
    console.log("ccecde", this.$appStore.getters.signUpState)
    this.cityCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CityCode);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
  }

  gotoNext() {
    this.saveState();
    void this.$router.push("/signup/group");
  }

  gotoBack() {
    this.saveState();
    void this.$router.push("/signup/verification");
  }

  saveState() {
    let form = Object.assign({ ...this.$appStore.getters.signUpState }, this.form);
    this.$appStore.mutations.setSignUpState(form);
  }

  showPrivacy() {
    console.log(this.xform.togglePrivacy);
    this.privacy = true;
  }

  societyRule() {
    if (this.form.lineId || this.form.instagramId || this.form.weChatId || this.form.otherSocialId) {
      return true;
    }
    return "社群帳號為必填";
  }

  baptizedTypeRule() {
    if (this.form.baptizedType) {
      return true;
    }
    return "請選擇信仰狀態";
  }

  /* eslint-disable*/
  onValidationError(ref: any) {
    //scroll to error element
    var el = ref.$el;

    //元素距離頁面頂部距離
    var offset = el.getBoundingClientRect().top + window.pageYOffset;
    // console.log(offset)
    var duration = 200;
    setVerticalScrollPosition(getScrollTarget(el), offset, duration);
  }
  /* eslint-enable*/
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
@import "../../css/app.scss";

.app-form-caption {
  width: 192px;
  height: 22px;

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  line-height: 140%;

  font-feature-settings: "tnum" on, "lnum" on;

  color: #aa9159;
}

.app-wizard-success-text {
  margin-top: 24px;
  margin-bottom: 24px;
  width: 192px;
  height: 22px;

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  line-height: 140%;

  font-feature-settings: "tnum" on, "lnum" on;

  color: #aa9159;
}

.app-wizard-subtitle {
  padding-bottom: 16px;
  padding-top: 16px;
}

.app-link {
  color: $blue-10;
}
</style>
