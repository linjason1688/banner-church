<template>
  <q-select
    v-bind="$attrs"
    v-bind:[attr.outlined]="true"
    v-bind:[attr.rounded]="true"
    v-bind:[attr.dense]="true"
    ref="el"
    behavior="menu"
  >
    <template v-for="(_, slot) of $slots" v-slot:[slot]="scope"><slot :name="slot" v-bind="scope" /></template>
  </q-select>
</template>

<script lang="ts">
// Component
import { QSelect } from "quasar";
import { Options } from "vue-class-component";
import { Prop, Ref } from "vue-property-decorator";
import { FormBase } from "./FormBase";

@Options({})
export default class FormSelect extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  @Ref("el")
  el!: QSelect;

  created() {
    this.switchByRole("FormSelect", this.role);
  }
}
</script>
