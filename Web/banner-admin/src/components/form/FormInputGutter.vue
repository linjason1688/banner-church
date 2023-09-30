<template>
    <q-input 
    v-bind="$attrs" 
    v-bind:[attr.rounded]="true" 
    v-bind:[attr.dense]="true"
    class="q-px-md q-mb-md"
    >
        <slot></slot>

        <template v-slot:after>
            <slot name="after"></slot>
        </template>
    </q-input>
  </template>
  
  <script lang="ts">
  // Component
  import { Options } from "vue-class-component";
  import { Prop } from "vue-property-decorator";
  import { FormBase } from "./FormBase";
  
  @Options({})
  export default class FormInputGutter extends FormBase {
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
  