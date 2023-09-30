<template>
  <c-row>
    <div class="col-12 col-md-6">
      <c-sub-title title="帳號資訊"> </c-sub-title>
      <q-form @save.prevent="save()">
        <c-form-card>
          <c-column label="帳號" required>
            <c-input placeholder="請輸入帳號" v-model="form.userNo" :rules="[(val: any) => !!val || '請輸入帳號']" role="n"
              disable></c-input>
          </c-column>
          <c-column label="密碼" required>
            <c-password-field ref="passwordField" placeholder="請輸入8-12位英數字" v-model="form.password" role="n"
              autocomplete="password"></c-password-field>
            <template v-slot:append>
              <q-btn class="c-heading-h5 c-text-color-white c-primary-background-500" no-wrap unelevated rounded
                color="primary" label="變更密碼" @click="updatePassword()" />
            </template>
          </c-column>
        </c-form-card>
      </q-form>

      <c-sub-title title="個人資訊"> </c-sub-title>
      <c-form-card>
        <c-field>
          <c-column class="name-label" label="姓名" required>
            <c-input placeholder="請輸入姓名" v-model="form.name" :rules="[(val: any) => !!val || '請輸入姓名']" role="n"></c-input>
          </c-column>
          <c-column label="性別" required :rules="[() => !!form.genderType || '請輸入性別']">
            <c-option-group label="性別" :options="genderList" v-model="form.genderType" disable />
          </c-column>
          <c-column label="身分證字號（或居留證/護照號碼）">
            <c-input placeholder="請輸入身分證字號或居留證/護照號碼" v-model="form.idNumber" role="n"></c-input>
          </c-column>
          <c-column label="出生年月日(西元)" required>
            <c-date-picker v-model="form.birthday" min="1900-01-01" :rules="[(val: any) => !!val || '請輸入出生年月日(西元)']"
              role="n"></c-date-picker>
          </c-column>
          <c-column label="教育程度">
            <c-select class="inline-block full-width" emit-value map-options :options="eduList" v-model="form.eduType"
              option-label="value" option-value="name" role="o"></c-select>
          </c-column>
          <c-column label="職業">
            <c-select class="inline-block full-width" emit-value map-options :options="professionTypeList"
              v-model="form.professionType" option-label="value" option-value="name" role="o"></c-select>
          </c-column>
          <c-column label="婚姻" required>
            <div class="row other">
              <c-option-group class="col-4" label="婚姻" :options="marriageList" v-model="form.isMarried" />
              <c-input class="col-8 " v-if="form.isMarried === '2'" placeholder="自填"
                v-model="form.anotherMarried"></c-input>
            </div>
          </c-column>
        </c-field>
      </c-form-card>
      <c-sub-title title="社群資料"> </c-sub-title>
      <c-form-card>
        <c-field :rules="[(val: any) => !!val || societyRule() || '社群帳號為必填']">
          <div>
            <div class="row q-ma-none c-content-body q-px-md q-mb-md">
              <p>社群帳號</p>
              <p class="app-required">　*</p>
            </div>
            <c-field stack-label label="Line" class="q-px-md q-mb-md">
              <c-input placeholder="" v-model="form.lineId"></c-input>
            </c-field>
            <c-field stack-label label="Instagram" class="q-px-md q-mb-md">
              <c-input placeholder="" v-model="form.instagramId"></c-input>
            </c-field>
            <c-field stack-label label="WeChat" class="q-px-md q-mb-md">
              <c-input placeholder="" v-model="form.weChatId"></c-input>
            </c-field>
            <c-field stack-label label="其他" class="q-px-md q-mb-md">
              <c-input placeholder="若沒有社群帳號請填寫：無" v-model="form.otherSocialId"></c-input>
            </c-field>
          </div>
        </c-field>

      </c-form-card>
    </div>
    <div class="col-12 col-md-6">
      <c-sub-title title="信仰資料"> </c-sub-title>
      <c-form-card>
        <div class="row">
          <div class="col-12">
            <c-form-group-baptized v-model:baptizedType.sync="form.baptizedType" v-model:baptizeday.sync="form.baptizeday"
              v-model:churchType.sync="form.churchType" v-model:churchName.sync="form.churchName"
              v-model:anotherChurchName.sync="form.anotherChurchName" v-model:baptizer.sync="form.baptizer"
              v-model:otherComment.sync="form.otherComment"></c-form-group-baptized>
          </div>
          <div class="col-12">
            <c-column stack-label label="旌旗主日聚會點" required>
              <c-select v-model="form.meetingPointId" class="inline-block full-width" emit-value map-options
                :options="meetingPointList" option-label="name" option-value="id" role="o"></c-select>
            </c-column>
          </div>
        </div>
      </c-form-card>

      <c-sub-title title="入組意願調查"> </c-sub-title>
      <c-form-card class="q-mb-sm">
        <div>
          <q-radio v-model="xform.isJoinChurchGroup" val="0" class="q-px-sm" label="只是訪客，暫無入組意願" />
        </div>
        <div>
          <q-radio v-model="xform.isJoinChurchGroup" val="1" class="q-px-sm" label="對加入小組有意願" />
          <div class="q-ml-sm" v-if="xform.isJoinChurchGroup === '1'">
            <q-checkbox v-model="xform.join" label="實體" />
            <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
              <c-form-group-meetup sequence="1" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate1"
                v-model:time.sync="form.joinInPersonTime1" v-model:church.sync="form.joinInPersonLocation1" />
              <c-form-group-meetup sequence="2" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate2"
                v-model:time.sync="form.joinInPersonTime2" v-model:church.sync="form.joinInPersonLocation2" />
              <c-form-group-meetup sequence="3" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate3"
                v-model:time.sync="form.joinInPersonTime3" v-model:church.sync="form.joinInPersonLocation3" />
            </q-card>
            <q-checkbox v-model="xform.online" label="線上" />
            <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
              <c-form-group-meetup sequence="1" meetupCategory="online" v-model:day.sync="form.joinOnlineDate1"
                v-model:time.sync="form.joinOnlineTime1" />
              <c-form-group-meetup sequence="2" meetupCategory="online" v-model:day.sync="form.joinOnlineDate2"
                v-model:time.sync="form.joinOnlineTime2" />
              <c-form-group-meetup sequence="3" meetupCategory="online" v-model:day.sync="form.joinOnlineDate3"
                v-model:time.sync="form.joinOnlineTime3" />
            </q-card>
          </div>
        </div>
        <div>
          <q-radio v-model="xform.isJoinChurchGroup" val="2" class="q-px-sm" label="已參加小組" />
          <c-column v-if="xform.isJoinChurchGroup === '2'" label="">
            <c-input placeholder="請填入小組編號" v-model="form.churchGroupNo" role="n"></c-input>
          </c-column>
        </div>
      </c-form-card>
    </div>
  </c-row>
  <c-sub-title title="通訊資料"> </c-sub-title>
  <c-form-card :rules="[(val: any) => !!val || AddressRule() || '社群帳號為必填']">
    <c-row>
      <div class="col-12 col-sm-6">
        <c-column label="通信地址" required></c-column>
        <c-column label="居住國家">
          <c-select class="inline-block full-width" emit-value map-options :options="countryCodeList"
            v-model="form.liveCountry" option-label="value" option-value="name" role="o"></c-select>
        </c-column>
        <c-row v-if="xform.domestic">
          <c-column label="城市" class="col-12 col-sm-6">
            <c-select class="inline-block full-width" emit-value map-options :options="cityCodeList"
              v-model="form.liveCity" option-label="value" option-value="name" role="o"></c-select>
          </c-column>
          <c-column label="地區" class="col-12 col-sm-6">
            <c-select class="inline-block full-width" emit-value map-options :options="areaCodeList"
              v-model="form.liveZipArea" option-label="value" option-value="name" role="o"></c-select>
          </c-column>
          <c-column label="郵遞區號" class="col-12">
            <c-input v-model="form.liveZipCode" role="n"></c-input>
          </c-column>
          <c-column label="詳細地址" class="col-12">
            <c-input v-model="form.liveAddress" role="n"></c-input>
          </c-column>
        </c-row>
        <c-row v-else>
          <c-column label="住址1" class="col-12">
            <c-input placeholder="輸入地址" v-model="form.liveAddress" role="n"></c-input>
          </c-column>
          <c-column label="住址2" class="col-12">
            <c-input placeholder="輸入地址" v-model="form.liveAddress2" role="n"></c-input>
          </c-column>
          <c-column label="郵遞區號" class="col-12">
            <c-input v-model="form.liveZipCode" role="n"></c-input>
          </c-column>
        </c-row>
      </div>
      <div class="col-12 col-sm-6">
        <c-column label="手機號碼" required>
          <template v-slot:prepend>
            <c-select emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode1"
              :option-label="(opt: any) => Object(opt) === opt && '+' + opt.value + ' ' + opt.name" option-value="name"
              :rules="[(val: any) => !!val || '請選擇國碼']" role="o" />
          </template>
          <c-input placeholder="輸入手機號碼" v-model="form.cellPhone1" :rules="[(val: any) => !!val || '請輸入手機號碼']"
            role="n"></c-input>
          <template v-slot:append>
            <q-btn v-if="!sendingPhoneCode" color="indigo" label="取得手機驗證碼"
              @click="() => sendCellphoneCode('Sms', form.cellPhone1)" no-wrap unelevated rounded />
            <div v-if="sendingPhoneCode" class="inline-block app-verification-counter-text">
              {{ cellphoneCounter }} 秒後重新發送
            </div>
            <div v-if="(verificationCode == form.cellphone1Verification) && (form.cellphone1Verification != '')"
              class="verify">
              <div class="icon-left">
                <img src="/img/step-check.svg" alt="" class="q-mr-sm">
              </div>
              <div class="verify-success">
                <span>驗證成功</span>
              </div>
            </div>
          </template>
          <c-field stack-label>
            <c-input placeholder="驗證碼" v-model="form.cellphone1Verification" :rules="[(val: any) => !!val || '請輸入驗證碼']" />
          </c-field>
          <c-row class="cancel-and-confirm">
            <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" label="取消"
              @click="cellphoneCancel()" />
            <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" label="確認"
              type="submit" @click="cellphoneGoToNext()" />
          </c-row>
        </c-column>
        <c-column class="col-12 col-sm-6" label="手機號碼2">
          <template v-slot:prepend>
            <c-select emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode2"
              :option-label="(opt: any) => Object(opt) === opt && '+' + opt.value + ' ' + opt.name" option-value="name"
              role="o" />
          </template>
          <c-input placeholder="輸入手機號碼" v-model="form.cellPhone2" role="n"></c-input>
        </c-column>
        <c-column class="col-12" label="電話（市話）">
          <c-input placeholder="輸入電話" v-model="form.phone" role="n"></c-input>
        </c-column>
        <c-column class="col-12" label="Email" required>
          <c-input ref="emailField" placeholder="abc@gmail.com" v-model="form.email1"
            :rules="[(val: any) => !!val || '請輸入Email', (val: any) => emailRule(val)]" role="n"></c-input>
          <template v-slot:append>
            <q-btn v-if="!sendingMailCode" class="c-heading-h5 c-text-color-white c-primary-background-500" label="電子郵件驗證"
              @click="sendEmailCode('Email', form.email1)" no-wrap unelevated rounded color="primary" />
            <div v-if="sendingMailCode" class="inline-block app-verification-counter-text">
              {{ emailCounter }} 秒後重新發送
            </div>
            <div v-if="(verificationCode == form.email1Verification) && (form.email1Verification != '')" class="verify">
              <div class="icon-left">
                <img src="/img/step-check.svg" alt="" class="q-mr-sm">
              </div>
              <div class="verify-success">
                <span>驗證成功</span>
              </div>
            </div>
          </template>
          <c-field stack-label>
            <c-input placeholder="驗證碼" v-model="form.email1Verification" :rules="[(val: any) => !!val || '請輸入驗證碼']" />
          </c-field>
          <c-row class="cancel-and-confirm">
            <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" label="取消"
              @click="emailCancel()" />
            <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" label="確認"
              @click="emailGoToNext()" />
          </c-row>
        </c-column>
        <c-column class="col-12" label="Email2">
          <c-input placeholder="請輸入Email" v-model="form.email2" role="n"
            :rules="[(val: any) => emailRule(val)]"></c-input>
        </c-column>
      </div>
    </c-row>
  </c-form-card>
  <c-savecancel-group @save="save()" @cancel="cancel()" />
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { formatDate, SystemConfig } from "src/util";
import {
  MeetingPointView,
  FetchAllOrganizationRequest,
  OrganizationView,
  SignUpCommand,
  SystemConfigView,
  UpdatePasswordCommand,
  PasswordResetType,
} from "src/api/feature";
import SubTitle from "components/SubTitle.vue";
import { Emit, Watch } from "vue-property-decorator";
import FormOrganization from "components/business/FormOrganization.vue";
import { TaiwanCountryCode } from "src/data/constants";
import { User } from "src/services";
import { QCard, QForm, QInput } from "quasar";
import FormRow from "src/components/form/FormRow.vue";
import { from } from "rxjs";
import { val } from "dom7";
import { identifier } from "@babel/types";
import { validate } from "json-schema";
import { send } from "process";

