<template>
  <c-main-layout>
    <q-form @submit="send" class="q-gutter-y-md">
      <div class="column flex-center">
        <div class="row text-h6">忘記密碼</div>
        <div class="row text-subtitle2" style="padding-top: 16px; padding-bottom: 16px">輸入您的Email或電話號碼</div>
        <div class="row app-account-tabs cursor-pointer">
          <div class="col-6" @click="xform.resetByEmail = true">
            <div :class="emailClass">Email</div>
          </div>
          <div class="col-6" @click="xform.resetByEmail = false">
            <div :class="cellPhoneClass">手機</div>
          </div>
        </div>
        <div class="row full-width">
          <div class="col-12">
            <c-input v-if="xform.resetByEmail" label="Email" placeholder="請輸入Email" v-model="form.account"
                     :rules="[(val) => !!val || '請輸入Email',
                              (val) => xform.validateEmail(val) || '不合法的Email']" />
            <c-input v-if="!xform.resetByEmail" label="手機號碼" placeholder="請輸入手機號碼" v-model="form.account"
                     :rules="[(val) => !!val || '請輸入手機號碼']" />
          </div>
        </div>
        <div class="row">
          <c-btn type="submit" :label="buttonText" :class="buttonClass" :disabled="xform.isSending" />
        </div>
        <div class="row full-width" style="margin-top: 170px">
          <div class="col text-right">
            <c-btn flat label="返回登入" :to="{ path: '/Login' }"></c-btn>
          </div>
        </div>
      </div>
    </q-form>
  </c-main-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { StringUtility } from "src/util";
import { SendVerificationCodeRequest } from "src/api/feature";

export default class ResetPwd extends ComponentBase {
  waitingSeconds = 60;
  xform = {
    resetByEmail: true,
    isSending: false,
    buttonText: "發送Email",
    counter: 60,
    validateEmail: StringUtility.validateEmail,
  };
  form = {
    account: "",
  };

  get emailClass() {
    return this.xform.resetByEmail ? "app-account-tab" : "app-account-tab-inverse q-btn--actionable";
  }

  get cellPhoneClass() {
    return this.xform.resetByEmail ? "app-account-tab-inverse q-btn--actionable" : "app-account-tab";
  }

  get buttonText() {
    const text = this.xform.resetByEmail ? "發送Email" : "發送簡訊";
    return this.xform.isSending ? `${this.xform.counter}秒後重新發送` : text;
  }

  get buttonClass() {
    return this.xform.isSending ? "app-account-email-btn-inverse" : "app-account-email-btn";
  }

  mounted() {
    //
  }

  async send() {
    this.xform.isSending = true;

    const form = {
      "account": this.form.account,
      "resetType": this.xform.resetByEmail ? "Email" : "Sms",
    };

    // eslint-disable-next-line @typescript-eslint/no-unsafe-call
    await this.apis.feature.user.sendVerification(form as SendVerificationCodeRequest);
    this.xform.counter = this.waitingSeconds;
    let timer = setInterval(() => {
      this.xform.counter -= 1;
      if (this.xform.counter <= 0) {
        this.xform.isSending = false;
        this.xform.counter = this.waitingSeconds;
        clearInterval(timer);
      }
    }, 1000);
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
@import "../../css/app.scss";
</style>
