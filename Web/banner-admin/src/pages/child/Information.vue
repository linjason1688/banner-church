<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-child-layout title="註冊" subtitle="用戶資訊" step="2">
          <q-form @submit="gotoNext" class="q-gutter-y-md">
            <div class="app-wizard-information-table">
              <div class="column items-center">
                <div class="flex items-center justify-center app-wizard-information-caption">社群帳號</div>
              </div>
              <div class="app-wizard-information-content">
                <c-field label="Line">
                  <c-input placeholder="" v-model="form.lineId"></c-input>
                </c-field>
                <c-field label="Instagram">
                  <c-input placeholder="" v-model="form.instagramId"></c-input>
                </c-field>
                <c-field label="WeChat">
                  <c-input placeholder="" v-model="form.weChatId"></c-input>
                </c-field>
                <c-field label="其他">
                  <c-input placeholder="若沒有社群帳號請填寫：無" v-model="form.otherSocialId"></c-input>
                </c-field>
              </div>
            </div>

            <div class="app-wizard-information-table">
              <div class="column items-center">
                <div class="flex items-center justify-center app-wizard-information-caption">其他資訊</div>
              </div>
              <div class="app-wizard-information-content">
                <c-field label="身分證字號 (或居留證 / 護照號碼)">
                  <c-input placeholder="請輸入身分證字號或居留證 / 護照號碼" v-model="form.idNumber"></c-input>
                </c-field>
                <c-field label="電話 (市話)">
                  <c-input placeholder="輸入電話" v-model="form.phone"></c-input>
                </c-field>
              </div>
            </div>

            <div class="app-wizard-information-table">
              <div class="column items-center">
                <div class="flex items-center justify-center app-wizard-information-caption">居住地址</div>
              </div>
              <div class="app-wizard-information-content">
                <div>
                  <c-field label="國家">
                    <c-select v-model="form.liveCountry"
                              emit-value map-options :options="countryCodeList"
                              option-value="value"
                              option-label="name"
                    />
                  </c-field>
                </div>
                <div v-if="xform.domestic">
                  <div>
                    <c-field label="城市">
                      <c-select v-model="form.liveCity" emit-value map-options :options="cityCodeList"
                                option-value="value"
                                option-label="name"></c-select>
                    </c-field>
                  </div>
                  <div class="row">
                    <div class="q-pr-md" style="width: 50%">
                      <c-field label="地區">
                        <c-select v-model="form.liveZipArea" emit-value map-options :options="areaCodeList"
                                  option-value="value"
                                  option-label="name" />
                      </c-field>
                    </div>
                    <div style="width: 50%">
                      <c-field label="郵遞區號">
                        <c-input placeholder="" v-model="form.liveZipCode"></c-input>
                      </c-field>
                    </div>
                  </div>
                  <div>
                    <c-field label="詳細住址">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                    </c-field>
                  </div>
                </div>
                <div v-else>
                  <div>
                    <c-field label="住址1">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                    </c-field>
                  </div>

                  <div>
                    <c-field label="住址2">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress2"></c-input>
                    </c-field>
                  </div>
                  <div>
                    <c-field label="郵遞區號">
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
                <div class="text-subtitle1 inline-block">信仰狀態及受洗資料</div>
                <div class="inline-block app-required">*</div>

                <div>
                  <q-list>
                    <q-item tag="label" class="q-pa-none">
                      <q-item-section avatar>
                        <q-radio v-model="form.baptizedType" val="0" />
                      </q-item-section>
                      <q-item-section>
                        <q-item-label>已受洗</q-item-label>
                      </q-item-section>
                    </q-item>
                    <q-item class="q-pl-xl">
                      <q-item-section>
                        <q-list bordered>
                          <q-item>
                            <q-item-section>
                              <c-field class="col" label="受洗時間">
                                <c-date-picker v-model="form.baptizeday" />
                              </c-field>

                              <div class="app-wizard-subtitle">過去在哪個教會</div>

                              <q-list>
                                <q-item tag="label" class="q-pa-none">
                                  <q-item-section avatar>
                                    <q-radio v-model="form.churchType" val="0" />
                                  </q-item-section>
                                  <q-item-section>
                                    <q-item-label>旌旗教會</q-item-label>
                                  </q-item-section>
                                </q-item>

                                <q-item>
                                  <q-item-section>
                                    <c-select emit-value map-options :options="churchList" v-model="form.churchName"
                                              option-value="value"
                                              option-label="label" />
                                  </q-item-section>
                                </q-item>

                                <q-item tag="label" class="q-pa-none">
                                  <q-item-section avatar>
                                    <q-radio v-model="form.churchType" val="1" />
                                  </q-item-section>
                                  <q-item-section>
                                    <q-item-label>其他教會</q-item-label>
                                  </q-item-section>
                                </q-item>

                                <q-item tag="label">
                                  <q-item-section>
                                    <c-input placeholder="填入教會名稱" v-model="form.anotherChurchName"></c-input>
                                  </q-item-section>
                                </q-item>

                                <q-item tag="label">
                                  <q-item-section>
                                    <div>教會施洗者 (若為旌旗教會者)</div>
                                  </q-item-section>
                                </q-item>
                                <q-item>
                                  <q-item-section>
                                    <c-input placeholder="輸入施洗者姓名" v-model="form.baptizer"></c-input>
                                  </q-item-section>
                                </q-item>

                              </q-list>
                            </q-item-section>
                          </q-item>
                        </q-list>
                      </q-item-section>
                    </q-item>

                    <q-item tag="label" class="q-pa-none">
                      <q-item-section avatar>
                        <q-radio v-model="form.baptizedType" val="1" />
                      </q-item-section>
                      <q-item-section>
                        <q-item-label>未受洗</q-item-label>
                      </q-item-section>
                    </q-item>

                    <q-item tag="label" class="q-pa-none">
                      <q-item-section avatar>
                        <q-radio v-model="form.baptizedType" val="2" />
                      </q-item-section>
                      <q-item-section>
                        <q-item-label>其他</q-item-label>
                      </q-item-section>
                    </q-item>
                    <q-item class="q-pl-xl">
                      <q-item-section>
                        <c-input placeholder="填入其他狀態" v-model="form.otherComment"></c-input>
                      </q-item-section>
                    </q-item>
                  </q-list>
                </div>
                <div>
                  <div class="q-pa-xl text-center">
                    <q-field
                      v-model="form.isTerm"
                      :rules="[(val) => !!val || '請同意線上奉獻規範與個資使用說明']"
                      borderless
                      dense>
                      <template v-slot:control>
                        <q-checkbox v-model="form.isTerm" />
                        <div class="inline-block">我已詳細閱讀並同意</div>
                        <div class="inline-block app-link text-bold cursor-pointer" @click="showPrivacy()">
                          線上奉獻規範與個資使用說明
                        </div>
                      </template>
                    </q-field>
                  </div>
                </div>
                <c-privacyText :toggle-show="xform.togglePrivacy"></c-privacyText>
              </div>
            </div>

            <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
              <div>
                <q-btn label="上一步" class="app-verification-wizard-btn" :to="{ path: '/child/profile' }"></q-btn>
                <q-btn label="下一步" type="submit" class="app-verification-wizard-next-btn"></q-btn>
              </div>
            </div>
          </q-form>
        </c-child-layout>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop, Watch } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Layout from "pages/child/Layout.vue";
