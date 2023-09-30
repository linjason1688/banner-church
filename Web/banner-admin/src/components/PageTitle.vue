<template>
  <h5 class="q-ma-none text-primary">
    {{ $fnName }}
    <q-tooltip :delay="500" :offset="[0, 0]" anchor="bottom left" self="top left">
      {{ $fnId }}
    </q-tooltip>
  </h5>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import Enumerable from "linq";
/* eslint-enable */

@Options({})
export default class PageTitle extends ComponentBase {
  // ========== props ==========
  //   TODO: 新增 property 供傳入顯示 title
  // ========== vuex ==========

  // ========== data ==========

  fnId = "";
  fnName = "";

  // ========== computed ==========
  get $fnId() {
    if (this.fnId) {
      return this.fnId;
    }
    const fnId = this.$route.name as string;
    return fnId;
  }

  get $fnName() {
    if (this.fnName) {
      return this.fnName;
    }
    const fnId = this.$route.name as string;

    const node = this.tryGetNodeOf(fnId);

    return node.name;
  }

  // ========== watch ==========

  // ========== refs ==========
  @Ref()
  readonly button!: HTMLButtonElement;

  // ========== hook ==========
  mounted() {
    //
    this.fnId = this.$route.params.$fnId as string;
    this.fnName = this.$route.params.$fnName as string;
  }

  // ========== methods ==========
  /**
   * 動詞＋名詞
   */
  tryGetNodeOf(fnId: string) {
    const privilegeMap = this.$appStore.state.privilegeHashMap;
    const node = privilegeMap[fnId] || {};

    return node;
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
