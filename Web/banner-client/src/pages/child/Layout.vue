<template>
  <q-layout view="hHh lpr fFf" style="background-color: #e9f1ff">
    <header class="app-wizard-header">
      <div class="row" style="display: flex; justify-content: center">
        <div class="col-4">
          <img class="app-wizard-logo" src="/img/logo-r.svg" alt="Banner Church" />
        </div>
        <div class="col-4 vertical-middle" style="text-align: center; vertical-align: middle; justify-content: center">
          <div class="app-wizard-title">
            {{ title }}
          </div>
        </div>
        <div class="col-4" style="text-align: right">
          <div>
            <div class="app-wizard-has-account inline-block">如果您已有帳號，前往</div>
            <c-btn label="登入" class="inline-block app-wizard-signin-btn" @click="gotoSignIn()"></c-btn>
          </div>
        </div>
      </div>
    </header>
    <section style="top: 136px">
      <div class="column items-center">
        <div class="app-wizard-section">
          <div class="column items-center" style="margin-top: 64px">
            <div class="col" style="width: 688px">
              <c-subtitle :title="subtitle" :requiredMark="requiredMark"></c-subtitle>
              <div class="row" style="margin-top: 24px">
                <div class="col">
                  <div class="">
                    <slot> </slot>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class Layout extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  subtitle!: string;

  @Prop({ type: Number })
  step: number = 1;

  @Prop({ type: String })
  requiredMark!: string;

  async mounted() {
    //
  }

  async gotoSignIn() {
    await this.$appStore.actions.logoutAsync();
    await this.$router.push("/Login");
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.app-wizard-section {
  background-color: #ffffff;
  width: 1040px;
}

.app-wizard-title {
  /* H3 */
  font-family: "Inter";
  font-style: normal;
  font-weight: 800;
  font-size: 24px;
  line-height: 34px;
  /* identical to box height, or 142% */

  font-feature-settings: "tnum" on, "lnum" on;
  /* Primary/500 */

  color: $primary-color;
}

.app-wizard-has-account {
  /* Content/Subtitle */

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  line-height: 140%;
  /* or 22px */

  font-feature-settings: "tnum" on, "lnum" on;

  /* TextColor/60% */

  color: rgba(40, 40, 40, 0.6);
  margin-right: 8px;
}

.app-wizard-logo {
  height: 59.507347106933594px;
  width: 161px;
  border-radius: 0;
}

.app-wizard-header {
  margin-top: 32px;
  margin-left: 32px;
  margin-bottom: 32px;
}

.app-wizard-signin-btn {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 10px 24px;
  gap: 8px;

  width: 76px;
  height: 40px;

  /* Primary/500 */

  background: #0c3176;
  border-radius: 20px;

  /* Inside auto layout */

  flex: none;
  order: 0;
  flex-grow: 0;
  margin-right: 32px;
}

.app-wizard-line {
  border: 1.5px solid #0c3176;
  width: 120px;
}

.app-wizard-line-inverse {
  border: 1.5px solid #dbdbdb;
  width: 120px;
}

.app-wizard-subtitle {
  width: 32px;
  height: 10px;

  /* Primary/500 */

  background: #0c3176;
  transform: rotate(90deg);

  /* Inside auto layout */

  flex: none;
  order: 0;
  flex-grow: 0;
}

.app-wizard-subtitle-label {
  /* Content/Title */
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 140%;
  /* or 25px */

  font-feature-settings: "tnum" on, "lnum" on;

  /* Primary/500 */

  color: #0c3176;

  /* Inside auto layout */

  flex: none;
  order: 1;
  flex-grow: 0;
}

.app-wizard-subtitle-br {
  width: 100%;
  height: 0;
  /* Primary/500 */

  border: 2px solid #0c3176;

  /* Inside auto layout */

  flex: none;
  order: 1;
  align-self: stretch;
  flex-grow: 0;
}
</style>
