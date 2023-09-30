<template>
  <c-auth-guard :isReady="isReady" :isAuthorized="$isAuthorized">
    <router-view />
  </c-auth-guard>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import { MyLocalStorage, MyLogger } from "src/util";
import { Console } from "console";
/* eslint-enable */

@Options({
  meta() {
    return {
      title: "",
    };
  },

  components: {},
})
export default class Index extends ComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  isReady = false;

  get $isAuthorized() {
    return true;
    // return this.$appStore.getters.isAuthorized;
  }

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async created() {
    try {
      this.isReady = true;
    } catch (ex) {
      MyLogger.error(ex);
      await this.$router.push({
        name: "Login",
      });
    } finally {
      this.hideLoading();
    }
  }
  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
