<template>
  <q-layout>
    <q-page-container>
      <q-page>
        <div style="background: #0c3178">
          <div class="row window-height">
            <div class="col">
              <div class="row">
                <div class="logo">
                  <img src="/img/logo.svg" alt="Logo" />
                </div>
              </div>
              <div class="row flex flex-center items-center justify-center">
                <div>
                  <div class="app-main">
                    <img src="/img/main.svg" alt="Main" />
                  </div>
                </div>
              </div>
            </div>
            <div class="col flex flex-center items-center justify-center" style="background: white">
              <slot></slot>
            </div>
          </div>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class MainLayout extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables";

//html, body {
//  height: 100%;
//  margin: 0;
//}
//
//.full-height {
//  height: 100%;
//  background: yellow;
//}
</style>
