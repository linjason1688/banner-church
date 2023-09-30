<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <div class="row">
          <div class="col-5">
            <div class="col-12">
              <div class="app-page-not-found-message-code">WIP</div>
            </div>
            <div class="col-12">
              <div class="app-page-not-found-message">網頁仍在建置中......。</div>
            </div>
            <div class="col-12">
              或 <q-btn icon-right="home" label="返回首頁" color="primary" rounded unelevated @click="back()" />
            </div>
          </div>
          <div class="col-7">
            <img class="app-page-not-found-image" src="/img/wip.svg" alt="WIP" />
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
      title: "Not Found",
    };
  },

  components: {},
})
export default class NotFoundPage extends ComponentBase {
  async mounted() {
    //
  }
  back() {
    this.$router.back();
  }
}
</script>

<style lang="scss" scoped>
@import "../css/quasar.variables.scss";

.app-page-not-found-message {
  width: 324px;
  height: 25px;
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 140%;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #282828;
}

.app-page-not-found-message-code {
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

.app-page-not-found-image {
  width: 611.94px;
  height: 400.98px;
}
</style>
