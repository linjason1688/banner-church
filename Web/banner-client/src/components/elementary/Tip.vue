<template>
  <div class="doc-note doc-note--tip" :style="{ 'border-color': $color, 'background-color': $bgColor }">
    <p class="doc-note__title"><slot name="title"></slot></p>
    <p>
      <slot></slot>
    </p>
  </div>
</template>

<script lang="ts">
/**
 * NOTE:
 * https://github.com/vuejs/vue-class-component/issues/406
 * https://davidjamesherzog.github.io/2020/12/30/vue-typescript-decorators/
 */

/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";

import { colors } from "quasar";
/* eslint-enable */

@Options({})
export default class Tip extends ComponentBase {
  // ========== props ==========

  @Prop({ type: String, default: "primary", required: false })
  private color!: string;

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========
  get $color() {
    return colors.getPaletteColor(this.color || "primary");
  }

  get $bgColor() {
    return colors.changeAlpha(this.$color, 0.15);
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

<style lang="scss" scoped>
.doc-note {
  font-family: Avenir, -apple-system, BlinkMacSystemFont, Segoe UI, Helvetica, Arial, sans-serif;
  background-color: #f5f5f5;
  border-radius: 4px;
  margin: 16px 0;
  padding: 16px 24px;
  font-size: 1em;
  line-height: 1.35em;
  border-width: 0 5px;
  border-style: solid;
  border-color: #eee;
  letter-spacing: 0.5px;
}

.doc-note__title {
  font-weight: 500;
  padding-bottom: 8px;
}

.doc-note--tip {
  //
}
</style>
