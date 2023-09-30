<template>
  <div class="row justify-center q-pa-md">
    <div class="col-12 col-md-8">
      <c-sub-title title="退款費用專用帳戶"> </c-sub-title>
      <c-form-card>
        <div class="row">
          <div class="col-12">
            <c-column label="戶名">
              <c-input v-model="form.bankName" role="n"></c-input>
            </c-column>
            <c-column label="銀行代號">
              <c-select
                class="inline-block full-width"
                emit-value
                map-options
                :options="bankList"
                v-model="form.bankCode"
                option-label="label"
                option-value="value"
                role="o"
              ></c-select>
            </c-column>
            <c-column label="分行代號">
              <c-input v-model="form.branchCode" role="n"></c-input>
            </c-column>
            <c-column label="銀行帳戶">
              <c-input v-model="form.account" role="n"></c-input>
            </c-column>
            <p class="q-px-md q-mb-md c-content-body c-info-color-600 column items-end">
              若當初支付方式為現金或匯款一率採取匯款退費
            </p>
          </div>
        </div>
      </c-form-card>
    </div>
    <c-savecancel-group class="app-savecancel-group-fixed" @save="save()" @cancel="cancel()" />
  </div>
</template>

<script lang="ts">
/* eslint-disable */
import { Prop } from "vue-property-decorator";
/* eslint-enable */
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { CreateUserBankAccountCommand, SignUpCommand } from "src/api/feature";
import SubTitle from "components/SubTitle.vue";

/* eslint-disable */
interface BankAccount$ {
  bankName: string;
  bankCode: string;
  branchCode: string;
}
/* eslint-enable */

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class Payment extends ComponentBase {
  bankList = [
    {
      label: "004 臺灣銀行",
      value: "004",
    },
    {
      label: "807 永豐銀行",
      value: "807",
    },
    {
      label: "812 台新國際商業銀行",
      value: "812",
    },
  ];

  form = {
    id: 0,
    account: "",
    bankCode: "",
    bankName: "",
    branchCode: "",
  };

  async mounted() {
    console.log(this.$appStore.getters.userProfile);
    let userId = this.$appStore.getters.userProfile.id;
    let user = await this.apis.feature.user.getUser(userId);
    this.form = Object.assign(this.form, user.data);
    for (let i = 0; i < user.data.userBankAccounts.length; i++) {
      const a = user.data.userBankAccounts[i];
      this.form.account = a.account;
      this.form.bankCode = a.bankCode;
      this.form.bankName = a.bankName;
      this.form.branchCode = a.branchCode;
    }
  }

  async save() {
    let user = await this.apis.feature.user.getUser(this.$appStore.getters.userProfile.id);
    let form = Object.assign({ ...this.$appStore.getters.signUpState }, user.data, this.form);
    let signupCommand = form as SignUpCommand;
    signupCommand.userBankAccounts.push({
      account: this.form.account,
      bankCode: this.form.bankCode,
      bankName: this.form.bankName,
      branchCode: this.form.branchCode,
    } as CreateUserBankAccountCommand);
    await this.apis.feature.user.updateMember(this.$appStore.getters.userProfile.id, signupCommand);
    this.showSuccessNotify("保存成功");
  }

  cancel() {
    console.log("onClickCancel");
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
