<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-child-layout title="為12歲以下兒童註冊" subtitle="個人基本資料" requiredMark="1" step="1">
          <q-form @submit="gotoNext" class="q-gutter-y-md" @validation-error="onValidationError">
            <div>
              <c-field stack-label label="帳號">
                <c-input placeholder="請輸入帳號" ref="usernameField" v-model="form.name"
                  :rules="[(val) => !!val || '請輸入帳號', idExistedRule]" lazy-rules="ondemand"
                  @keyup="onFieldChanged('usernameField')"></c-input>
              </c-field>
              <c-field stack-label label="密碼">
                <c-input placeholder="請輸入8-12位英數字" v-model="form.password" type="password" :rules="[
                    (val) => !!val || '請輸入密碼',
                    (val) => (val.length >= 8 && val.length <= 12) || '請輸入密碼8-12位英數字',
                    (val) => /^\w+$/.test(val) || '密碼只允許英數字',
                  ]" lazy-rules></c-input>
              </c-field>
              <c-field stack-label label="確認密碼">
                <c-input placeholder="請再次確認密碼" v-model="xform.confirmPassword" type="password" :rules="[
                    (val) => !!val || '請輸入密碼',
                    (val) => (val.length >= 8 && val.length <= 12) || '請輸入密碼8-12位英數字',
                    (val) => /^\w+$/.test(val) || '密碼只允許英數字',
                  ]" lazy-rules></c-input>
              </c-field>
              <c-field stack-label label="手機">
                <div class="row q-mt-md">
                  <div class="col-12">
                    <c-option-group :options="phoneTypeList" v-model="form.phoneType" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <c-select class="inline-block full-width" emit-value map-options :options="countryCodeList"
                      v-model="form.cellAreaCode1" option-value="name"
                      :option-label="(opt) => (opt === '' ? '請選擇區碼' : '+' + opt.name + ' ' + opt.value)"
                      :rules="[(val) => !!val || '請選擇區碼']" lazy-rules />
                  </div>
                  <div class="col-8">
                    <c-input placeholder="輸入手機號碼" class="inline-block full-width" v-model="form.cellPhone1"
                      :rules="[(val) => !!val || '請輸入手機號碼']" lazy-rules></c-input>
                  </div>
                </div>
              </c-field>
              <c-field stack-label label="Email">
                <c-input ref="emailField" placeholder="請輸入Email" v-model="form.email1"
                  :rules="[(val) => !!val || '請輸入Email', emailRule, emailExistedRule]" lazy-rules="ondemand"
                  @keyup="onFieldChanged('emailField')"></c-input>
              </c-field>
              <c-field stack-label label="姓名">
                <div class="row">
                  <div class="col-4 inline-block">
                    <c-input placeholder="姓" v-model="form.firstName" :rules="[(val) => !!val || '請輸入姓']"
                      lazy-rules></c-input>
                  </div>
                  <div class="col-8 inline-block">
                    <c-input placeholder="名" v-model="form.lastName" :rules="[(val) => !!val || '請輸入名']"></c-input>
                  </div>
                </div>
              </c-field>
              <c-field stack-label label="性別" :rules="[() => !!this.form.genderType || '請輸入性別']">
                <div class="q-pt-md"></div>
                <c-form-gender v-model="form.genderType" />
              </c-field>
              <c-field stack-label label="居住國家">
                <c-select v-model="form.liveCountry" emit-value map-options :options="countryCodeList" option-value="name"
                  option-label="value" :rules="[() => !!this.form.liveCountry || '請輸入居住國家']" lazy-rules />
              </c-field>
              <c-field stack-label label="出生年月日(西元)">
                <c-date-picker v-model="form.birthday"
                  :rules="[() => !!this.form.birthday || '請輸入出生年月日(西元)', childBirthdayRule]" lazy-rules></c-date-picker>
              </c-field>
            </div>
            <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
              <c-btn type="submit" label="下一步" class="app-wizard-next-btn"></c-btn>
            </div>
          </q-form>
        </c-child-layout>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Layout from "pages/child/Layout.vue";
