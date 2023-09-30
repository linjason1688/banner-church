<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-child-layout title="為12歲以下兒童註冊" subtitle="基本資料" step="1">
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
                <div class="col-4">
                  <c-select class="inline-block full-width"
                            emit-value map-options :options="countryCodeList" v-model="xform.countryCode"
                            :option-value="value"
                            :option-label="opt => Object(opt) === opt && '+' + opt.value + ' ' + opt.name" />
                </div>
                <div class="col-8">
                  <c-input
                    placeholder="輸入手機號碼"
                    class="inline-block full-width"
                    v-model="form.cellPhone"
                  ></c-input>
                </div>
              </div>
            </c-field>
            <c-field label="Email">
              <c-input placeholder="請輸入Email" v-model="form.email1"> </c-input>
            </c-field>
            <c-field label="姓名">
              <div class="row">
                <div class="col-4 inline-block">
                  <c-input placeholder="姓" v-model="form.firstName"></c-input>
                </div>
                <div class="col-8 inline-block">
                  <c-input placeholder="名" v-model="form.lastName"></c-input>
                </div>
              </div>
            </c-field>
            <c-field label="性別">
              <div class="q-pt-md"></div>
              <c-option-group :options="genderList" v-model="form.genderType" />
            </c-field>
            <c-field label="居住國家">
              <c-select v-model="form.liveCountry"
                        emit-value map-options :options="countryCodeList"
                        option-value="value"
                        option-label="name" />
            </c-field>
            <c-field label="出生年月日(西元)">
              <c-date-picker v-model="form.birthday"></c-date-picker>
            </c-field>
          </div>
          <div class="column items-center" style="margin-bottom: 48px; margin-top: 24px">
            <c-btn label="下一步" class="app-wizard-next-btn" @click="gotoNext()"></c-btn>
          </div>
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

@Options({
  components: {
    "c-child-layout": Layout,
  },
})
export default class Profile extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  subtitle!: string;

  @Prop({ type: Number })
  step: number = 2;

  genderList = [
    {
      label: "男",
      value: "F",
    },
    {
      label: "女",
      value: "M",
    },
  ];

  phoneTypeList = [
    {
      label: "家長手機",
      value: "0",
    },
    {
      label: "小孩手機",
      value: "1",
    },
  ];
  countryCodeList!: Array<SystemConfigState>;

  xform = {
    confirmPassword: "",
  }

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
    pastoralId: "",
    phone: "",
    phoneType: "",
    professionType: "",
    userNo: "",
    weChatId: ""

  };

  mounted() {
    this.form = Object.assign(this.form, this.$appStore.getters.childSignUpState);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
    // 每次進入畫面需輸入密碼
    this.form.password = "";
    this.xform.confirmPassword = "";
  }

  gotoNext() {
    let form = Object.assign({ ...this.$appStore.getters.childSignUpState }, this.form);
    form.parentUserId = this.$appStore.getters.userProfile.id;
    this.$appStore.mutations.setChildSignUpState(form as ChildSignUpCommand);
    void this.$router.push("/child/information");
  }
}
</script>

<style lang="scss" scoped></style>
