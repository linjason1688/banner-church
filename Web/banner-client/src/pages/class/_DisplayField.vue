<template>
  <div class="c-content-title c-text-color-100 q-mt-lg q-mb-sm">{{ label }}</div>
  <div class="c-content-body c-text-color-100 q-mb-xs q-mt-xs">
    <slot></slot>
  </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { FormBase } from "components/form/FormBase";

@Options({})
export default class DisplayField extends FormBase {

  @Prop({ type: String, default: () => "" })
  protected readonly label!: string;

  created() {
    //
  }
}
</script>