let typingTimer: ReturnType<typeof setTimeout>;

interface IdName$ {
  id: number;
  name: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
    "c-form-organization": FormOrganization,
  },
})
export default class Profile extends ComponentBase {
  meetingPointList: Array<MeetingPointView> = [];
  eduList: Array<SystemConfigView> = [];
  professionTypeList: Array<SystemConfigView> = [];
  careList: Array<SystemConfigView> = [];
  churchNameList: Array<SystemConfigView> = [];
  countryCodeList: Array<SystemConfigView> = [];
  cityCodeList: Array<SystemConfigView> = [];
  contactAreaList: Array<SystemConfigView> = [];
  areaCodeList: Array<SystemConfigView> = [];

  waitingSeconds = 60;
  sendingPhoneCode = false;
  sendingMailCode = false;
  cellphoneCounter = 1;
  emailCounter = 1;

  genderList = [
    {
      label: "男性",
      value: "1",
    },
    {
      label: "女性",
      value: "0",
    },
  ];

  marriageList = [
    {
      label: "單身",
      value: "0",
    },
    {
      label: "已婚",
      value: "1",
    },
    {
      label: "其他",
      value: "2",
    }
  ];

  xform = {
    join: false,
    online: false,
    domestic: true,
    isJoinChurchGroup: "1",
  };