import { ChildSignUpCommand } from "src/api/feature";
import { SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { User, isUsernameExisted, isEmailExisted } from "src/services";
import { QInput, scroll } from "quasar";
import FormGender from "components/business/FormGender.vue";

const { getScrollTarget, setVerticalScrollPosition } = scroll;

let typingTimer: ReturnType<typeof setTimeout>;

@Options({
  components: {
    "c-child-layout": Layout,
    "c-form-gender": FormGender,
  },
})
export default class Profile extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  subtitle!: string;

  @Prop({ type: Number })
  step: number = 2;

  phoneTypeList = [
    {
      label: "家長手機",
      value: "0",
    },
    {
      label: "兒童手機",
      value: "1",
    },
  ];
  countryCodeList!: Array<SystemConfigState>;

  xform = {
    confirmPassword: "",
  };

  form = {
    anotherChurchName: "",
    baptizedPerson: "",
    baptizedTime: "",
    baptizedType: "",
    birthday: "",
    cellAreaCode: "",
    cellAreaCode1: "",
    cellAreaCode2: "",
    cellPhone: "",
    cellPhone1: "",
    cellPhone2: "",
    churchGroupNo: "",
    churchType: "",
    eduType: "",
    email1: "",
    email2: "",
    firstName: "",
    genderType: "",
    idNumber: "",
    instagramId: "",
    isChurchGroup: "",
    isJoinChurchGroup: "",
    isMarried: "",
    joinInPersonDate1: "",
    joinInPersonDate2: "",
    joinInPersonDate3: "",
    joinInPersonLocation1: "",
    joinInPersonLocation2: "",
    joinInPersonLocation3: "",
    joinInPersonTime1: "",
    joinInPersonTime2: "",
    joinInPersonTime3: "",
    joinOnlineDate1: "",
    joinOnlineDate2: "",
    joinOnlineDate3: "",
    joinOnlineTime1: "",
    joinOnlineTime2: "",
    joinOnlineTime3: "",
    lastName: "",
    lineId: "",
    liveAddress: "",
    liveCity: "",
    liveCountry: "",
    liveZipArea: "",
    liveZipCode: "",
    memberType: "",
    name: "",
    otherSocialId: "",
    password: "",
    phone: "",
    phoneType: "0",
    professionType: "",
    userNo: "",
    weChatId: "",
  };

  oldUserNo = "";

  async mounted() {
    this.form = Object.assign(this.form, this.$appStore.getters.childSignUpState);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
    // 每次進入畫面需輸入密碼
    this.form.password = "";

    let uri = window.location.search.substring(1);
    let params = new URLSearchParams(uri);
    if (params.get("account")) {
      this.form.name = params.get("account") as string;
      this.oldUserNo = this.form.name;
    }
    this.xform.confirmPassword = "";

    if (this.$appStore.getters.userProfile.id != null) {
      try {
        const user = (await this.apis.feature.user.getUser(this.$appStore.getters.userProfile.id)).data;
        if (user !== null) {
          this.form.cellAreaCode1 = user.cellAreaCode1;
          this.form.cellPhone1 = user.cellPhone1;
        }
      } catch (e) {
        console.log(e);
      }
    }
  }

  gotoNext() {
    this.form.userNo = this.form.name;
    this.$appStore.mutations.setChildSignUpState(this.form as ChildSignUpCommand);
    void this.$router.push("/child/information");
  }

  childBirthdayRule() {
    const age = this.getAge(this.form.birthday);
    if (age > 15) return "兒童年齡不可大於15歲";
    return true;
  }

  getAge(birthday: string) {
    //出生时间 毫秒
    const birthDayTime = new Date(birthday).getTime();
    //当前时间 毫秒
    const nowTime = new Date().getTime();
    //一年毫秒数(365 * 86400000 = 31536000000)
    return Math.ceil((nowTime - birthDayTime) / 31536000000);
  }

  emailRule() {
    if (User.emailRule.test(this.form.email1)) {
      return true;
    }
    return "Email格式錯誤";
  }

  onFieldChanged(value: string) {
    clearTimeout(typingTimer);
    typingTimer = setTimeout(() => {
      void ((this.$refs[value] as QInput).$refs["field"] as QInput).validate();
    }, 1000);
  }

  async idExistedRule(newId: string) {
    var exist = await isUsernameExisted(newId);
    return !((newId != this.oldUserNo) && (exist == true)) || "無法使用此帳號進行註冊";
  }

  async emailExistedRule(value: string) {
    var result = await isEmailExisted(value);
    return !result || "無法使用此Email進行註冊";
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

<style lang="scss" scoped></style>
