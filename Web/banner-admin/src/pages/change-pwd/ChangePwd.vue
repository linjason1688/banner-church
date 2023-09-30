<template>
  <div>
    <div class="row">Login</div>
    <div class="row">
      <div class="app-changepwd-content">
        <div>變更密碼</div>
        <c-field label="新密碼">
          <c-input placeholder="請輸入8~12個英數字元"></c-input>
        </c-field>
        <c-field label="確認密碼">
          <c-input placeholder="再度輸入新密碼"></c-input>
        </c-field>
      </div>
      <div class="app-changepwd-btn-panel">
        <c-btn label="確認送出"></c-btn>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class ChangePwd extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables";
</style>
