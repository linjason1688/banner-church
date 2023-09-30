<template>
  <c-mask-input v-bind="$attrs" :formatter="format" minlength="8" maxlength="10"> <slot></slot></c-mask-input>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";

@Options({})
export default class MaskIdInput extends FormBase {
  format(v: string) {
    // TODO: do some format to the value
    return v;
  }
}
</script>
