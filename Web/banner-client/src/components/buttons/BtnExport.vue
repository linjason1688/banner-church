<template>
  <q-btn v-bind="$attrs" class="q-ma-xs" color="teal">
    <slot>匯出</slot>
    <q-icon class="q-ml-xs" name="save_alt"></q-icon>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnExport extends ButtonBase {}
</script>
