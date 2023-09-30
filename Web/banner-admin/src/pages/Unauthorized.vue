<template>
  <q-layout>
    <q-page-container>
      <q-page class="column flex-center">
        <h4>很抱歉，無此頁面，或您無權限存取！</h4>
        <span v-show="$target">({{ $from }} - {{ $target }})</span>
        <q-btn
          :to="{ name: $from }"
          icon-right="arrow_back"
          label="返回"
          size="lg"
          color="primary"
          rounded
          unelevated
        />
      </q-page>
    </q-page-container>
  </q-layout>
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
      title: "Not Found",
    };
  },
  components: {},
})
export default class UnauthorizedPage extends ComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========
  get $target() {
    return this.$route.params["target"];
  }

  get $from() {
    return this.$route.params["from"] || "Home";
  }
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
