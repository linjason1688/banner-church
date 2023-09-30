<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="個人基本資料" step="1">
          <q-form @submit="gotoNext" class="q-gutter-y-md">
            <div>
              <c-field label="帳號">
                <c-input placeholder="請輸入帳號" v-model="form.name" :rules="[(val) => !!val || '請輸入帳號']"></c-input>
              </c-field>
              <c-field label="密碼">
                <c-input
                  placeholder="請輸入8-12位英數字"
                  v-model="form.password"
                  type="password"
                  :rules="[(val) => !!val || '請輸入密碼']"
                ></c-input>
              </c-field>
              <c-field label="確認密碼">
                <c-input
                  placeholder="請再次確認密碼"
                  v-model="xform.confirmPassword"
                  type="password"
                  :rules="[(val) => !!val || '請輸入確認密碼']"
                ></c-input>
              </c-field>
              <c-field label="手機號碼">
                <div class="row">
                  <div class="col-4 q-pr-md">


                    <c-select class="inline-block full-width" emit-value map-options :options="countryCodeList" v-model="xform.countryCode"
                              :option-value="value"
                              :option-label="opt => Object(opt) === opt && '+' + opt.value + ' ' + opt.name"  :rules="[(val) => !!val || '國碼']" />
                  </div>
                  <div class="col-8">
                    <c-input
                      placeholder="輸入手機號碼"
                      class="inline-block full-width"
                      v-model="form.cellPhone"

                       :rules="[(val) => !!val || '輸入手機號碼',
                           (val) =>  val.length >= 10 || '請輸入輸入手機號碼10位以上數字',
                           (val) => /^\d+$/.test(val) || '密碼只允許數字']"

                    ></c-input>
                  </div>
                </div>
              </c-field>
              <c-field label="Email">
               <c-input placeholder="請輸入Email" v-model="form.email1"
                         :rules="[(val) => !!val || '請輸入Email', emailRule]"></c-input>
              </c-field>
              <c-field label="姓名">
                <div class="row">
                  <div class="col-4 inline-block q-pr-md">
                    <c-input placeholder="姓" v-model="form.firstName"></c-input>
                  </div>
                  <div class="col-8 inline-block">
                    <c-input placeholder="名" v-model="form.lastName"></c-input>
                  </div>
                </div>
              </c-field>
              <c-field label="性別">
                <div class="q-pt-md"></div>
                <c-option-group label="性別" :options="genderList" v-model="form.genderType" />
              </c-field>
              <c-field label="居住國家">
                <c-select v-model="form.liveCountry"
                          emit-value map-options :options="countryCodeList"
                          option-value="value"
                          option-label="name"
                />
              </c-field>
              <c-field label="出生年月日(西元)">
                <c-date-picker v-model="form.birthday"></c-date-picker>
              </c-field>
            </div>
            <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
              <c-btn type="submit" label="下一步" class="app-wizard-next-btn"></c-btn>
            </div>
          </q-form>
        </c-wizard>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Wizard from "pages/signup/Wizard.vue";
import { SignUpState } from "src/data/dto/SignUpState";
import {
  CreateUserBankAccountCommand,
  CreateUserContactCommand,
  CreateUserExpertiseCommand,
  CreateUserFamilyCommand,
} from "src/api/feature";
import { SystemConfigState } from "src/data/dto/SystemConfigState";
import { SystemConfig } from "src/util";
import { User } from "src/services";

@Options({
  components: {
    "c-wizard": Wizard,
  },
})
export default class Profile extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  subtitle!: string;

  @Prop({ type: String })
  gender!: string;

  genderList = [
    {
      label: "男",
      value: "1",
    },
    {
      label: "女",
      value: "0",
    },
  ];

  xform = {
    confirmPassword: "",
    countryCode: "",
  };

  countryCodeList!: Array<SystemConfigState>;

  form = {
    anotherChurchName: "",
    baptizedPerson: "",
    baptizedTime: "",
    baptizedType: "",
    birthday: "",
    cellAreaCode: "",
    cellPhone: "",
    cellPhone1: "",
    cellPhone2: "",
    churchGroupNo: "",
    churchType: "",
    countryCode: "",
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
    isOldMember: "",
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
    pastoralId: "",
    phone: "",
    phoneType: "",
    professionType: "",
    userBankAccounts: new Array<CreateUserBankAccountCommand>(),
    userContracts: new Array<CreateUserContactCommand>(),
    userExpertises: new Array<CreateUserExpertiseCommand>(),
    userFamilies: new Array<CreateUserFamilyCommand>(),
    userNo: "",
    weChatId: ""
  };

  mounted() {
    this.form = Object.assign(this.form, this.$appStore.getters.signUpState);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
    // 每次進入畫面需輸入密碼
    this.form.password = "";
    this.xform.confirmPassword = "";
  }

  gotoNext() {
    if (this.xform.confirmPassword !== this.form.password) {
      this.showErrorNotify("新舊密碼不符");
      return;
    }


    this.$appStore.mutations.setSignUpState(this.form as unknown as SignUpState);
    void this.$router.push("/signup/verification");
  }

  emailRule() {
    if (User.emailRule.test(this.form.email1)) {
      return true;
    }
    return "Email格式錯誤";
  }
}
</script>

<style lang="scss" scoped></style>
