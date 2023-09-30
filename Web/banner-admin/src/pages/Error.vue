<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <div class="row">
          <div class="col-5">
            <div class="col-12">
              <div class="app-page-error-message-code">500</div>
            </div>
            <div class="col-12">
              <div class="app-page-error-message inline-block">內部伺服器發生錯誤，請</div>
              <div class="app-page-error-message inline-block">聯繫網站管理員</div>
            </div>
            <div class="col-12">
              或 <q-btn :to="{ name: 'Home' }" label="返回首頁" color="primary" rounded unelevated />
            </div>
          </div>
          <div class="col-7">
            <img class="app-page-message-image" src="/img/500.svg" alt="404" />
          </div>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ComponentBase } from "src/components/ComponentBase";

@Options({
  meta() {
    return {
      title: "Error",
    };
  },

  components: {},
})
export default class ErrorPage extends ComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    //
  }

  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped>
@import "../css/quasar.variables.scss";

.app-page-error-message {
  //width: 324px;
  height: 25px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 140%;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #282828;
}

.app-page-error-message-code {
  width: 170px;
  height: 120px;

  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 96px;
  line-height: 125%;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #282828;
}

.app-page-message-image {
  width: 611.94px;
  height: 400.98px;
}
</style>
