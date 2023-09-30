<template>
  <!--  <q-page class="column flex-center">-->
  <!--    <h3 class="q-ma-none">歡迎</h3>-->
  <!--    <h4 class="text-primary">BannerChurch</h4>-->
  <!--  </q-page>-->
  <c-menu-layout> </c-menu-layout>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */

@Options({
  meta() {
    return {
      title: "歡迎",
    };
  },

  components: {},
})
export default class HomePage extends ComponentBase {
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

<style lang="scss" scoped></style>