  form = {
    //信仰狀態及受洗資料
    baptizedType: "",
    baptizeday: "",
    churchType: "",
    churchName: {},
    anotherChurchName: "",
    baptizer: "",
    otherComment: "",

    birthday: "",
    cellAreaCode: "",
    cellPhone: "",
    cellAreaCode1: {},
    cellPhone1: "",
    cellAreaCode2: "",
    cellPhone2: "",
    churchGroupNo: "",
    countryCode: "",
    eduType: "",
    email1: "",
    email2: "",
    firstName: "",
    genderType: "",
    id: 0,
    idNumber: "",
    instagramId: "",
    isBaptize: "",
    isChurchGroup: "",
    isJoinChurchGroup: "",
    isMarried: "",
    anotherMarried: "",
    isOldMember: "",
    isTerm: "",
    joinInPersonDate1: "",
    joinInPersonDate2: "",
    joinInPersonDate3: "",
    joinInPersonLocation1: {},
    joinInPersonLocation2: {},
    joinInPersonLocation3: {},
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
    liveAddress2: "",
    liveAddress: "",
    liveCity: "",
    liveCountry: "",
    liveZipArea: "",
    liveZipCode: "",
    memberType: "",
    meetingPointId: "",
    name: "",
    otherSocialId: "",
    password: "",
    phone: "",
    phoneType: "",
    professionType: "",
    userNo: "",
    weChatId: "",
    verificationType: "",
    verification: "",
    cellphone1Verification: "",
    email1Verification: ""
  };
  socialAccount = {
    lineId: this.form.lineId,
    instergramId: this.form.instagramId,
    otherSocialId: this.form.otherSocialId,
    weChatId: this.form.weChatId,
  };

