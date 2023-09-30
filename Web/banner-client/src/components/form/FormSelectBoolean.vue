<template>
  <q-select
    v-bind="$attrs"
    v-bind:[attr.rounded]="true"
    v-bind:[attr.dense]="true"
    :options="options"
    option-label="text"
    option-value="value"
    map-options
    outlined
  >
    <slot></slot>
  </q-select>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { FormBase } from "./FormBase";

@Options({})
export default class FormSelectBoolean extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  options = [
    { text: "請選擇", value: undefined },
    { text: "是", value: true },
    { text: "否", value: false },
  ];

  created() {
    this.switchByRole("FormSelect", this.role);
  }
}
</script>
