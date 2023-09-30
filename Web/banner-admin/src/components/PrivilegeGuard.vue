<template>
  <template v-if="$hasPrivilege">
    <slot />
  </template>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
/* eslint-enable */

@Options({})
export default class PrivilegeGuard extends ComponentBase {
  // ========== props ==========
  @Prop({ type: String, default: "", required: true })
  private readonly fid!: string;

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========
  get $hasPrivilege() {
    return this.$privilege?.nodes.some((it) => it.functionId === this.fid);
  }

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  mounted() {
    //
  }

  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