  private organizationList: Array<OrganizationView> = [];

  @Watch("form.liveCountry", { immediate: true, deep: true })
  onLiveCountryChanged(val: string) {
    this.xform.domestic = val === TaiwanCountryCode;
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
    //
    console.log(val);
  }

  @Watch("form.churchName", { immediate: true, deep: true })
  onChurchNameChanged(val: string) {
    //
    console.log(val);
  }

  verificationCode = "";

  get account() {
    return this.form.verificationType === PasswordResetType.Email
      ? this.$appStore.state.signUpState.email1
      : this.$appStore.state.signUpState.cellAreaCode1 + this.$appStore.state.signUpState.cellPhone1
  }

  get verificationType() {
    return this.form.verificationType === PasswordResetType.Email
      ? PasswordResetType.Email
      : PasswordResetType.Sms;
  }

  async mounted() {
    if (!this.$appStore.getters.userProfile.id) {
      void this.$router.push("/Login");
    }
    await this.loadState();
  }

  async sendCellphoneCode(passwordResetType: string, account: string) {
    this.sendingPhoneCode = true;
    this.cellphoneCounter = this.waitingSeconds;

    await this.apis.feature.user.sendVerification({
      account: account,
      resetType: passwordResetType as PasswordResetType,
    })
      .then(e => {
        this.verificationCode = e.data.token;
      })

    let timer = setInterval(() => {
      this.cellphoneCounter -= 1;
      if (this.cellphoneCounter <= 0) {
        this.sendingPhoneCode = false
        this.cellphoneCounter = this.waitingSeconds;
        clearInterval(timer);
      }
    }, 1000);
  }

