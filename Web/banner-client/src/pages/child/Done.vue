<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <c-wizard title="註冊" subtitle="註冊成功" step="5" showLoginButton="false">
          <div class="col items-center text-center">
            <div class="row">
              <div class="col-12">
                <div class="app-wizard-done-text">註冊成功</div>
              </div>
            </div>
            <div class="row">
              <div class="col-12">
                <q-btn
                  label="返回首頁"
                  class="app-verification-wizard-next-btn"
                  style="margin-top: 12px; margin-bottom: 120px; width: 112px"
                  :to="{ path: '/login' }"
                ></q-btn>
              </div>
            </div>
          </div>
        </c-wizard>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import Wizard from "pages/child/Layout.vue";

@Options({
  components: {
    "c-wizard": Wizard,
  },
})
export default class Done extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.app-wizard-done-text {
  margin-top: 12px;
  margin-bottom: 12px;
  height: 30px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 24px;
  line-height: 125%;
  font-feature-settings: "tnum" on, "lnum" on;

  /* Primary/400 */
  color: #3764ac;
}
</style>
