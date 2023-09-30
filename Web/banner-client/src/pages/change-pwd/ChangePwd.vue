<template>
  <div class="fullscreen relative-position c-background-content">
    <img class="app-wizard-logo q-ma-md" src="/img/logo-r.svg" alt="Banner Church" />
    <div class="q-mx-auto bg-white q-px-xl q-py-md" style="width:fit-content">
      <div class="text-h5 text-center">變更密碼</div>
      <div class="q-mx-auto bg-grey-1 q-pa-xl q-ma-md">
        <c-column stack-label label="舊密碼">
          <c-input type="password" v-model="form.oldPassword" placeholder="請輸入舊密碼"
            :rules="[v => !!v || '請輸入舊密碼']"></c-input>
        </c-column>
        <c-column stack-label label="新密碼">
          <c-input type="password" v-model="form.password" placeholder="請輸入8~12個英數字元"
            :rules="[v => !!v || '請輸入新密碼']"></c-input>
        </c-column>
        <c-column stack-label label="確認密碼">
          <c-input type="password" v-model="confirmPassword" placeholder="再度輸入新密碼"
            :rules="[v => v == form.password || '與新密碼不一致']"></c-input>
        </c-column>
      </div>
      <q-btn class="text-center q-mx-xl" style="width:200px" color="indigo" rounded @click="savePassword">儲存</q-btn>
    </div>
    <q-dialog v-model="dialogSuccess">
      <q-card class="text-center q-px-xl q-py-md">
        <p class="text-weight-bold text-h5 q-mb-md">變更成功</p>
        <div>密碼變更完成！</div>
        <div>請使用新密碼進行登入。</div>
        <q-btn class="q-mt-md" color="indigo" rounded @click="$router.push('/m/login')">立刻登入</q-btn>
      </q-card>
    </q-dialog>
    <q-dialog v-model="dialogError">
      <q-card class="text-center q-px-xl q-py-md">
        <p class="text-weight-bold text-h5 q-mb-md">資料錯誤</p>
        <div>{{ errorMessage }}</div>
        <q-btn class="q-mt-md" color="indigo" rounded @click="dialogError = false">OK</q-btn>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ResetPasswordCommand } from "src/api/feature";
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class ChangePwd extends ComponentBase {
  dialogSuccess = false;
  dialogError = false;
  errorMessage = "";
  confirmPassword = "";
  @Prop({ type: String })
  title!: string;
  form = {} as ResetPasswordCommand;
  async savePassword() {
    this.form.email1 = this.$appStore.getters.userProfile.email;
    if (this.confirmPassword != this.form.password) return;
    const res = await this.apis.feature.user.resetPassword(this.form);
    if (res.data.result) this.dialogSuccess = true;
    else {
      this.dialogError = true;
      this.errorMessage = res.message;
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables";
</style>