  async sendEmailCode(passwordResetType: string, account: string) {
    this.sendingMailCode = true;
    this.emailCounter = this.waitingSeconds;

    await this.apis.feature.user.sendVerification({
      account: account,
      resetType: passwordResetType as PasswordResetType,
    })
      .then(e => {
        this.verificationCode = e.data.token;
      })

    let timer = setInterval(() => {
      this.emailCounter -= 1;
      if (this.emailCounter <= 0) {
        this.sendingMailCode = false
        this.emailCounter = this.waitingSeconds;
        clearInterval(timer);
      }
    }, 1000);
  }

  cellphoneCancel() {
    this.form.cellPhone1 = "";
    this.form.cellphone1Verification = "";
  }

  cellphoneGoToNext() {
    if (this.verificationCode !== this.form.cellphone1Verification) {
      this.showErrorNotify("驗證碼錯誤");
      return;
    }
    else {
      this.showSuccessNotify("驗證成功");
      return;
    }
  }

  emailCancel() {
    this.form.email1 = "";
    this.form.email1Verification = "";
  }

  emailGoToNext() {
    if (this.verificationCode != this.form.email1Verification) {
      this.showErrorNotify("驗證碼錯誤");
      return;
    }
    else {
      this.showSuccessNotify("驗證成功");
      return;
    }
  }

  async save() {
    console.log(this.societyRule())
    if (this.form.password && this.form.name && this.form.genderType && this.form.birthday && this.form.isMarried && this.form.baptizedType && this.form.meetingPointId && this.societyRule() && this.AddressRule() && this.form.cellPhone && this.form.email1) {
      let form = Object.assign({ ...this.$appStore.getters.signUpState }, this.form);

      this.form.isJoinChurchGroup = "";
      if (this.xform.isJoinChurchGroup === "2") {
        form.isChurchGroup = "1";
      } else {
        form.isChurchGroup = "0";
        form.isJoinChurchGroup = this.xform.isJoinChurchGroup;
      }
      let signupCommand = form as SignUpCommand;
      signupCommand.churchName = this.fromOrganization(this.form.churchName as IdName$);
      signupCommand.joinInPersonLocation1 = this.fromOrganization(this.form.joinInPersonLocation1 as IdName$);
      signupCommand.joinInPersonLocation2 = this.fromOrganization(this.form.joinInPersonLocation2 as IdName$);
      signupCommand.joinInPersonLocation3 = this.fromOrganization(this.form.joinInPersonLocation3 as IdName$);
      await this.apis.feature.user.updateMember(this.$appStore.getters.userProfile.id, signupCommand);
      this.showSuccessNotify("保存成功");
      await this.loadState();

    } else {
      this.showErrorNotify("還有尚未填寫的欄位");
    }
  }

  toOrganization(id: string) {
    return this.organizationList.find((e) => e.id.toString() == id) as IdName$;
  }

