<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-child-layout title="註冊" subtitle="用戶資訊" step="2">
          <q-form @submit="gotoNext" class="q-gutter-y-md">
            <div class="app-wizard-information-table">
              <div class="column items-center">
                <div class="flex items-center justify-center app-wizard-information-caption">身分證字號與電話</div>
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
                <div>
                  <c-field stack-label label="國家">
                    <c-select v-model="form.liveCountry" emit-value map-options :options="countryCodeList"
                      option-value="name" option-label="value" />
                  </c-field>
                </div>
                <div v-if="xform.domestic">
                  <div>
                    <c-field stack-label label="城市">
                      <c-select v-model="form.liveCity" emit-value map-options :options="cityCodeList" option-value="name"
                        option-label="value"></c-select>
                    </c-field>
                  </div>
                  <div class="row">
                    <div class="q-pr-md" style="width: 50%">
                      <c-field stack-label label="地區">
                        <c-select v-model="form.liveZipArea" emit-value map-options :options="areaCodeList"
                          option-value="name" option-label="value" />
                      </c-field>
                    </div>
                    <div style="width: 50%">
                      <c-field stack-label label="郵遞區號">
                        <c-input placeholder="" v-model="form.liveZipCode"></c-input>
                      </c-field>
                    </div>
                  </div>
                  <div>
                    <c-field stack-label label="詳細住址">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                    </c-field>
                  </div>
                </div>
                <div v-else>
                  <div>
                    <c-field stack-label label="住址1">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
                    </c-field>
                  </div>

                  <div>
                    <c-field stack-label label="住址2">
                      <c-input placeholder="輸入地址" v-model="form.liveAddress2"></c-input>
                    </c-field>
                  </div>
                  <div>
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
                <c-field stack-label label="旌旗主日聚會點" required>
                  <c-select v-model="form.meetingPointId" emit-value map-options :options="meetingPointList"
                    option-value="id" option-label="name" role="signup" />
                </c-field>
                <div>
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
import { RelativeType, SystemConfig } from "src/util";
import { ChildSignUpState } from "src/data/dto/ChildSignUpState";
import { CreateUserFamilyCommand, SystemConfigView, MeetingPointView, CourseTimeScheduleApi, } from "src/api/feature";
import { ref } from "vue";
import PrivacyText from "pages/signup/PrivacyText.vue";
import { TaiwanCountryCode } from "src/data/constants";
import { SignUpCommand } from "src/api/management";

interface Relative$ {
  relativeType: string;
  name: string;
}

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

  meetingPointList: Array<MeetingPointView> = [];

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

    //信仰狀態及受洗資料
    baptizedType: "",
    baptizeday: "",
    churchType: "",
    churchName: "",
    anotherChurchName: "",
    baptizer: "",
    otherComment: "",
    meetingPointId: "",

    isTerm: false,
    userFamilies: new Array<Relative$>(),
  };

  @Watch("form.liveCountry", { immediate: true, deep: true })
  onLiveCountryChanged(val: string) {
    this.xform.domestic = val === TaiwanCountryCode;
    console.log(this.xform.domestic)
  }

  @Watch("form.liveZipArea", { immediate: true, deep: true })
  onLiveZipAreaChanged(val: string) {
    this.form.liveZipCode = val;
    console.log(this.form.liveZipCode)
  }

  @Watch("form.liveCity", { immediate: true, deep: true })
  onLiveCityChanged(val: string) {
    this.areaCodeList = this.$appStore.getters.getSystemConfig(`${SystemConfig.Zip}${val}`);
    console.log(this.areaCodeList)
  }

  async mounted() {
    this.meetingPointList = (await this.apis.feature.meetingPoint.fetchMeetingPoints2()).data;

    this.form = Object.assign(this.form, this.$appStore.getters.childSignUpState);
    this.cityCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CityCode);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
  }

  gotoBack() {
    void this.$router.push("/child/profile");
  }

  async gotoNext() {
    let parentUserId = this.$appStore.getters.userProfile.id;
    let parent = (await this.apis.feature.user.getUser(parentUserId)).data;
    if (parent === null) {
      throw new Error(`cannot find parent user id. ${this.$appStore.getters.userProfile.id}`);
    }

    let form = Object.assign({ ...this.$appStore.getters.childSignUpState }, this.form);
    this.$appStore.mutations.setChildSignUpState(form);

    let signUpCommand = Object.assign({}, form) as unknown as SignUpCommand;
    signUpCommand.parentUserId = parentUserId;
    if (signUpCommand.userFamilies === null) {
      signUpCommand.userFamilies = Array<CreateUserFamilyCommand>();
    }

    // 建立父母關係
    signUpCommand.userFamilies = Array<CreateUserFamilyCommand>();
    signUpCommand.userFamilies = Object.assign(
      [],
      [
        {
          relativeType: parent.genderType == "1" ? RelativeType.Father : RelativeType.Mother,
          name: parent.firstName + parent.lastName,
        } as unknown as CreateUserFamilyCommand,
      ]
    );
    await this.apis.feature.user.signUp(signUpCommand);

    // 建立兒童關係
    if (
      !parent.userFamilies.some((e) => e.memo == signUpCommand.name && e.relativeType == RelativeType.Child.toString())
    ) {
      parent.userFamilies.push({
        relativeType: RelativeType.Child,
        name: signUpCommand.firstName + signUpCommand.lastName,
        memo: signUpCommand.name,
      } as unknown as CreateUserFamilyCommand);
      await this.apis.feature.user.updateMember(parentUserId, parent as unknown as SignUpCommand);
    }

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
