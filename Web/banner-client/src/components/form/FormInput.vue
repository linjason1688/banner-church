<template>
  <q-input v-bind="$attrs" v-bind:[attr.rounded]="true" v-bind:[attr.dense]="true" ref="field">
    <slot></slot>
    <template v-slot:append>
      <slot name="append"></slot>

      <div v-if="hasToolTip">
        <q-icon name="info" color="secondary" />

        <q-tooltip anchor="bottom right" self="top right" :offset="[12, 16]">
          <slot name="tool-tip"></slot>
        </q-tooltip>
      </div>
    </template>
  </q-input>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { FormBase } from "./FormBase";

@Options({})
export default class FormInput extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  get hasToolTip() {
    return !!this.$slots["tool-tip"];
  }

  created() {
    this.switchByRole("FormInput", this.role);
  }
}
</script>