  async loadState() {
    this.eduList = this.$appStore.getters.getSystemConfig(SystemConfig.EduType);

    this.professionTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.JobType);

    this.careList = this.$appStore.getters.getSystemConfig(SystemConfig.CareType);
    this.churchNameList = this.$appStore.getters.getSystemConfig(SystemConfig.ChurchNameList);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
    this.cityCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CityCode);

    this.meetingPointList = (await this.apis.feature.meetingPoint.fetchMeetingPoints()).data;

    this.organizationList = (
      await this.apis.feature.organization.fetchOrganizations({} as FetchAllOrganizationRequest)
    ).data;

    let userId = this.$appStore.getters.userProfile.id;
    let user = await this.apis.feature.user.getUser(userId);
    this.form = Object.assign(this.form, user.data);
    this.form.password = "";
    this.form.churchName = this.toOrganization(user.data.churchName);
    this.form.joinInPersonLocation1 = this.toOrganization(user.data.joinInPersonLocation1);
    this.form.joinInPersonLocation2 = this.toOrganization(user.data.joinInPersonLocation2);
    this.form.joinInPersonLocation3 = this.toOrganization(user.data.joinInPersonLocation3);
    this.xform.join = !(
      this.form.joinInPersonDate1 === "" &&
      this.form.joinInPersonDate2 === "" &&
      this.form.joinInPersonDate1 === ""
    );
    this.xform.online = !(
      this.form.joinOnlineDate1 === "" &&
      this.form.joinOnlineDate2 === "" &&
      this.form.joinOnlineDate3 === ""
    );
    if (this.form.meetingPointId == "0") {
      this.form.meetingPointId = "";
    }
    if (this.form.isChurchGroup === "0" && this.form.isJoinChurchGroup === "0") {
    } else if (this.form.isChurchGroup === "1") {
      this.xform.isJoinChurchGroup = "2";
    } else {
      this.xform.isJoinChurchGroup = this.form.isJoinChurchGroup;
    }

    if (this.form.birthday) {
      this.form.birthday = formatDate(this.form.birthday);
    }

  }

  cancel() {
    console.log("onClickCancel");
  }

  async updatePassword() {
    var status = ((this.$refs["passwordField"] as QInput).$refs["field"] as QInput).validate();
    if (status == false) {
      return;
    }

    const request = {
      userId: this.$appStore.getters.userProfile.id,
      password: this.form.password,
    } as UpdatePasswordCommand;
    await this.apis.feature.user.updatePassword(request);
    this.showSuccessNotify("修改密碼成功");
  }

  private fromOrganization(val: IdName$) {
    if (!val) return "";
    if (!val.hasOwnProperty("id")) return val.toString();
    if (val.id) return val.id.toString();
    return "";
  }

  onFieldChanged(value: string) {
    clearTimeout(typingTimer);
    typingTimer = setTimeout(() => {
      void ((this.$refs[value] as QInput).$refs["field"] as QInput).validate();
    }, 1000);
  }

  societyRule() {
    if (this.form.lineId ||
      this.form.instagramId ||
      this.form.weChatId ||
      this.form.otherSocialId) {
      return true;
    } else {
      return false;
    }
  }
  AddressRule() {
    if (this.form.liveCountry &&
      this.form.liveCity &&
      this.form.liveZipArea &&
      this.form.liveZipCode &&
      this.form.liveAddress) {
      return true;
    } else {
      return false;
    }
  }

  emailRule(email: string) {
    if (User.emailRule.test(email)) {
      return true;
    }
    return "Email格式錯誤";
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables";

.name-label {
  width: 222px;
}


.q-field--with-bottom {
  padding-bottom: 0;
}

.q-field__control .row {
  display: flex;
}

.other {
  display: flex;
  align-items: center;
  justify-content: space-between;

  .q-option-group {
    margin: 0;
    padding: 0;
    line-height: 4;
  }
}

.verify {
  display: flex;
  align-items: center;
}

.icon-left {
  display: flex;
  align-items: center;
  flex-direction: row;
}

.verify-success {
  display: flex;
  justify-content: center;
  text-align: center;
}

.cancel-and-confirm {
  display: flex;
  justify-content: center;
  text-align: center;
  margin-top: 10px;
}
</style>