import { SystemConfig } from "src/util";
import { ChildSignUpState } from "src/data/dto/ChildSignUpState";
import { SystemConfigView } from "src/api/feature";
import { ref } from "vue";
import PrivacyText from "pages/signup/PrivacyText.vue";
import { TaiwanCountryCode } from "src/data/constants";

@Options({
  components: {
    "c-child-layout": Layout,
    "c-privacyText": PrivacyText,
  },
})
export default class Information extends ComponentBase {
  @Prop({ type: String })
  title!: string;
  cityCodeList: Array<SystemConfigView> = [];
  areaCodeList: Array<SystemConfigView> = [];
  countryCodeList: Array<SystemConfigView> = [];

  xform = {
    togglePrivacy: ref(false),
    domestic: true,
  };

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
    isBaptize: "",
    baptizedType: "",
    baptizeTypeId: "",
    baptizeday: "",
    churchType: "",
    anotherChurchName: "",
    orgName: "",
    baptizer: "",
    otherComment: "",
    isTerm: false,
  };

  @Watch("form.liveCountry", { immediate: true, deep: true })
  onLiveCountryChanged(val: string) {
    this.xform.domestic = val === TaiwanCountryCode;
  }

  @Watch("form.liveCity", { immediate: true, deep: true })
  onLiveCityChanged(val: string) {
    this.areaCodeList = this.$appStore.getters.getSystemConfig(`${SystemConfig.Zip}${val}`);
  }

  mounted() {
    this.form = Object.assign(this.form, this.$appStore.getters.childSignUpState);
    this.cityCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CityCode);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
  }

  gotoBack() {
    void this.$router.push("/child/profile");
  }

  async gotoNext() {
    let form = Object.assign({ ...this.$appStore.getters.childSignUpState }, this.form);
    this.$appStore.mutations.setChildSignUpState(form);
    await this.apis.feature.user.signUp(form);
    this.$appStore.mutations.setChildSignUpState({} as ChildSignUpState);
    void this.$router.push("/child/done");
  }

  showPrivacy() {
    this.xform.togglePrivacy = ref(true);
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
@import "../../css/app.scss";


.app-link {
  color: $blue-10;
}
</style>
