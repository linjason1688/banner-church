<template>
  <c-btn v-bind="$attrs" rounded class="q-px-lg c-primary-color-500 c-primary-background-100" dense unelevated>
    <q-icon left name="print" />
    <slot>匯出</slot>
  </c-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnPrint extends ButtonBase {}
</script>
