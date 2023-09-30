<template>
  <div class="i-force-word-break">
    <div v-for="dc in detailColumns" :key="dc.name">
      <slot :name="`detail-cell-${dc.name}`" v-bind="{ label: dc.label, value: dc.field(props.row), props }">
        <strong>{{ dc.label }}<c-colon /></strong>
        {{ dc.field(props.row) }}
      </slot>
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

@Options({})
export default class DetailColumns extends ElementaryBase {
  /**
   * type is the same as columns
   */
  @Prop({ default: () => [] })
  private detailColumns!: [];

  @Prop({ default: () => ({}) })
  private props!: unknown;

  /**
   */
  created() {
    //
  }
}
</script>
