<template>
  <div id="q-app">
    <router-view />
  </div>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import { MyLocalStorage } from "src/util";
/* eslint-enable */

@Options({
  meta() {
    return {
      title: "",
    };
  },

  components: {},
})
export default class App extends ComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  created() {
    console.log("APP READY ");
    //
    this.showLoading();
  }

  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
