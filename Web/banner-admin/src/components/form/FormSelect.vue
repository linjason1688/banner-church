<template>
  <q-select 
    v-bind="$attrs" 
    v-bind:[attr.rounded]="true" 
    v-bind:[attr.dense]="true" 
    v-bind:[attr.outlined]="true" 
    v-bind:[attr.behavior]="true"
    v-bind:[attr.class]="true"
    ref="el"
    class="c-form-select"
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

<style lang="scss" scoped>
  @import "../../css/quasar.variables.scss";

  .c-form-select{
    background-color: white; 
    background-clip: content-box;
  }
</style>
  