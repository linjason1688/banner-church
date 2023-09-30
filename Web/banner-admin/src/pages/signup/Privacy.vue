<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <div class="column justify-center items-center app-privacy-title-title">線上奉獻規範與個資使用說明</div>
        <div></div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class Privacy extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.app-privacy-title-title {
  width: 750px;
  height: 80px;
  background: #0c3176;

  font-family: "Inter";
  font-style: normal;
  font-weight: 800;
  font-size: 24px;
  line-height: 34px;
  /* identical to box height, or 142% */

  font-feature-settings: "tnum" on, "lnum" on;
  color: #ffffff;
}
</style>
