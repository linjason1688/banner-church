<template>
  <q-btn v-bind="$attrs" class="q-ma-xs" color="blue darken-1">
    <slot>下載</slot>
    <q-icon class="q-ml-xs" name="cloud_download"></q-icon>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnExport extends ButtonBase {}
</script>
